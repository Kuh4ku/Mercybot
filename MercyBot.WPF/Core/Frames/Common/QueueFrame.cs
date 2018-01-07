using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Common
{
    public static class QueueFrame
    {

        public static Task HandleQueueStatusMessage(Account account, QueueStatusMessage message)
            => Task.Run(() =>
            {
                account.Logger.LogDofus(LanguageManager.Translate("69"), LanguageManager.Translate("70", message.Position, message.Total));
            });

        public static Task HandleLoginQueueStatusMessage(Account account, LoginQueueStatusMessage message)
            => Task.Run(() =>
            {
                account.Logger.LogDofus(LanguageManager.Translate("69"), LanguageManager.Translate("70", message.Position, message.Total));
            });

    }
}
