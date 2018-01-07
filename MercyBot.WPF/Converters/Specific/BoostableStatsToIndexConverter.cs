using MercyBot.Core.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MercyBot.Converters.Specific
{
    public class BoostableStatsToIndexConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)(BoostableStats)value) - 9;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (BoostableStats)((int)value + 9);
        }

    }
}
