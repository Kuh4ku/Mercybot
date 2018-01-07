using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Specific
{
    public class SubscriptionTextConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (MercyBotMain.Instance.Server.IsSubscribedToTouch)
            {
                // If the user is currently in a plan
                return MercyBotMain.Instance.Server.TouchEndDate == null ? 
                    LanguageManager.Translate("415") : 
                    LanguageManager.Translate("416", MercyBotMain.Instance.Server.TouchEndDate.Value.ToString("G"));
            }

            return LanguageManager.Translate("417");        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
