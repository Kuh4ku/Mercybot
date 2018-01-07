using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MercyBot.Core.Logs;
using MercyBot.Utility.Extensions;
using MercyBot.Core.Accounts.Network;
using MercyBot.Core.Accounts.InGame;
using MercyBot.Core.Enums;
using MercyBot.Core.Commands;
using MercyBot.Core.Accounts.Scripts;
using MercyBot.Configurations;
using MercyBot.Core.Accounts.Extensions;
using MercyBot.Protocol.Messages;
using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts.Configurations;
using MercyBot.Core.Accounts.Statistics;
using MercyBot.Core.Groups;
using System.Diagnostics;
using MercyBot.Utility;
using System.Dynamic;
using System.Threading;
using MercyBot.Configurations.Language;
using Newtonsoft.Json;

namespace MercyBot.Core.Accounts
{
    public class Account : ViewModelBase, IEntity, IDisposable
    {

        // Fields
        private AccountStates _state;
        private bool _wasScriptRunning;
        private DateTime? _subscriptionEndDate;
        private bool _wasScriptEnabled;


        // Properties
        public AccountConfiguration AccountConfig { get; private set; }
        public Configuration Configuration { get; private set; }
        public FramesData FramesData { get; private set; }
        public string Token { get; private set; }
        public string Login { get; internal set; }
        public DateTime? SubscriptionEndDate
        {
            get => _subscriptionEndDate;
            internal set => Set(ref _subscriptionEndDate, value);
        }
        public Logger Logger { get; private set; }
        public NetworkManager Network { get; private set; }
        public Game Game { get; private set; }
        public CommandsManager Commands { get; private set; }
        public ScriptsManager Scripts { get; private set; }
        public ExtensionsContainer Extensions { get; private set; }
        public StatisticsManager Statistics { get; private set; }
        public AccountStates State
        {
            get => _state;
            set
            {
                Set(ref _state, value);
                StateChanged?.Invoke();
            }
        }
        public Group Group { get; set; }
        public TimerWrapper PlanificationTimer { get; private set; }

        public bool IsBusy => State != AccountStates.NONE && State != AccountStates.REGENERATING;
        public Account Element => this;
        public bool HasGroup => Group != null;
        public bool IsGroupChief => !HasGroup || Group.Chief == this;


        // Events
        public event Action StateChanged;
        public event Action<Account> RecaptchaReceived;
        public event Action<Account, bool> RecaptchaResolved;


        // Constructor
        public Account(AccountConfiguration accountConfig)
        {
            AccountConfig = accountConfig;
            State = AccountStates.DISCONNECTED;

            FramesData = new FramesData();
            Configuration = new Configuration(this);
            Logger = new Logger();
            Network = new NetworkManager(this);
            Game = new Game(this);
            Commands = new CommandsManager(this);
            Scripts = new ScriptsManager(this);
            Extensions = new ExtensionsContainer(this);
            Statistics = new StatisticsManager(this);
            PlanificationTimer = new TimerWrapper(30000, Planification_Callback);

            Network.Disconnected += Network_Disconnected;
            Game.Map.MapLoaded += Map_MapLoaded;
        }


        public async Task Connect()
        {
            if (!PlanificationTimer.Enabled)
                PlanificationTimer.Start();

            FramesData.Clear();
            Network.Clear();
            Game.Clear();
            Extensions.Clear();
            Logger.LogInfo("", LanguageManager.Translate("10"));

            if (await SetToken())
            {
                State = AccountStates.CONNECTING;
                Logger.LogInfo("", LanguageManager.Translate("11"));
                await Network.ConnectToLoginServer();
            }
        }

