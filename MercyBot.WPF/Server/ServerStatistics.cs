using GalaSoft.MvvmLight;
using MercyBot.Server.Messages;

namespace MercyBot.Server
{
    public class ServerStatistics : ViewModelBase
    {

        // Fields
        private int _accountsConnected;
        private int _botsConnected;


        // Properties
        public int AccountsConnected
        {
            get => _accountsConnected;
            set => Set(ref _accountsConnected, value);
        }
        public int BotsConnected
        {
            get => _botsConnected;
            set => Set(ref _botsConnected, value);
        }


        // Constructor
        public ServerStatistics(ServerManager serverManager)
        {
            serverManager.RegisterMessage<ServerStatisticsMessage>(HandleServerStatisticsMessage);
        }


        private void HandleServerStatisticsMessage(ServerStatisticsMessage message)
        {
            AccountsConnected = message.AccountsCount;
            BotsConnected = message.BotsCount;
        }

    }
}
