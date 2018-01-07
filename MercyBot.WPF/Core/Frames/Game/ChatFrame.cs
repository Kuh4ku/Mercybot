using MercyBot.Core.Accounts;
using MercyBot.Core.Enums;
using MercyBot.Core.Extensions;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Game
{
    public static class ChatFrame
    {

        public static Task HandleObjectErrorMessage(Account account, ObjectErrorMessage message)
           => Task.Run(() => account.Logger.LogError("", LanguageManager.Translate("96", (ObjectErrorEnum)message.Reason)));

        public static Task HandleChatServerWithObjectMessage(Account account, ChatServerWithObjectMessage message)
            => HandleChatServerMessage(account, message);

        public static Task HandleChatErrorMessage(Account account, ChatErrorMessage message)
            => Task.Run(() =>
            {
                if (byte.TryParse(message.Reason, out byte reason))
                {
                    account.Logger.LogError("ChatFrame", ((ChatErrorEnum)reason).ToString());
                }
                else
                {
                    account.Logger.LogError("ChatFrame", message.Reason);
                }
            });

        public static Task HandleTextInformationMessage(Account account, TextInformationMessage message)
            => Task.Run(() =>
            {
                string text = message.Text;
                for (int i = 0; i < message.Parameters.Count; i++)
                {
                    text = text.Replace("$%{i}", message.Parameters[i]);
                }

                switch ((TextInformationTypeEnum)message.MsgType)
                {
                    case TextInformationTypeEnum.TEXT_INFORMATION_ERROR:
                        account.Logger.LogError("", text);
                        break;
                    case TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE:
                        account.Logger.LogInfo("", text);
                        break;
                    default:
                        account.Logger.LogDofus("", text);
                        break;
                }
            });

        public static Task HandleChatServerMessage(Account account, ChatServerMessage message)
            => Task.Run(() =>
            {
                if (!IsChannelEnabled(account, (ChatActivableChannelsEnum)message.Channel))
                    return;

                var channel = (ChatActivableChannelsEnum)message.Channel;
                switch ((ChatActivableChannelsEnum)message.Channel)
                {
                    case ChatActivableChannelsEnum.CHANNEL_ADMIN:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.ADMIN).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_ALLIANCE:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.ALLIANCE).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_GLOBAL:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.GLOBAL).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_GUILD:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.GUILD).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_PARTY:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.PARTY).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_SALES:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.SALES).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_SEEK:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.SEEK).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_NOOB:
                        account.Logger.Log(channel.ToFriendlyString(), $"{message.SenderName}: {message.Content}", ((int)ChannelColors.NOOB).ToString("X6"));
                        break;
                    case ChatActivableChannelsEnum.PSEUDO_CHANNEL_PRIVATE:
                        account.Logger.Log($"de {message.SenderName}", message.Content, ((int)ChannelColors.PRIVATE).ToString("X"));
                        break;
                    case ChatActivableChannelsEnum.CHANNEL_ADS:
                        account.Logger.Log(message.SenderName, message.Content, ((int)ChannelColors.ADS).ToString("X6"));
                        break;
                }
            });

        public static Task HandleChatServerCopyMessage(Account account, ChatServerCopyMessage message)
            => Task.Run(() =>
            {
                if (((ChatActivableChannelsEnum)message.Channel) == ChatActivableChannelsEnum.PSEUDO_CHANNEL_PRIVATE)
                {
                    account.Logger.Log($"à {message.ReceiverName}", message.Content, ((int)ChannelColors.PRIVATE).ToString("X6"));
                }
            });

        private static bool IsChannelEnabled(Account account, ChatActivableChannelsEnum channel)
        {
            switch (channel)
            {
                case ChatActivableChannelsEnum.CHANNEL_GLOBAL:
                    return account.Configuration.ShowGeneralMessages;
                case ChatActivableChannelsEnum.CHANNEL_GUILD:
                    return account.Configuration.ShowGuildMessages;
                case ChatActivableChannelsEnum.CHANNEL_ALLIANCE:
                    return account.Configuration.ShowAllianceMessages;
                case ChatActivableChannelsEnum.CHANNEL_NOOB:
                    return account.Configuration.ShowNoobMessages;
                case ChatActivableChannelsEnum.CHANNEL_PARTY:
                    return account.Configuration.ShowPartyMessages;
                case ChatActivableChannelsEnum.CHANNEL_SEEK:
                    return account.Configuration.ShowSeekMessages;
                case ChatActivableChannelsEnum.CHANNEL_SALES:
                    return account.Configuration.ShowSaleMessages;
                default:
                    return true;
            }
        }

    }
}
