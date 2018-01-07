using System.Diagnostics;
using System.Linq;
using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Game
{
    public static class CharacterFrame
    {

        public static Task HandleEmotePlayMessage(Account account, EmotePlayMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleCharacterExperienceGainMessage(Account account, CharacterExperienceGainMessage message)
            => Task.Run(() =>
            {
                account.Statistics.Update(message);

                account.Logger.LogInfo("", LanguageManager.Translate("93", message.ExperienceCharacter));
                account.Game.Character.Stats.Update(message);
            });

        public static Task HandleCharacterStatsListMessage(Account account, CharacterStatsListMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleCharacterLevelUpMessage(Account account, CharacterLevelUpMessage message)
            => Task.Run(() =>
            {
                account.Statistics.Update(message);

                account.Logger.LogInfo("", "Level up!");
                account.Game.Character.Update(message);
            });

        public static Task HandleUpdateLifePointsMessage(Account account, UpdateLifePointsMessage message)
            => Task.Run(() => account.Game.Character.Stats.Update(message));

        public static Task HandleGameRolePlayPlayerLifeStatusMessage(Account account, GameRolePlayPlayerLifeStatusMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandlePlayerStatusUpdateMessage(Account account, PlayerStatusUpdateMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleLifePointsRegenBeginMessage(Account account, LifePointsRegenBeginMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleLifePointsRegenEndMessage(Account account, LifePointsRegenEndMessage message)
            => Task.Run(() =>
            {
                account.Game.Character.Update(message);

                if (message.LifePointsGained > 0)
                {
                    account.Logger.LogInfo("", LanguageManager.Translate("95", message.LifePointsGained));
                }

                account.Game.Character.Stats.Update(message);
            });

        public static Task HandleSpellListMessage(Account account, SpellListMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleSpellUpgradeSuccessMessage(Account account, SpellUpgradeSuccessMessage message)
            => Task.Run(() => account.Game.Character.Update(message));

        public static Task HandleJobDescriptionMessage(Account account, JobDescriptionMessage message)
            => Task.Run(() => account.Game.Character.Jobs.Update(message));

        public static Task HandleJobExperienceMultiUpdateMessage(Account account, JobExperienceMultiUpdateMessage message)
            => Task.Run(async () => await account.Game.Character.Jobs.Update(message));

        public static Task HandleJobExperienceUpdateMessage(Account account, JobExperienceUpdateMessage message)
            => Task.Run(() => account.Game.Character.Jobs.Update(message));

        public static Task HandleMountXpRatioMessage(Account account, MountXpRatioMessage message)
            => Task.Run(() => account.Game.Character.Mount.Update(message));

        public static Task HandleMountRidingMessage(Account account, MountRidingMessage message)
            => Task.Run(() => account.Game.Character.Mount.Update(message));

        public static Task HandleMountSetMessage(Account account, MountSetMessage message)
            => Task.Run(() => account.Game.Character.Mount.Update(message));

    }
}
