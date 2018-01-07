using MercyBot.Core.Accounts;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Connection
{
    public static  class ServerSelectionFrame
    {

        public static Task HandleServersListMessage(Account account, ServersListMessage message)
            => Task.Run(async () =>
            {
                var server = account.AccountConfig.CharacterCreation.Create ?
                             message.Servers.FirstOrDefault(s => s.Name == account.AccountConfig.CharacterCreation.Server) :
                             account.AccountConfig.Server == "-" ? message.Servers.FirstOrDefault(s => s.CharactersCount > 0) : message.Servers.FirstOrDefault(s => s.Name == account.AccountConfig.Server);

                if (server == null || server.CharactersCount == 0 && !account.AccountConfig.CharacterCreation.Create)
                {
                    account.Logger.LogError(LanguageManager.Translate("87"), LanguageManager.Translate("88", account.AccountConfig.Server));
                    return;
                }

                var status = (ServerStatusEnum)server.Status;
                if (status != ServerStatusEnum.ONLINE && status != ServerStatusEnum.SAVING && !server.IsSelectable)
                {
                    account.Logger.LogError(LanguageManager.Translate("87"), LanguageManager.Translate("89", server.Name, status));
                    return;
                }

                if (status == ServerStatusEnum.SAVING)
                {
                    account.FramesData.ServerToAutoConnectTo = server.Id;
                    account.Logger.LogInfo(LanguageManager.Translate("87"), LanguageManager.Translate("573", server.Name));
                }
                else // ONLINE
                {
                    account.Logger.LogDebug(LanguageManager.Translate("87"), LanguageManager.Translate("90", server.Name));
                    await account.Network.SendMessageAsync(new ServerSelectionMessage((int)server.Id));
                }
            });

        public static Task HandleServerStatusUpdateMessage(Account account, ServerStatusUpdateMessage message)
            => Task.Run(async () =>
            {
                
                if (account.FramesData.ServerToAutoConnectTo != 0 && message.Server.Id == account.FramesData.ServerToAutoConnectTo && (ServerStatusEnum)message.Server.Status == ServerStatusEnum.ONLINE)
                {
                    await Task.Delay(2000);
                    account.Logger.LogDebug(LanguageManager.Translate("87"), LanguageManager.Translate("90", message.Server.Name));
                    await account.Network.SendMessageAsync(new ServerSelectionMessage((int)message.Server.Id));
                }

            });

        public static Task HandleSelectedServerDataMessage(Account account, SelectedServerDataMessage message)
            => Task.Run(async () =>
            {
                account.Game.Server.Update(message);

                account.FramesData.Ticket = message.Ticket;
                await account.Network.SwitchToGameServer(message.Address, message.Port, message.ServerId, message.Access);
            });

        public static Task HandleHelloGameMessage(Account account, HelloGameMessage message)
            => Task.Run(async () =>
            {
                account.Logger.LogInfo(LanguageManager.Translate("87"), LanguageManager.Translate("91"));
                await account.Network.SendMessageAsync(new AuthenticationTicketMessage(GlobalConfiguration.Instance.Lang, account.FramesData.Ticket));
                account.Network.Phase = Enums.NetworkPhases.GAME;
            });

        public static Task HandleTrustStatusMessage(Account account, TrustStatusMessage message)
            => Task.Run(async () => await account.Network.SendMessageAsync(new CharactersListRequestMessage()));

    }
}
