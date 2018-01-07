using MercyBot.Core.Accounts.InGame.Character.Inventory;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.InGame.Storage
{
    public class StorageGame : IDisposable
    {

        // Fields
        private Account _account;


        // Properties
        public List<ObjectEntry> Objects { get; private set; }
        public int Kamas { get; private set; }


        // Events
        public event Action StorageStarted;
        public event Action StorageUpdated;
        public event Action StorageLeft;


        // Constructor
        public StorageGame(Account account)
        {
            _account = account;

            Objects = new List<ObjectEntry>();
        }


        public bool PutItem(int gid, int quantity)
        {
            if (_account.State != AccountStates.STORAGE || quantity < 0)
                return false;

            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null)
                return false;

            quantity = quantity == 0 ?
                       (int)item.Quantity :
                       (quantity > item.Quantity ? (int)item.Quantity : quantity);

            _account.Network.SendMessage(new ExchangeObjectMoveMessage(item.UID, quantity));
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("118", quantity, item.Name));
            return true;
        }

        public bool GetItem(int gid, int quantity)
        {
            if (_account.State != AccountStates.STORAGE || quantity < 0)
                return false;

            var item = Objects.FirstOrDefault(o => o.GID == gid);

            if (item == null)
                return false;

            quantity = quantity == 0 ?
                       (int)item.Quantity :
                       (quantity > item.Quantity ? (int)item.Quantity : quantity);

            _account.Network.SendMessage(new ExchangeObjectMoveMessage(item.UID, quantity * -1));
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("119", quantity, item.Name));
            return true;
        }

        public bool PutKamas(int quantity)
        {
            if (_account.State != AccountStates.STORAGE || quantity < 0)
                return false;

            quantity = quantity == 0 ?
                       _account.Game.Character.Inventory.Kamas :
                       (quantity > _account.Game.Character.Inventory.Kamas ? _account.Game.Character.Inventory.Kamas : quantity);

            if (quantity > 0)
            {
                _account.Network.SendMessage(new ExchangeObjectMoveKamaMessage(quantity));
                _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("120", quantity));
            }

            return true;
        }

        public bool GetKamas(int quantity)
        {
            if (_account.State != AccountStates.STORAGE || quantity < 0)
                return false;

            quantity = quantity == 0 ?
                       Kamas :
                       (quantity > Kamas ? Kamas : quantity);

            if (quantity > 0)
            {
                _account.Network.SendMessage(new ExchangeObjectMoveKamaMessage(quantity * -1));
                _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("121", quantity));
                return true;
            }
            else
                return false;
        }

        public bool PutAllItems()
        {
            if (_account.State != AccountStates.STORAGE)
                return false;

            _account.Network.SendMessage(new ExchangeObjectTransfertAllFromInvMessage());
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("134"));
            return true;
        }

        public bool GetAllItems()
        {
            if (_account.State != AccountStates.STORAGE)
                return false;

            _account.Network.SendMessage(new ExchangeObjectTransfertAllToInvMessage());
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("135"));
            return true;
        }

        public bool PutExistingItems()
        {
            if (_account.State != AccountStates.STORAGE)
                return false;

            _account.Network.SendMessage(new ExchangeObjectTransfertExistingFromInvMessage());
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("136"));
            return true;
        }

        public bool GetExistingItems()
        {
            if (_account.State != AccountStates.STORAGE)
                return false;

            _account.Network.SendMessage(new ExchangeObjectTransfertExistingToInvMessage());
            _account.Logger.LogInfo(LanguageManager.Translate("132"), LanguageManager.Translate("137"));
            return true;
        }

        #region Updates

        public void Update(ExchangeStartedWithStorageMessage message)
        {
            _account.State = AccountStates.STORAGE;
        }

        public void Update(StorageInventoryContentMessage message)
        {
            Kamas = (int)message.Kamas;
            Objects.Clear();

            var objects = DataManager.GetEnumerable<Items>(message.Objects.Select(f => (int)f.ObjectGID));
            for (int i = 0; i < message.Objects.Count; i++)
            {
                Objects.Add(new ObjectEntry(message.Objects[i], objects.FirstOrDefault(f => f.Id == message.Objects[i].ObjectGID)));
            }

            StorageStarted?.Invoke();
        }

        public void Update(StorageKamasUpdateMessage message)
        {
            Kamas = message.KamasTotal;

            StorageUpdated?.Invoke();
        }

        public void Update(StorageObjectUpdateMessage message)
        {
            var obj = Objects.FirstOrDefault(f => f.UID == message.Object.ObjectUID);

            // Needs to be added
            if (obj == null)
            {
                Objects.Add(new ObjectEntry(message.Object, DataManager.Get<Items>((int)message.Object.ObjectGID)));
            }
            // Needs to be updated
            else
            {
                obj.Update(message.Object);
            }

            StorageUpdated?.Invoke();
        }

        public void Update(StorageObjectRemoveMessage message)
        {
            Objects.RemoveAll(o => o.UID == message.ObjectUID);

            StorageUpdated?.Invoke();
        }

        public void Update(StorageObjectsUpdateMessage message)
        {
            for (int i = 0; i < message.ObjectList.Count; i++)
            {
                var obj = Objects.FirstOrDefault(f => f.UID == message.ObjectList[i].ObjectUID);

                // Needs to be added
                if (obj == null)
                {
                    Objects.Add(new ObjectEntry(message.ObjectList[i], DataManager.Get<Items>((int)message.ObjectList[i].ObjectGID)));
                }
                // Needs to be updated
                else
                {
                    obj.Update(message.ObjectList[i]);
                }
            }

            StorageUpdated?.Invoke();
        }

        public void Update(StorageObjectsRemoveMessage message)
        {
            for (int i = 0; i < message.ObjectUIDList.Count; i++)
            {
                Objects.RemoveAll(o => o.UID == message.ObjectUIDList[i]);
            }

            StorageUpdated?.Invoke();
        }

        public void Update(ExchangeLeaveMessage message)
        {
            if ((DialogTypeEnum)message.DialogType == DialogTypeEnum.DIALOG_EXCHANGE && _account.State == AccountStates.STORAGE)
            {
                _account.State = AccountStates.NONE;
                Objects.Clear();
                Kamas = 0;

                StorageLeft?.Invoke();
            }
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                Objects.Clear();
                Objects = null;
                _account = null;

                disposedValue = true;
            }
        }

        ~StorageGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
