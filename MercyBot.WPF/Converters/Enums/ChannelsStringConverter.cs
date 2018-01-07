using MercyBot.Protocol.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Enums
{
    public class ChannelsStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ChatActivableChannelsEnum)value)
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
                    return LanguageManager.Translate("225");                case ChatActivableChannelsEnum.PSEUDO_CHANNEL_PRIVATE:
                    return LanguageManager.Translate("475");                default: // Including GLOBAL
                    return LanguageManager.Translate("266");            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
