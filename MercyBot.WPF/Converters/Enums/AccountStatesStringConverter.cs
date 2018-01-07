using MercyBot.Core.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Enums
{
    public class AccountStatesStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((AccountStates)value)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
