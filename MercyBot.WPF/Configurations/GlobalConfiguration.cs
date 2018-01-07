using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts;
using MercyBot.Core.Groups;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using MercyBot.Configurations.Language;

namespace MercyBot.Configurations
{
    public class GlobalConfiguration : ViewModelBase
    {

        #region Singleton

        private static GlobalConfiguration _instance;

        public static GlobalConfiguration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalConfiguration();

                return _instance;
            }
        }

        #endregion

        // Fields
        private readonly string _configPath = Path.Combine(Directory.GetCurrentDirectory(), "config.mb");
        private bool _loaded;
        private string _antiCaptchaKey;
        private bool _showDebugMessages;
        private Languages _language;
        private readonly SemaphoreSlim _semaphore;


        // Properties
        public ObservableCollection<AccountConfiguration> Accounts { get; }
        public string AntiCaptchaKey
        {
            get => _antiCaptchaKey;
            set
            {
                Set(ref _antiCaptchaKey, value);
                Save();
            }
        }
        public bool ShowDebugMessages
        {
            get => _showDebugMessages;
            set
            {
                Set(ref _showDebugMessages, value);
                Save();
            }
        }
        public string Username { get; set; }
        public Languages Language
        {
            get => _language;
            set
            {
                Set(ref _language, value);
                Save();
            }
        }
        
        public List<AccountConfiguration> AccountsList
        {
            get
            {
                var list = new List<AccountConfiguration>(Accounts);
                foreach (var connectedEntity in MercyBotMain.Instance.Entities)
                {
                    if (connectedEntity is Account a)
                        list.Remove(a.AccountConfig);
                    else if (connectedEntity is Group group)
                    {
                        list.Remove(group.Chief.AccountConfig);
                        foreach (var member in group.Members)
                        {
                            list.Remove(member.AccountConfig);
                        }
                    }
                }
                return list;
            }
        }
        public string Lang => Language == Languages.ENGLISH ? "en" : Language == Languages.FRENCH ? "fr" : "pt";


        // Constructor
        private GlobalConfiguration()
        {
            Accounts = new ObservableCollection<AccountConfiguration>();
            AntiCaptchaKey = "";
            ShowDebugMessages = true;
            Username = "";
            Language = Languages.FRENCH;
            _semaphore = new SemaphoreSlim(1, 1);
        }


        public void Load()
        {
            _loaded = false;

            if (File.Exists(_configPath))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Accounts.Clear();
                    try
                    {
                        using (BinaryReader br = new BinaryReader(File.Open(_configPath, FileMode.Open)))
                        {
                            int c = br.ReadInt32();
                            for (int i = 0; i < c; i++)
                            {
                                Accounts.Add(AccountConfiguration.Load(br));
                            }

                            AntiCaptchaKey = br.ReadString();
                            ShowDebugMessages = br.ReadBoolean();
                            Username = br.ReadString();
                            Language = (Languages)br.ReadByte();

                            for (int i = 0; i < Accounts.Count; i++)
                            {
                                for (int j = 0; j < 24; j++)
                                    Accounts[i].Planification[j] = br.ReadBoolean();

                                Accounts[i].PlanificationActivated = br.ReadBoolean();
                            }
                        }
                    }
                    catch
                    {
                        // Ignored
                    }
                });
            }

            _loaded = true;
        }

        public void Save()
        {
            // Avoid saving while we're just loading
            if (!_loaded)
                return;

            _semaphore.Wait();

            using (BinaryWriter bw = new BinaryWriter(File.Open(_configPath, FileMode.Create)))
            {
                bw.Write(Accounts.Count);
                foreach (var accountConfig in Accounts)
                {
                    accountConfig.Save(bw);
                }

                bw.Write(AntiCaptchaKey);
                bw.Write(ShowDebugMessages);
                bw.Write(Username);
                bw.Write((byte)Language);

                for (int i = 0; i < Accounts.Count; i++)
                {
                    for (int j = 0; j < 24; j++)
                        bw.Write(Accounts[i].Planification[j]);

                    bw.Write(Accounts[i].PlanificationActivated);
                }
            }

            _semaphore.Release();
        }

        public void AddAccountAndSave(string username, string password, string server, string character, string nickname)
        {
            Accounts.Add(new AccountConfiguration(username, password, server, character, nickname));
            RaisePropertyChanged("AccountsList");

            Save();
        }

        public void AddAccountsAndSave(IEnumerable<AccountConfiguration> accounts)
        {
            foreach (var account in accounts)
            {
                Accounts.Add(account);
            }

            RaisePropertyChanged("AccountsList");
            Save();
        }

        public void RemoveAccount(AccountConfiguration accountConfig)
        {
            Accounts.Remove(accountConfig);
            RaisePropertyChanged("AccountsList");
        }

        public AccountConfiguration GetAccount(string username)
            => Accounts.FirstOrDefault(a => a.Username == username);

    }
}
