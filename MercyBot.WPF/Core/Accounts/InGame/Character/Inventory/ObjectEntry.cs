using MercyBot.Protocol.Types;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Data;
using MercyBot.Utility.DofusTouch;

namespace MercyBot.Core.Accounts.InGame.Character.Inventory
{
    public class ObjectEntry
    {

        // Properties
        public uint GID { get; private set; }
        public uint UID { get; private set; }
        public uint Quantity { get; private set; }
        public CharacterInventoryPositionEnum Position { get; private set; }
        public ObjectTypes Type { get; }
        public string Name { get; }
        public int IconId { get; }
        public bool Usable { get; }
        public bool Exchangeable { get; }
        public int Range { get; }
        public bool IsFishingRod { get; }
        public int RealWeight { get; }
        public int TypeId { get; }
        public int SuperTypeId { get; }
        public uint RegenValue { get; }
        public uint WeightBoost { get; }

        public string IconUrl => $"https://ankama.akamaized.net/games/dofus-tablette/assets/{DTConstants.AssetsVersion}/gfx/items/{IconId}.png";


        // Constructor
        public ObjectEntry(ObjectItem o, Items item = null)
        {
            GID = o.ObjectGID;
            UID = o.ObjectUID;
            Quantity = o.Quantity;
            Position = (CharacterInventoryPositionEnum)o.Position;

            if (item == null)
                item = DataManager.Get<Items>((int)GID);

            var type = DataManager.Get<ItemTypes>(item.TypeId);
            Name = item.NameId;
            IconId = item.IconId;
            Usable = item.Usable;
            Exchangeable = item.Exchangeable;
            Range = item.Range;
            IsFishingRod = item.TypeId == 20 && item.UseAnimationId == 18;
            RealWeight = item.RealWeight;
            TypeId = item.TypeId;
            SuperTypeId = type.SuperTypeId;
            Type = InventoryHelper.GetObjectType(SuperTypeId);

            // Check if this item gives hp back (BOOST_HP 110)
            for (int i = 0; i < o.Effects.Count; i++)
            {
                if (!(o.Effects[i] is ObjectEffectInteger oei))
                    continue;

                if (oei.ActionId == 110)
                {
                    RegenValue = oei.Value;
                }
                else if (oei.ActionId == 158)
                {
                    WeightBoost = oei.Value;
                }
            }
        }


        #region Updates

        public void Update(ObjectItem o)
        {
            GID = o.ObjectGID;
            UID = o.ObjectUID;
            Quantity = o.Quantity;
            Position = (CharacterInventoryPositionEnum)o.Position;
        }

        public void UpdateQuantity(uint qty)
        {
            Quantity = qty;
        }

        public void Update(ObjectMovementMessage message)
        {
            Position = (CharacterInventoryPositionEnum)message.Position;
        }

        #endregion

    }
}
