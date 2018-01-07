using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Enums;

namespace MercyBot.Core.Extensions
{
    public static class ToFriendlyStringExtensions
    {

        public static string ToFriendlyString(this AccountStates state)
        {
            switch (state)
            {
                case AccountStates.CONNECTING:
                    return LanguageManager.Translate("12");                case AccountStates.DISCONNECTED:
                    return LanguageManager.Translate("13");                case AccountStates.EXCHANGE:
                    return LanguageManager.Translate("117");                case AccountStates.FIGHTING:
                    return LanguageManager.Translate("216");                case AccountStates.GATHERING:
                    return LanguageManager.Translate("133");                case AccountStates.MOVING:
                    return LanguageManager.Translate("15");                case AccountStates.NONE:
                    return LanguageManager.Translate("215");                case AccountStates.STORAGE:
                    return LanguageManager.Translate("16");                case AccountStates.TALKING:
                    return LanguageManager.Translate("17");                case AccountStates.BUYING:
                    return LanguageManager.Translate("18");                case AccountStates.SELLING:
                    return LanguageManager.Translate("19");                case AccountStates.REGENERATING:
                    return LanguageManager.Translate("23");                case AccountStates.RECAPTCHA:
                    return "reCaptcha";
                default:
                    return "-";
            }
        }

        public static string ToFriendlyString(this ChatActivableChannelsEnum channel)
        {
            switch (channel)
            {
                case ChatActivableChannelsEnum.CHANNEL_ADMIN:
                    return LanguageManager.Translate("217");                case ChatActivableChannelsEnum.CHANNEL_ALLIANCE:
                    return LanguageManager.Translate("218");                case ChatActivableChannelsEnum.CHANNEL_ARENA:
                    return LanguageManager.Translate("219");                case ChatActivableChannelsEnum.CHANNEL_GUILD:
                    return LanguageManager.Translate("220");                case ChatActivableChannelsEnum.CHANNEL_NOOB:
                    return LanguageManager.Translate("221");                case ChatActivableChannelsEnum.CHANNEL_PARTY:
                    return LanguageManager.Translate("222");                case ChatActivableChannelsEnum.CHANNEL_SALES:
                    return LanguageManager.Translate("223");                case ChatActivableChannelsEnum.CHANNEL_SEEK:
                    return LanguageManager.Translate("224");                case ChatActivableChannelsEnum.CHANNEL_TEAM:
                    return LanguageManager.Translate("225");                default: // Including GLOBAL
                    return "";
            }
        }

        public static string ToFriendlyString(this BoostableStats stat)
        {
            switch (stat)
            {
                case BoostableStats.AGILITY:
                    return LanguageManager.Translate("226");                case BoostableStats.CHANCE:
                    return LanguageManager.Translate("227");                case BoostableStats.INTELLIGENCE:
                    return LanguageManager.Translate("228");                case BoostableStats.STRENTH:
                    return LanguageManager.Translate("229");                case BoostableStats.VITALITY:
                    return LanguageManager.Translate("230");                case BoostableStats.WISDOM:
                    return LanguageManager.Translate("231");                default:
                    return "-";
            }
        }

    }
}
