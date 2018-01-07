using GalaSoft.MvvmLight;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts;
using MercyBot.Core.Extensions;
using MercyBot.Core.Groups;
using MercyBot.Server.Enums;
using MercyBot.Server.Messages;
using MercyBot.Server.Network;
using MercyBot.Utility.Extensions;
using MercyBot.Utility.Security;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Windows;
using MercyBot.Configurations.Language;
using MercyBot.Utility.DofusTouch;
using ExtensionsEnum = MercyBot.Protocol.Server.Enums.Extensions;

namespace MercyBot.Server
{
    public class ServerManager : ViewModelBase
    {

        // Fields
        private readonly ClientWrapper _client;
        private string _name;
        private string _avatarUrl;
        private ServerConnectionStates _state;
        private readonly ConcurrentDictionary<Type, List<Action<object>>> _registeredMessages;
        private LoginRequestMessage _lastLrm;
        private DateTime? _touchEndDate;


        // Properties
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => Set(ref _avatarUrl, value);
        }
        public ServerConnectionStates State
        {
            get => _state;
            set => Set(ref _state, value);
        }
        public bool LoggedIn { get; private set; }
        public DateTime? TouchEndDate
        {
            get => _touchEndDate;
            set
            {
                _touchEndDate = value;
                RaisePropertyChanged();
            }
        }
        public Dictionary<ExtensionsEnum, DateTime> Extensions { get; private set; }
        public ServerStatistics Statistics { get; }

        public bool IsSubscribedToTouch => TouchEndDate != null && DateTime.Now < TouchEndDate;


        // Events
        public event Action LoginAccepted;


        // Constructor
        public ServerManager()
        {
            _client = new ClientWrapper();
            _registeredMessages = new ConcurrentDictionary<Type, List<Action<object>>>();
            State = ServerConnectionStates.DISCONNECTED;
            Statistics = new ServerStatistics(this);
            Extensions = new Dictionary<ExtensionsEnum, DateTime>();

            _client.Connected += Client_Connected;
            _client.DataReceived += Client_DataReceived;
            _client.ErrorOccured += Client_ErrorOccured;
            _client.Disconnected += Client_Disconnected;

            RegisterMessage<LoginAcceptedMessage>(HandleLoginAcceptedMessage);
            RegisterMessage<SubscriptionInformationsMessage>(HandleSubscriptionInformationsMessage);
            RegisterMessage<BotsInformationsRequestMessage>(HandleBotsInformationsRequestMessage);
            RegisterMessage<DTVersionsMessage>(HandleDTVersionsMessage);
            RegisterMessage<PingMessage>(HandlePingMessage);
        }


        public void Start()
        {
            if (_client.Running)
                return;

            _client.Connect("185.52.2.254", 1457); //185.52.2.254
            FunctionalitiesManager.Initialize();
        }

        public void RegisterMessage<T>(Action<T> handler) where T : IServerMessage
        {
            var msgType = typeof(T);
            if (!_registeredMessages.ContainsKey(msgType))
                _registeredMessages.TryAdd(msgType, new List<Action<object>>());

            _registeredMessages[msgType].Add((m) => handler((T)m));
        }

        public void SendMessage(IServerMessage message)
        {
            if (State != ServerConnectionStates.CONNECTED)
                return;

            var bytes = new List<byte>();

            using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
            {
                writer.Write(message.MessageId);
                message.Serialize(writer);

                bytes.AddRange(writer.GetAllBytes());

                // Insert the message length in the beginning
                bytes.InsertRange(0, BitConverter.GetBytes(bytes.Count));
            }

            _client.Send(bytes.ToArray());

            // Save the last LoginRequestMessage in case we need to reconnect
            if (message is LoginRequestMessage lrm)
            {
                _lastLrm = lrm;
            }
        }

        public bool HasExtension(ExtensionsEnum extension)
            => Extensions?.ContainsKey(extension) == true && Extensions?[extension] > DateTime.Now;

        #region Client events

        private void Client_Connected(ClientWrapper client)
        {
            State = ServerConnectionStates.CONNECTED;
        }