        private async Task<bool> SetToken()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", AccountConfig.Username),
                new KeyValuePair<string, string>("password", AccountConfig.Password)
            });

            // HttpClient creation (with proxy if available)
            var httpClient = !AccountConfig.Proxy.IsValid ? 
                             new HttpClient() :
                             new HttpClient(new HttpClientHandler
                             {
                                 Proxy = new WebProxy(AccountConfig.Proxy.Url, false)
                                 {
                                     UseDefaultCredentials = false,
                                     Credentials = new NetworkCredential(AccountConfig.Proxy.Username, AccountConfig.Proxy.Password)
                                 },
                                 PreAuthenticate = true,
                                 UseDefaultCredentials = false
                             });

            using (httpClient)
            {
                var response = await httpClient.PostAsync("https://haapi.ankama.com/json/Ankama/v2/Api/CreateApiKey", content);
                var keyJson = await response.Content.ReadAsJsonAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("apiKey", keyJson.Value<string>("key"));
                    response = await httpClient.GetAsync("https://haapi.ankama.com/json/Ankama/v2/Account/CreateToken?game=18");

                    if (response.IsSuccessStatusCode)
                    {
                        Token = (await response.Content.ReadAsJsonAsync()).Value<string>("token");
                        return true;
                    }

                    Logger.LogError("", LanguageManager.Translate("32", response.StatusCode));
                }
                // Wrong username or password
                else if ((int)response.StatusCode == 601)
                {
                    Logger.LogError("", keyJson["reason"].ToString() == "BAN" ? LanguageManager.Translate("478") : LanguageManager.Translate("552"));
                }
                // Other errors
                else
                {
                    Logger.LogError("", LanguageManager.Translate("32", response.StatusCode));
                }
            }

            return false;
        }

        public async Task HandleRecaptcha(string sitekey, int tries = 1)
        {
            State = AccountStates.RECAPTCHA;
            // If _wasScriptRunning was already true, don't change it
            _wasScriptRunning = _wasScriptRunning || Scripts.Enabled;
            Scripts.StopScript();
            RecaptchaReceived?.Invoke(this);

            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                Logger.LogDebug("reCaptcha", "Getting response..");
                string response = RecaptchaHandler.GetResponse(sitekey);
                Logger.LogDebug("reCaptcha", "Got response.");

                // If the response is null, its because the user didn't enter an anti-captcha key
                if (response == null)
                {
                    // We shouldn't leave this True
                    _wasScriptRunning = false;
                    Logger.LogError(LanguageManager.Translate("71"), LanguageManager.Translate("73"));
                    RecaptchaResolved?.Invoke(this, false);
                }
                else
                {
                    Logger.LogInfo(LanguageManager.Translate("71"), LanguageManager.Translate("74", sw.Elapsed.TotalSeconds));

                    dynamic msg = new ExpandoObject();
                    msg.call = "recaptchaResponse";
                    msg.data = response;
                    string raw = JsonConvert.SerializeObject(msg);

                    Logger.LogDebug(LanguageManager.Translate("71"), LanguageManager.Translate("75"));
                    await Network.SendRawAsync(raw);

                    if (State == AccountStates.RECAPTCHA)
                    {
                        State = AccountStates.NONE;
                    }

                    // Resume script if this is a solo account
                    // Sometimes this will fail if we receive more than one captcha
                    if (!HasGroup && _wasScriptRunning)
                    {
                        await Task.Delay(2000);
                        Logger.LogDebug(LanguageManager.Translate("71"), LanguageManager.Translate("76"));
                        Scripts.StartScript();

                        // Only set reset _wasScriptRunning if the script was actually started
                        // Because if the bot received another recaptcha, StartScript will just return because IsBusy will be True
                        if (Scripts.Enabled)
                            _wasScriptRunning = false;
                    }
                    // Otherwise if this is a group member, trigger RecaptchaResolved
                    else if (HasGroup)
                    {
                        RecaptchaResolved?.Invoke(this, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("reCaptcha", ex.Message);
                if (tries < 3)
                {
                    Logger.LogError("reCatpcha", LanguageManager.Translate("582", ++tries));
                    await HandleRecaptcha(sitekey, tries);
                }
            }
        }

        #region States Checking

        public bool IsFighting()
            => State == AccountStates.FIGHTING;

        public bool IsGathering()
            => State == AccountStates.GATHERING;

        public bool IsInDialog()
            => State == AccountStates.STORAGE || State == AccountStates.TALKING || State == AccountStates.EXCHANGE || State == AccountStates.BUYING || State == AccountStates.SELLING;

        #endregion

        public void LeaveDialog()
        {
            if (IsInDialog())
            {
                Network.SendMessage(new LeaveDialogRequestMessage());
            }
        }

        private void Network_Disconnected(NetworkManager networkManager)
        {
            State = AccountStates.DISCONNECTED;
            Logger.LogWarning("Network", LanguageManager.Translate("31"));

            // In case there was a script enabled
            if (Network.Phase != NetworkPhases.SWITCHING_TO_GAME)
            {
                _wasScriptEnabled = Scripts.Enabled;
                Scripts.StopScript();
                Extensions.Flood.Stop();
            }
        }

        private async void Planification_Callback(object state)
        {
            if (!AccountConfig.PlanificationActivated)
                return;

            int hour = DateTime.Now.Hour;

            // If the bot is connected and the hour is red
            if (Network.Connected && AccountConfig.Planification[hour] == false && State != AccountStates.FIGHTING)
            {
                Logger.LogInfo("Planificateur", LanguageManager.Translate("584"));
                await Network.Disconnect("CLIENT_CLOSING");
            }
            // If the bot is disconnected and the hour is green
            else if (State == AccountStates.DISCONNECTED && AccountConfig.Planification[hour])
            {
                Logger.LogInfo("Planificateur", LanguageManager.Translate("585"));
                try
                {
                    await Connect();
                }
                catch (Exception ex)
                {
                    Logger?.LogError("", ex.ToString());
                }
            }
        }

        private async void Map_MapLoaded()
        {
            if (!AccountConfig.PlanificationActivated || !_wasScriptEnabled)
                return;

            await Task.Delay(1500);
            Logger.LogInfo("Planificateur", LanguageManager.Translate("583"));
            Scripts.StartScript();
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Logger.Dispose();
                    Network.Dispose();
                    Game.Dispose();
                    Scripts.Dispose();
                    Extensions.Dispose();
                    Configuration.Dispose();
                    Statistics.Dispose();
                    Commands.Dispose();
                    PlanificationTimer.Dispose();
                }

                _state = AccountStates.NONE;
                AccountConfig = null;
                Configuration = null;
                Token = null;
                Login = null;
                Logger = null;
                Network = null;
                Game = null;
                Scripts = null;
                Extensions = null;
                Statistics = null;
                FramesData = null;
                Commands = null;
                PlanificationTimer = null;

                _disposedValue = true;
            }
        }

        ~Account() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}