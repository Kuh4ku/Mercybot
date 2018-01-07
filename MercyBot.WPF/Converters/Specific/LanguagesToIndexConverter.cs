using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Specific
{
    public class LanguagesToIndexConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (byte)((Languages)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Languages)value;
        }

    }
}
