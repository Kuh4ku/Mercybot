using MercyBot.Core.Accounts;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Game
{
    public static class AchievementsFrame
    {

        public static Task HandleAchievementRewardSuccessMessage(Account account, AchievementRewardSuccessMessage message)
            => Task.Run(() =>
            {
                account.Statistics.Update(message);

                var achievement = DataManager.Get<Achievements>(message.AchievementId);
                account.Logger.LogInfo("", LanguageManager.Translate("92", achievement.NameId, achievement.Points));
            });

        public static Task HandleAchievementFinishedMessage(Account account, AchievementFinishedMessage message)
            => Task.Run(async () =>
            {
                if (!account.Configuration.AcceptAchievements)
                    return;

                await account.Network.SendMessageAsync(new AchievementRewardRequestMessage((int)message.Id));
            });

        public static Task HandleAchievementListMessage(Account account, AchievementListMessage message)
            => Task.Run(async () =>
            {
                if (!account.Configuration.AcceptAchievements)
                    return;

                foreach (var achiv in message.RewardableAchievements)
                {
                    await account.Network.SendMessageAsync(new AchievementRewardRequestMessage((int)achiv.Id));
                }
            });

    }
}
