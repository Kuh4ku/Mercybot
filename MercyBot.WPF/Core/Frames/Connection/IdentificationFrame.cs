using System;
using MercyBot.Core.Accounts;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Utility.DofusTouch;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Connection
{
    public static class IdentificationFrame
    {

        public static Task HandleHelloConnectMessage(Account account, HelloConnectMessage message)
            => Task.Run(async () =>
            {
                account.Network.Phase = Enums.NetworkPhases.LOGIN;
                account.Logger.LogDebug("IdentificationFrame", LanguageManager.Translate("81"));
                account.FramesData.Key = message.Key.Select(f => (sbyte)f).ToList();
                account.FramesData.Salt = message.Salt;

                await account.Network.SendCallAsync(new CheckAssetsVersionMessage(DTConstants.AssetsVersion, DTConstants.StaticDataVersion));
            });

        public static Task HandleAssetsVersionCheckedMessage(Account account, AssetsVersionCheckedMessage message)
            => Task.Run(async () => await account.Network.SendCallAsync(new LoginMessage(account.FramesData.Salt, account.AccountConfig.Username, account.Token, account.FramesData.Key)));

        public static Task HandleConnectionFailedMessage(Account account, ConnectionFailedMessage message)
            => Task.Run(() => account.Logger.LogError("IdentificationFrame", LanguageManager.Translate("82", message.Reason)));

        public static Task HandleIdentificationSuccessMessage(Account account, IdentificationSuccessMessage message)
            => Task.Run(() =>
            {
                account.Login = message.Login;
                account.SubscriptionEndDate = message.SubscriptionEndDate == 0 ? 
                                              null : 
                                              (DateTime?)DateTime.Now.AddDays(Math.Floor((message.SubscriptionEndDate - DateTimeOffset.Now.ToUnixTimeMilliseconds()) / 1000 / 60 / 60 / 24));

                var log = $"{LanguageManager.Translate("83")}{(message.WasAlreadyConnected ? LanguageManager.Translate("84") : ".")}";
                account.Logger.LogInfo("IdentificationFrame", log);
            });

        public static Task HandleIdentificationFailedMessage(Account account, IdentificationFailedMessage message)
            => Task.Run(() =>
            {
                IdentificationFailureReasonEnum reason = (IdentificationFailureReasonEnum)message.Reason;
                account.Logger.LogError("IdentificationFrame", LanguageManager.Translate("86", reason));
            });

        public static Task HandleIdentificationFailedBannedMessage(Account account, IdentificationFailedBannedMessage message)
            => Task.Run(() =>
            {
                DateTime until = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(message.BanEndDate);
                account.Logger.LogError("IdentificationFrame", $"{(IdentificationFailureReasonEnum)message.Reason} [{until.ToShortDateString()} {until.ToShortTimeString()}]");
            });

    }
}
