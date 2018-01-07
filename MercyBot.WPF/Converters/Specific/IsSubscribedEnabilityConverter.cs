using System;
using System.Globalization;
using System.Windows.Data;

namespace MercyBot.Converters.Specific
{
    public class IsSubscribedEnabilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MercyBotMain.Instance.Server.IsSubscribedToTouch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
