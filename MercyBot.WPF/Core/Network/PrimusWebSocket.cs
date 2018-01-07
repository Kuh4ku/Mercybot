using System;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using WebSocketSharp;

namespace MercyBot.Core.Network
{
    public class PrimusWebSocket : IDisposable
    {

        // Properties
        public Uri Url { get; private set; }
        public bool Connected { get; private set; }
        public string Sid { get; private set; }


        // Fields
        private WebSocket _webSocket;
        private Timer _pingTimer;
        private ConcurrentQueue<JObject> _messagesQueue;
        private bool _waitingToBeClosed;


        // Events
        public event Action<PrimusWebSocket, Exception> ErrorOccured;
        public event Action<PrimusWebSocket, JObject> MessageReceived;
        public event Action<PrimusWebSocket> Opened;
        public event Action<PrimusWebSocket> Closed;


        // Constructors
        public PrimusWebSocket()
        {
            _messagesQueue = new ConcurrentQueue<JObject>();
            _pingTimer = new Timer(PingTimerCallback, null, Timeout.Infinite, Timeout.Infinite);
            _waitingToBeClosed = false;
        }


        public async Task OpenAsync(string url, string proxyUrl = null, string proxyUsername = null, string proxyPassword = null)
        {
            if (_webSocket != null)
                RemoveEvents();

            try
            {
                InitializeWebsocket(url, proxyUrl, proxyUsername, proxyPassword);
            }
            catch (Exception e)
            {
                ErrorOccured?.Invoke(this, e);
            }

            await OpenAsync().ConfigureAwait(false);
        }

        public Task OpenAsync()
            => Task.Run(() =>
            {
                try
                {
                    _webSocket.Connect();
                }
                catch (Exception e)
                {
                    ErrorOccured?.Invoke(this, e);
                }
            });

        private async Task ProcessMessages()
        {
            try
            {
                while (Connected || _messagesQueue.Count > 0)
                {
                    if (_messagesQueue.Count > 0)
                    {
                        if (_messagesQueue.TryDequeue(out JObject obj))
                        {
                            MessageReceived?.Invoke(this, obj);
                        }
                    }
                    else if (_waitingToBeClosed)
                    {
                        _waitingToBeClosed = false;
                        Connected = false;
                    }

                    // Friendly Infinite Loop
                    await Task.Delay(10);
                }
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(this, ex);
            }

            Closed?.Invoke(this);
        }

        public Task CloseAsync(string reason)
            => Task.Run(() =>
            {
                try
                {
                    _webSocket.Close(CloseStatusCode.Normal, reason);
                }
                catch (Exception e)
                {
                    ErrorOccured?.Invoke(this, e);
                }
            });

        public Task SendAsync(string data)
            => Task.Run(() =>
            {
                try
                {
                    data = $"4{data}";
                    _webSocket.Send(data);
                }
                catch (Exception e)
                {
                    ErrorOccured?.Invoke(this, e);
                }
            });

        private void RemoveEvents()
        {
            _webSocket.OnOpen -= WebSocket_Opened;
            _webSocket.OnMessage -= WebSocket_MessageReceived;
            _webSocket.OnClose -= WebSocket_Closed;
            _webSocket.OnError -= WebSocket_ErrorOccured;
        }

        private void InitializeWebsocket(string url, string proxyUrl, string proxyUsername, string proxyPassword)
        {
            Url = new Uri(url);
            _webSocket = new WebSocket(Url.AbsoluteUri);
            
            // Set proxy if needed
            if (proxyUrl?.Length > 0)
            {
                _webSocket.SetProxy(proxyUrl, proxyUsername ?? "", proxyPassword ?? "");
            }

            _waitingToBeClosed = false;

            _webSocket.OnOpen += WebSocket_Opened;
            _webSocket.OnMessage += WebSocket_MessageReceived;
            _webSocket.OnClose += WebSocket_Closed;
            _webSocket.OnError += WebSocket_ErrorOccured;
        }

        private async void PingTimerCallback(object state)
        {
            if (!Connected)
                return;

            var ticks = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            await SendAsync($"\"primus::ping::{ticks}\"").ConfigureAwait(false);
        }

        private void WebSocket_ErrorOccured(object sender, ErrorEventArgs e)
        {
            ErrorOccured?.Invoke(this, e.Exception);
        }

        private void WebSocket_MessageReceived(object sender, MessageEventArgs e)
        {
            // Useless message (or not?)
            if (e.Data.Length == 0 || e.Data == "3")
                return;

            // If its a primus response
            if (e.Data.Contains("\"primus::"))
                return;

            if (e.Data[0] != '0' && e.Data[0] != '4')
                return;

            try
            {
                var msg = e.Data.Substring(1);
                var obj = JObject.Parse(msg);

                // Handle ping
                if (e.Data[0] == '0' && obj["pingInterval"] != null)
                {
                    Sid = obj["sid"].ToString();
                    var interval = obj.Value<int>("pingInterval");
                    _pingTimer.Change(interval, interval);
                    return;
                }

                _messagesQueue.Enqueue(obj);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(this, ex);
            }
        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {
            _waitingToBeClosed = true;
            _pingTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        
        private void WebSocket_Opened(object sender, EventArgs e)
        {
            _webSocket.Send("2probe");
            Connected = true;

            Task.Factory.StartNew(ProcessMessages, TaskCreationOptions.LongRunning);

            Opened?.Invoke(this);
        }

        public void Dispose()
        {
            _pingTimer.Change(Timeout.Infinite, Timeout.Infinite);

            //webSocket.Dispose(); TODO: Implement this
            _pingTimer.Dispose();

            Url = null;
            Connected = false;
            Sid = null;
            _webSocket = null;
            _pingTimer = null;
        }

    }
}