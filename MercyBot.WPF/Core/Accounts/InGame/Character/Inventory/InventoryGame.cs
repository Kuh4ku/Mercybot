using GalaSoft.MvvmLight;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.InGame.Character.Inventory
{
    public class InventoryGame : ViewModelBase, IDisposable
    {

        // Fields
        private Account _account;
        private ConcurrentDictionary<uint, ObjectEntry> _objects;
        private int _kamas;
        private short _weight;
        private short _maxWeight;
        private short _fallbackMaxWeight;


        // Properties
        public int Kamas
        {
            get => _kamas;
            set => Set(ref _kamas, value);
        }
        public short Weight
        {
            get => _weight;
            set
            {
                Set(ref _weight, value);
                RaisePropertyChanged("WeightPercent");
            }
        }
        public short MaxWeight
        {
            get => _maxWeight;
            set
            {
                Set(ref _maxWeight, value);
                RaisePropertyChanged("WeightPercent");
            }
        }

        public IEnumerable<ObjectEntry> Objects => _objects.Values;
        public IEnumerable<ObjectEntry> Equipements => Objects.Where(o => o.Type == ObjectTypes.EQUIPEMENT);
        public IEnumerable<ObjectEntry> Consumables => Objects.Where(o => o.Type == ObjectTypes.CONSUMABLE);
        public IEnumerable<ObjectEntry> Resources => Objects.Where(o => o.Type == ObjectTypes.RESSOURCES);
        public IEnumerable<ObjectEntry> QuestObjects => Objects.Where(o => o.Type == ObjectTypes.QUEST_OBJECT);
        public int WeightPercent => MaxWeight == 0 ? 0 : (int)(((double)Weight / MaxWeight) * 100);
        public bool HasFishingRod => Objects.FirstOrDefault(o => o.Position == CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON && o.IsFishingRod) != null;

        // Events
        public event Action<bool> InventoryUpdated;
        public event Action<uint> ObjectGained;
        public event Action<uint> ObjectEquipped;


        // Constructor
        internal InventoryGame(Account account)
        {
            _account = account;
            _objects = new ConcurrentDictionary<uint, ObjectEntry>();
        }


        public int GetWeaponRange()
            => GetObjectInPosition(CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON)?.Range ?? 0;

        public ObjectEntry GetObjectByUID(int uid)
            => Objects.FirstOrDefault(f => f.UID == uid);

        public ObjectEntry GetObjectByGID(int gid)
            => Objects.FirstOrDefault(f => f.GID == gid);

        public ObjectEntry GetObjectInPosition(CharacterInventoryPositionEnum position)
            => Objects.FirstOrDefault(o => o.Position == position);

        public IEnumerable<ObjectEntry> GetObjectsByGID(int gid)
            => Objects.Where(f => f.GID == gid);

        public bool EquipObject(ObjectEntry obj)
        {
            if (obj?.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                return false;

            var possiblePositions = InventoryHelper.GetPossiblePosition(obj.SuperTypeId);

            // In case its not equippable
            if (possiblePositions?.Count == 0)
                return false;

            // Check if a possible position is empty
            for (int i = 0; i < possiblePositions.Count; i++)
            {
                if (GetObjectInPosition(possiblePositions[i]) == null)
                {
                    _account.Network.SendMessage(new ObjectSetPositionMessage(obj.UID, (uint)possiblePositions[i], 1));
                    _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("109", obj.Name));
                    return true;
                }
            }

            // If we didn't find an empty place, just equip it in the first possible position
            _account.Network.SendMessage(new ObjectSetPositionMessage(obj.UID, (uint)possiblePositions[0], 1));
            _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("109", obj.Name));
            return true;
        }

        public bool UnEquipObject(ObjectEntry obj)
        {
            if (obj == null)
                return false;

            if (obj.Position == CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                return false;

            _account.Network.SendMessage(new ObjectSetPositionMessage(obj.UID, 63, 1));
            _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("110", obj.Name));
            return true;
        }

        public void UseObject(ObjectEntry obj, uint qty = 1)
        {
            if (obj == null)
                return;

            if (qty == 1)
            {
                _account.Network.SendMessage(new ObjectUseMessage(obj.UID));
            }
            else
            {
                qty = qty == 0 ?
                      obj.Quantity :
                      qty > obj.Quantity ? obj.Quantity : qty;

                _account.Network.SendMessage(new ObjectUseMultipleMessage(obj.UID, qty));
            }

            _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("111", qty, obj.Name));
        }

        public void DropObject(ObjectEntry obj, uint qty)
        {
            if (obj == null)
                return;

            qty = qty == 0 ?
                  obj.Quantity :
                  qty > obj.Quantity ? obj.Quantity : qty;

            _account.Network.SendMessage(new ObjectDropMessage(obj.UID, qty > obj.Quantity ? obj.Quantity : qty));
            _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("112", qty, obj.Name));
        }

        public void DeleteObject(ObjectEntry obj, uint qty)
        {
            if (obj == null)
                return;

            qty = qty == 0 ?
                  obj.Quantity :
                  qty > obj.Quantity ? obj.Quantity : qty;

            _account.Network.SendMessage(new ObjectDeleteMessage(obj.UID, qty));
            _account.Logger.LogInfo(LanguageManager.Translate("113"), LanguageManager.Translate("114", qty, obj.Name));
        }

        public void ResetMaxWeight()
        {
            try
            {
                MaxWeight = (short)(1000 + (5 * _account.Game.Character.Jobs.Jobs.Sum(j => j.Level)) + (1000 * _account.Game.Character.Jobs.Jobs.Count(j => j.Level == 100)) +
                                    (5 * _account.Game.Character.Stats.Strength.Total) + _account.Game.Character.Inventory.Equipements.Sum(e => e.WeightBoost));
            }
            catch
            {
                MaxWeight = _fallbackMaxWeight;
            }
        }

        #region Updates

        public void Update(InventoryContentMessage message)
        {
            _objects.Clear();
            Kamas = (int)message.Kamas;

            var items = DataManager.GetList<Items>(message.Objects.Select(f => (int)f.ObjectGID));
            for (int i = 0; i < message.Objects.Count; i++)
            {
                _objects.TryAdd(message.Objects[i].ObjectUID, new ObjectEntry(message.Objects[i], items.FirstOrDefault(f => f.Id == message.Objects[i].ObjectGID)));
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectAddedMessage message)
        {
            var obj = new ObjectEntry(message.Object);
            if (_objects.TryAdd(message.Object.ObjectUID, obj))
            {
                ObjectGained?.Invoke(obj.GID);
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectsAddedMessage message)
        {
            var items = DataManager.GetList<Items>(message.Object.Select(f => (int)f.ObjectGID));
            for (int i = 0; i < message.Object.Count; i++)
            {
                _objects.TryAdd(message.Object[i].ObjectUID, new ObjectEntry(message.Object[i], items.FirstOrDefault(f => f.Id == message.Object[i].ObjectGID)));
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectDeletedMessage message)
        {
            _objects.TryRemove(message.ObjectUID, out ObjectEntry value);

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectsDeletedMessage message)
        {
            for (int i = 0; i < message.ObjectUID.Count; i++)
            {
                _objects.TryRemove(message.ObjectUID[i], out ObjectEntry value);
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectModifiedMessage message)
        {
            if (_objects.TryGetValue(message.Object.ObjectUID, out ObjectEntry obj))
            {
                obj.Update(message.Object);
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectMovementMessage message)
        {
            if (_objects.TryGetValue(message.ObjectUID, out ObjectEntry obj))
            {
                obj.Update(message);

                if (obj.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                    ObjectEquipped?.Invoke(obj.GID);
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectQuantityMessage message)
        {
            if (_objects.TryGetValue(message.ObjectUID, out ObjectEntry obj))
            {
                obj.UpdateQuantity(message.Quantity);
                ObjectGained?.Invoke(obj.GID);
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(ObjectsQuantityMessage message)
        {
            for (int i = 0; i < message.ObjectsUIDAndQty.Count; i++)
            {
                if (_objects.TryGetValue(message.ObjectsUIDAndQty[i].ObjectUID, out ObjectEntry obj))
                {
                    obj.UpdateQuantity(message.ObjectsUIDAndQty[i].Quantity);
                }
            }

            RaiseINPCs();
            InventoryUpdated?.Invoke(true);
        }

        public void Update(InventoryWeightMessage message)
        {
            Weight = (short)message.Weight;
            _fallbackMaxWeight = (short)message.WeightMax;
            ResetMaxWeight();

            InventoryUpdated?.Invoke(false);
        }

        public void Update(KamasUpdateMessage message)
        {
            Kamas = message.KamasTotal;
            InventoryUpdated?.Invoke(false);
        }

        public void Update(CharacterStatsListMessage message)
        {
            Kamas = (int)message.Stats.Kamas;
            ResetMaxWeight();

            InventoryUpdated?.Invoke(false);
        }

        #endregion

        private void RaiseINPCs()
        {
            RaisePropertyChanged("Equipements");
            RaisePropertyChanged("Consumables");
            RaisePropertyChanged("Resources");
            RaisePropertyChanged("QuestObjects");
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                }

                _objects.Clear();
                _objects = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~InventoryGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
