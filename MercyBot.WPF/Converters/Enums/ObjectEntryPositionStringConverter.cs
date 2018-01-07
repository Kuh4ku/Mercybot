using MercyBot.Protocol.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using MercyBot.Configurations.Language;

namespace MercyBot.Converters.Enums
{
    public class ObjectEntryPositionStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((CharacterInventoryPositionEnum)value)
            {
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_AMULET:
                    return LanguageManager.Translate("207");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_BELT:
                    return LanguageManager.Translate("208");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_BOOTS:
                    return LanguageManager.Translate("209");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_CAPE:
                    return LanguageManager.Translate("210");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_HAT:
                    return LanguageManager.Translate("20");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_PETS:
                    return LanguageManager.Translate("21");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_SHIELD:
                    return LanguageManager.Translate("22");
                case CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON:
                    return LanguageManager.Translate("211");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_1:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_2:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_3:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_4:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_5:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_6:
                    return LanguageManager.Translate("69");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_MOUNT:
                    return LanguageManager.Translate("212");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_RING_LEFT:
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_RING_RIGHT:
                    return LanguageManager.Translate("213");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_FOLLOWER:
                    return LanguageManager.Translate("214");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_COMPANION:
                    return LanguageManager.Translate("24");
                case CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED:
                    return LanguageManager.Translate("25");
                default:
                    return "-";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}