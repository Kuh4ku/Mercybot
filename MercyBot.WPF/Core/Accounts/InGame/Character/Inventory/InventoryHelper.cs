using MercyBot.Protocol.Enums;
using System.Collections.Generic;

namespace MercyBot.Core.Accounts.InGame.Character.Inventory
{
    public static class InventoryHelper
    {

        // Fields
        private static List<int> _equippableSuperTypeIds = new List<int>()
        {
            1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 22, 23
        };
        private static Dictionary<int, List<CharacterInventoryPositionEnum>> _possiblePositions = new Dictionary<int, List<CharacterInventoryPositionEnum>>
        {
            { 1,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_AMULET } },
            { 2,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON } },
            { 3,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_RING_LEFT, CharacterInventoryPositionEnum.INVENTORY_POSITION_RING_RIGHT } },
            { 4,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_BELT } },
            { 5,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_BOOTS } },
            { 7,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_SHIELD } },
            { 8,  new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON } },
            { 10, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_HAT } },
            { 11, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_CAPE } },
            { 12, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.ACCESSORY_POSITION_PETS } },
            { 13, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_1, CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_2, CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_3, CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_4, CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_5, CharacterInventoryPositionEnum.INVENTORY_POSITION_DOFUS_6 } },
            { 15, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_MUTATION } },
            { 16, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_BOOST_FOOD } },
            { 17, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_FIRST_BONUS, CharacterInventoryPositionEnum.INVENTORY_POSITION_SECOND_BONUS } },
            { 18, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_FIRST_MALUS, CharacterInventoryPositionEnum.INVENTORY_POSITION_SECOND_MALUS } },
            { 19, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_ROLEPLAY_BUFFER } },
            { 20, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_FOLLOWER } },
            { 21, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_MOUNT } },
            { 23, new List<CharacterInventoryPositionEnum>() { CharacterInventoryPositionEnum.INVENTORY_POSITION_COMPANION } }
        };


        public static ObjectTypes GetObjectType(int superTypeId)
        {
            if (_equippableSuperTypeIds.Contains(superTypeId))
                return ObjectTypes.EQUIPEMENT;

            switch (superTypeId)
            {
                case 6:
                    return ObjectTypes.CONSUMABLE;
                case 9:
                    return ObjectTypes.RESSOURCES;
                case 14:
                    return ObjectTypes.QUEST_OBJECT;
                default:
                    return ObjectTypes.UNKOWN;
            }
        }

        public static List<CharacterInventoryPositionEnum> GetPossiblePosition(int superTypeId)
            => _possiblePositions.ContainsKey(superTypeId) ? _possiblePositions[superTypeId] : null;

    }

    public enum ObjectTypes
    {
        EQUIPEMENT,
        RESSOURCES,
        CONSUMABLE,
        QUEST_OBJECT,
        UNKOWN
    }

}
