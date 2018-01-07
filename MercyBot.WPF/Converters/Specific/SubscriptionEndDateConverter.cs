using System;
using System.Globalization;
using System.Windows.Data;

namespace MercyBot.Converters.Specific
{
    public class SubscriptionEndDateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime endDate && endDate > DateTime.Now)
                return endDate.ToShortDateString();

            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
