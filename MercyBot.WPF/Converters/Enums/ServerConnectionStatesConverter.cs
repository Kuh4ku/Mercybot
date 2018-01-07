using MercyBot.Server;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MercyBot.Converters.Enums
{
    public class ServerConnectionStatesConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = "red";

            switch ((ServerConnectionStates)value)
            {
                case ServerConnectionStates.CONNECTED:
                    color = "green";
                    break;
                case ServerConnectionStates.CONNECTING:
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
