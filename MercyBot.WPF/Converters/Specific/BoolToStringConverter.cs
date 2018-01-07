using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Specific
{
    public class BoolToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? LanguageManager.Translate("205") : LanguageManager.Translate("206");        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}