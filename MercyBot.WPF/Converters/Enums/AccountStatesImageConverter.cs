using MercyBot.Core.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MercyBot.Converters.Enums
{
    public class AccountStatesImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = "green";

            switch ((AccountStates)value)
            {
                case AccountStates.DISCONNECTED:
                    color = "red";
                    break;
                case AccountStates.CONNECTING:
                    color = "orange";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Resources/circle_{color}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
