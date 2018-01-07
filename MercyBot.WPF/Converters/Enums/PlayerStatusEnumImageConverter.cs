using MercyBot.Protocol.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MercyBot.Converters.Enums
{
    public class PlayerStatusEnumImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string image = "circle_green";

            switch ((PlayerStatusEnum)value)
            {
                case PlayerStatusEnum.PLAYER_STATUS_AFK:
                    image = "Clock-24";
                    break;
                case PlayerStatusEnum.PLAYER_STATUS_PRIVATE:
                    image = "No-entry24";
                    break;
                case PlayerStatusEnum.PLAYER_STATUS_SOLO:
                    image = "circle-cross-24";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Resources/{image}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
