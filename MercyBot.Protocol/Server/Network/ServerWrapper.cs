using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace MercyBot.Server.Network
{
    public class ServerWrapper
    {

        // Fields
        private readonly TcpListener _tcpListener;


        // Properties
        public bool Listening { get; private set; }
        public List<ClientWrapper> Clients { get; private set; }


        // Events
        public event Action<ClientWrapper> ClientConnected;
        public event Action<ClientWrapper> ClientDisconnected;
        public event Action<Exception> ErrorOccured;


        // Constructor
        public ServerWrapper(IPAddress ipAddress, int port)
        {
            _tcpListener = new TcpListener(ipAddress, port);
            Clients = new List<ClientWrapper>();
        }


        public void Start()
        {
            if (Listening)
                return;

            try
            {
                _tcpListener.Start();
                Listening = true;

                _tcpListener.BeginAcceptSocket(TcpListener_AcceptCallback, _tcpListener);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex);
            }
        }

        public void Stop()
        {
            if (!Listening)
                return;

            try
            {
                _tcpListener.Stop();
                Listening = false;
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex);
            }
        }

        #region Callbacks

        private void TcpListener_AcceptCallback(IAsyncResult ar)
        {
            if (!Listening)
                return;

            try
            {
                var newClient = (ar.AsyncState as TcpListener).EndAcceptSocket(ar);
                var clientWrapper = new ClientWrapper(newClient);

                clientWrapper.Disconnected += Client_Disconnected;

                Clients.Add(clientWrapper);
                clientWrapper.Start();
                ClientConnected?.Invoke(clientWrapper);

                // Re-call BeginAcceptSocket
                _tcpListener.BeginAcceptSocket(TcpListener_AcceptCallback, _tcpListener);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex);
            }
        }

        private void Client_Disconnected(ClientWrapper client)
        {
            try
            {
                var clientHandler = Clients.FirstOrDefault(c => c == client);

                if (clientHandler != null)
                {
                    Clients.Remove(clientHandler);
                    ClientDisconnected?.Invoke(clientHandler);

                    clientHandler.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex);
            }
        }

        #endregion

    }
}
