using System;
using MercyBot.Utility.Extensions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Core.Network;
using System.Threading.Tasks;
using MercyBot.Utility.DofusTouch;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;
using GalaSoft.MvvmLight;
using MercyBot.Core.Frames;
using MercyBot.Configurations;

namespace MercyBot.Core.Accounts.Network
{
    public class NetworkManager : ViewModelBase, IClearable, IDisposable
    {

        // Fields
        private static readonly List<string> MessagesToIgnore = new List<string>
        {
            "ChatServerMessage", "BasicLatencyStatsRequestMessage", "BasicLatencyStatsMessage", "SequenceNumberRequestMessage", "SequenceNumberMessage", "BasicPingMessage"
        };
        private NetworkPhases _phase;
        private ConcurrentDictionary<string, RegisteredMessage> _registeredMessages;
        private PrimusWebSocket _webSocket;
        private Timer _pingTimer;
        private SemaphoreSlim _semaphore;
        private string _sessionId;
        private int _serverId;
        private string _serverAddress;
        private uint _serverPort;
        private string _access;


        // Properties
        public Account Account { get; private set; }
        public bool Connected { get; private set; }
        public NetworkPhases Phase
        {
            get => _phase;
            internal set
            {
                var oldValue = _phase;
                _phase = value;

                if (oldValue != _phase)
                    PhaseChanged?.Invoke(this);
            }
        }
        public List<NetworkMessage> Messages { get; private set; }


        // Events
        public event Action<NetworkManager> PhaseChanged;
        public event Action<NetworkManager> Disconnected;


        // Constructor
        public NetworkManager(Account account)
        {
            Account = account;
            _phase = NetworkPhases.NONE;
            _webSocket = new PrimusWebSocket();
            _pingTimer = new Timer(PingTimerCallback, null, 600000, 600000);
            _semaphore = new SemaphoreSlim(1);
            _registeredMessages = new ConcurrentDictionary<string, RegisteredMessage>();
            Messages = new List<NetworkMessage>();

            AddEvents();
        }


        public async Task ConnectToLoginServer()
        {
            if (Connected || Phase != NetworkPhases.NONE)
                return;

            _sessionId = 16.ToRandomString();
            await _webSocket.OpenAsync($"wss://proxyconnection.touch.dofus.com/primus/?STICKER={_sessionId}&transport=websocket",
                Account.AccountConfig.Proxy.Url, Account.AccountConfig.Proxy.Username, Account.AccountConfig.Proxy.Password);
        }

        public async Task SwitchToGameServer(string address, uint port, int serverId, string access)
        {
            if (!Connected || Phase != NetworkPhases.LOGIN)
                return;

            _serverAddress = address;
            _serverPort = port;
            _serverId = serverId;
            _access = $"{access.Replace("https", "wss")}/primus/?STICKER={_sessionId}&transport=websocket";
            Phase = NetworkPhases.SWITCHING_TO_GAME;

            await Disconnect("SWITCHING_TO_GAME").ConfigureAwait(false);
        }

        public async Task Disconnect(string reason)
        {
            if (!Connected)
                return;

            await _webSocket.CloseAsync(reason).ConfigureAwait(false);
        }

        #region Send Messages

        public async Task SendRawAsync(string text)
        {
            if (!Connected)
                return;

            await _semaphore.WaitAsync();

            await _webSocket.SendAsync(text).ConfigureAwait(false);

            _semaphore.Release();
        }

        public async Task SendCallAsync(Message message)
        {
            if (!Connected)
                return;

            await _semaphore.WaitAsync();

            var json = message.ToCall();
            await _webSocket.SendAsync(json).ConfigureAwait(false);

            // Register all messages except these ones
            if (!MessagesToIgnore.Contains(message.GetType().Name))
            {
                AddMessage(json, true);
            }

            _semaphore.Release();
        }

        public async Task SendMessageAsync(Message message)
        {
            if (!Connected)
                return;

            await _semaphore.WaitAsync();

            var json = message.ToSendMessage();
            await _webSocket.SendAsync(json).ConfigureAwait(false);

            // Register all messages except these ones
            if (!MessagesToIgnore.Contains(message.GetType().Name))
            {
                AddMessage(json, true);
            }

            _semaphore.Release();
        }

        public void SendMessage(Message message)
            => SendMessageAsync(message).Wait();

        #endregion

        public string RegisterMessage<T>(Func<Account, T, Task> action) where T : Message
        {
            if (_disposedValue)
                return null;

            Task NewAction(Account a, object o) => action(a, (T)o);
            string id = 16.ToRandomString();
            _registeredMessages.TryAdd(id, new RegisteredMessage(typeof(T), NewAction));

            return id;
        }