        private void Client_DataReceived(ClientWrapper client, byte[] data)
        {
            try
            {
                if (State != ServerConnectionStates.CONNECTED)
                    return;

                var message = MessagesBuilder.BuildMessage(data);

                // If the message failed to build, do nothing
                if (message == null)
                    return;

                Console.WriteLine("Received {0}.", message.GetType().Name);

                var type = message.GetType();
                if (!_registeredMessages.ContainsKey(type)) return;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (var action in _registeredMessages[type])
                    {
                        action.Invoke(message);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void Client_ErrorOccured(ClientWrapper client, Exception exception)
        {
            // If the connection to the server fails before we even log in, it probably means that the server is having a tough time
            if (!LoggedIn && exception is SocketException se && (se.SocketErrorCode == SocketError.ConnectionRefused || se.SocketErrorCode == SocketError.TimedOut))
            {
                try
                {
                    await Application.Current.Dispatcher.Invoke(async () =>
                    {
                        await (Application.Current.MainWindow as MetroWindow).ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("484"));
                    });
                }
                catch { }

                Environment.Exit(0);
            }
        }

        private void Client_Disconnected(ClientWrapper client)
        {
            State = ServerConnectionStates.DISCONNECTED;
        }

        #endregion

        #region Server messages

        private void HandleLoginAcceptedMessage(LoginAcceptedMessage message)
        {
            Name = message.Name;
            AvatarUrl = message.Avatar;
            LoggedIn = true;

            LoginAccepted?.Invoke();
        }

        private void HandleSubscriptionInformationsMessage(SubscriptionInformationsMessage message)
        {
            TouchEndDate = message.TouchEndDate;
            Extensions = message.Extensions;
        }

        private void HandleBotsInformationsRequestMessage(BotsInformationsRequestMessage message)
        {
            bool TryGenerateBot(Account account, out Bot bot)
            {
                bot = null;

                try
                {
                    if (account.Game.Character.IsSelected)
                    {
                        bot = new Bot
                        (
                            level: account.Game.Character.Level,
                            energyPercent: (byte)account.Game.Character.Stats.EnergyPercent,
                            weightPercent: (byte)account.Game.Character.Inventory.WeightPercent,
                            kamas: account.Game.Character.Inventory.Kamas,
                            mapId: account.Game.Map.Id,
                            mapPosition: account.Game.Map.CurrentPosition,
                            state: account.State.ToFriendlyString()
                        );

                        return true;
                    }
                }
                catch { }

                return false;
            }

            Dictionary<string, Bot> bots = new Dictionary<string, Bot>();

            foreach (var entity in MercyBotMain.Instance.Entities)
            {
                switch (entity)
                {
                    case Account account:
                    {
                        if (TryGenerateBot(account, out Bot bot))
                        {
                            bots.Add(account.AccountConfig.Username, bot);
                        }
                        break;
                    }
                    case Group group:
                    {
                        if (TryGenerateBot(group.Chief, out Bot bot))
                        {
                            bots.Add(group.Chief.AccountConfig.Username, bot);
                        }

                        for (int i = 0; i < group.Members.Count; i++)
                        {
                            if (TryGenerateBot(group.Members[i], out Bot mbot))
                            {
                                bots.Add(group.Members[i].AccountConfig.Username, mbot);
                            }
                        }
                        break;
                    }
                }
            }

            SendMessage(new BotsInformationsMessage(bots));
        }

        private void HandleDTVersionsMessage(DTVersionsMessage message)
        {
            Console.WriteLine("{0} {1} {2} {3}", message.AppVersion, message.BuildVersion, message.AssetsVersion, message.StaticDataVersion);
            DTConstants.AppVersion = message.AppVersion;
            DTConstants.BuildVersion = message.BuildVersion;
            DTConstants.AssetsVersion = message.AssetsVersion;
            DTConstants.StaticDataVersion = message.StaticDataVersion;
        }

        private void HandlePingMessage(PingMessage message)
        {
            SendMessage(new PongMessage());
        }

        #endregion

    }
}
