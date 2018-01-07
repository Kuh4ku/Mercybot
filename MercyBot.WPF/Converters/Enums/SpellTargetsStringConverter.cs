using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Enums
{
    public class SpellTargetsStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((SpellTargets)value)
            {
                case SpellTargets.ALLY:
                    return LanguageManager.Translate("203");
                case SpellTargets.ENNEMY:
                    return LanguageManager.Translate("204");
                case SpellTargets.EMPTY_CELL:
                    return LanguageManager.Translate("26");
                default:
                    return LanguageManager.Translate("27");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