        public bool UnregisterMessage(string id)
            => _registeredMessages.TryRemove(id, out RegisteredMessage rm);

        public void Clear()
        {
            _sessionId = null;
            _serverId = 0;
            _serverAddress = null;
            _serverPort = 0;
            _access = null;
        }

        private async void PingTimerCallback(object state)
        {
            if (Connected)
            {
                await Account.Network.SendMessageAsync(new BasicPingMessage(true));
            }
            else
            {
                _pingTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void AddEvents()
        {
            _webSocket.Opened += WebSocket_Opened;
            _webSocket.Closed += WebSocket_Closed;
            _webSocket.MessageReceived += WebSocket_MessageReceived;
            _webSocket.ErrorOccured += WebSocket_ErrorOccured;
        }

        private void RemoveEvents()
        {
            _webSocket.Opened -= WebSocket_Opened;
            _webSocket.Closed -= WebSocket_Closed;
            _webSocket.MessageReceived -= WebSocket_MessageReceived;
            _webSocket.ErrorOccured -= WebSocket_ErrorOccured;
        }

        private void AddMessage(string message, bool sent)
        {
            if (Messages.Count >= 200)
                Messages.RemoveAt(0);

            Messages.Add(new NetworkMessage(message, sent));
        }

        #region Received Events

        private void WebSocket_ErrorOccured(PrimusWebSocket ws, Exception ex)
        {
            if (ex == null)
                return;

            Account.Logger.LogError("", ex.ToString());
        }

        private void WebSocket_MessageReceived(PrimusWebSocket ws, JObject json)
        {
            var messageType = json["_messageType"].ToString();

            var message = MessagesBuilder.GetMessage(messageType, json);

            if (message == null)
            {
                Console.WriteLine($"Message not found: {messageType}");
                return;
            }

            // Register all messages except these ones
            if (!MessagesToIgnore.Contains(messageType))
            {
                AddMessage(json.ToString(Formatting.None), false);
            }

            FramesManager.HandleMessage(Account, message);

            foreach (var rm in _registeredMessages.Values)
            {
                if (message.GetType() != rm.Type)
                    continue;

                // In case the account was disposed
                if (_disposedValue)
                    return;

                //rm.Action.Invoke(Account, message).ContinueWith(c => c.Exception.InnerException.SendCrashReport(),
                //TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
                rm.Action.Invoke(Account, message);
            }
        }

        private async void WebSocket_Closed(PrimusWebSocket ws)
        {
            Connected = false;
            Disconnected?.Invoke(this);

            try
            {
                if (Phase == NetworkPhases.SWITCHING_TO_GAME && _access != null && Account != null)
                {
                    // Connecting to the game server
                    await _webSocket.OpenAsync(_access, Account.AccountConfig.Proxy.Url, Account.AccountConfig.Proxy.Username, Account.AccountConfig.Proxy.Password);
                    Account.State = AccountStates.CONNECTING;
                }
                else
                {
                    Phase = NetworkPhases.NONE;
                }
            }
            catch { }
        }

        private async void WebSocket_Opened(PrimusWebSocket ws)
        {
            Connected = true;

            // Connecting to the login server
            if (Phase == NetworkPhases.NONE)
            {
                var cm = new ConnectingMessage(DTConstants.AppVersion, DTConstants.BuildVersion, GlobalConfiguration.Instance.Lang, "login", "android");
                await SendCallAsync(cm).ConfigureAwait(false);
            }
            else if (Phase == NetworkPhases.SWITCHING_TO_GAME)
            {
                // Since there is already a ConnectMessage class, i had to write this manually
                dynamic msg = new ExpandoObject();
                msg.call = "connecting";
                msg.data = new ExpandoObject();
                msg.data.appVersion = DTConstants.AppVersion;
                msg.data.buildVersion = DTConstants.BuildVersion;
                msg.data.client = "android";
                msg.data.language = GlobalConfiguration.Instance.Lang;
                msg.data.server = new ExpandoObject();
                msg.data.server.address = _serverAddress;
                msg.data.server.port = _serverPort;
                msg.data.server.id = _serverId;

                string raw = JsonConvert.SerializeObject(msg);
                await SendRawAsync(raw);
            }
        }

        #endregion

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _pingTimer.Dispose();
                    _semaphore.Dispose();
                }

                _phase = NetworkPhases.NONE;
                RemoveEvents();
                Messages.Clear();
                _registeredMessages.Clear();
                _registeredMessages = null;
                Messages = null;
                _webSocket = null;
                _pingTimer = null;
                _semaphore = null;
                _sessionId = null;
                _access = null;
                _serverAddress = null;
                Account = null;

                _disposedValue = true;
            }
        }

        ~NetworkManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}