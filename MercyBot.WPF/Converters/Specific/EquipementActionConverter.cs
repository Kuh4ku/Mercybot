using MercyBot.Core.Accounts.InGame.Character.Inventory;
using MercyBot.Protocol.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Specific
{
    public class EquipementActionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ObjectEntry obj))
                return "-";

            return obj.Position == CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED ? LanguageManager.Translate("29") : LanguageManager.Translate("28");        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
