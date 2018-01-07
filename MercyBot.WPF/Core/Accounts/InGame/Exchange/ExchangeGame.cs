using MercyBot.Core.Accounts.InGame.Character.Inventory;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Enums;

namespace MercyBot.Core.Accounts.InGame.Exchange
{
    public class ExchangeGame : IDisposable
    {

        // Fields
        private Account _account;
        private uint _step;


        // Properties
        public List<ObjectEntry> Objects { get; private set; }
        public List<ObjectEntry> RemoteObjects { get; private set; }
        public uint Kamas { get; private set; }
        public uint RemoteKamas { get; private set; }
        public uint CurrentWeight { get; private set; }
        public uint MaxWeight { get; private set; }
        public uint RemoteCurrentWeight { get; private set; }
        public uint RemoteMaxWeight { get; private set; }
        public bool IsReady { get; private set; }
        public bool RemoteIsReady { get; private set; }

        public int WeightPercent => (int)(((double)CurrentWeight / MaxWeight) * 100);
        public int RemoteWeightPercent => (int)(((double)RemoteCurrentWeight / RemoteMaxWeight) * 100);


        // Events
        public event Action<int> ExchangeRequested;
        public event Action ExchangeStarted;
        public event Action ExchangeContentChanged;
        public event Action RemoteReady;
        public event Action ExchangeLeft;


        // Constructor
        public ExchangeGame(Account account)
        {
            _account = account;

            Objects = new List<ObjectEntry>();
            RemoteObjects = new List<ObjectEntry>();
        }
        

        public bool StartExchange(int id)
        {
            if (_account.IsBusy)
                return false;

            if (_account.Game.Map.Players.FirstOrDefault(p => p.Id == id) == null)
                return false;

            _account.Network.SendMessage(new ExchangePlayerRequestMessage(1, (uint)id));
            return true;
        }

        public bool SendReady()
        {
            if (_account.State != Enums.AccountStates.EXCHANGE)
                return false;

            _account.Network.SendMessage(new ExchangeReadyMessage(true, _step));
            _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("116"));
            return true;
        }

        public bool PutItem(int gid, uint quantity)
        {
            if (_account.State != AccountStates.EXCHANGE)
                return false;

            var obj = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (obj == null)
                return false;

            quantity = quantity == 0 ?
                       obj.Quantity :
                       (quantity > obj.Quantity ? obj.Quantity : quantity);

            _account.Network.SendMessage(new ExchangeObjectMoveMessage(obj.UID, (int)quantity));
            _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("118", quantity, obj.Name));
            return true;
        }

        public bool RemoveItem(int gid, uint quantity)
        {
            if (_account.State != AccountStates.EXCHANGE)
                return false;

            var obj = Objects.FirstOrDefault(o => o.GID == gid);

            if (obj == null)
                return false;

            quantity = quantity == 0 ?
                       obj.Quantity :
                       (quantity > obj.Quantity ? obj.Quantity : quantity);

            _account.Network.SendMessage(new ExchangeObjectMoveMessage(obj.UID, (int)quantity * -1));
            _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("119", quantity, obj.Name));
            return true;
        }

        public async Task<bool> PutAllItems()
        {
            if (_account.State != AccountStates.EXCHANGE)
                return false;

            _account.Logger.LogDebug(LanguageManager.Translate("117"), LanguageManager.Translate("531"));

            foreach (var obj in _account.Game.Character.Inventory.Equipements)
            {
                if (!obj.Exchangeable || obj.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                    continue;

                _account.Network.SendMessage(new ExchangeObjectMoveMessage(obj.UID, (int)obj.Quantity));
                await Task.Delay(600);
            }

            foreach (var obj in _account.Game.Character.Inventory.Consumables)
            {
                if (!obj.Exchangeable || obj.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                    continue;

                _account.Network.SendMessage(new ExchangeObjectMoveMessage(obj.UID, (int)obj.Quantity));
                await Task.Delay(600);
            }

            foreach (var obj in _account.Game.Character.Inventory.Resources)
            {
                if (!obj.Exchangeable || obj.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                    continue;

                _account.Network.SendMessage(new ExchangeObjectMoveMessage(obj.UID, (int)obj.Quantity));
                await Task.Delay(600);
            }

            _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("532"));
            return true;
        }

        public bool PutKamas(uint quantity)
        {
            if (_account.State != Enums.AccountStates.EXCHANGE)
                return false;

            quantity = quantity == 0 ?
                       (uint)_account.Game.Character.Inventory.Kamas :
                       (quantity > _account.Game.Character.Inventory.Kamas ? (uint)_account.Game.Character.Inventory.Kamas : quantity);

            if (quantity > 0)
            {
                _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("120", quantity));
                _account.Network.SendMessage(new ExchangeObjectMoveKamaMessage((int)quantity));
                return true;
            }

            return false;
        }

        public bool RemoveKamas(uint quantity)
        {
            if (_account.State != Enums.AccountStates.EXCHANGE)
                return false;

            quantity = quantity == 0 ?
                       Kamas :
                       (quantity > Kamas ? Kamas : quantity);

            if (quantity > 0)
            {
                _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("121", quantity));
                _account.Network.SendMessage(new ExchangeObjectMoveKamaMessage((int)(Kamas - quantity)));
                return true;
            }

            return false;
        }

        #region Updates

        public void Update(ExchangeRequestedTradeMessage message)
        {
            if (message.ExchangeType == 1 && message.Target == _account.Game.Character.Id)
                ExchangeRequested?.Invoke((int)message.Source);
        }

        public void Update(ExchangeStartedWithPodsMessage message)
        {
            _step = 0;
            IsReady = false;
            RemoteIsReady = false;
            _account.State = Enums.AccountStates.EXCHANGE;

            if (message.FirstCharacterId == _account.Game.Character.Id)
            {
                CurrentWeight = message.FirstCharacterCurrentWeight;
                MaxWeight = message.FirstCharacterMaxWeight;
                RemoteCurrentWeight = message.SecondCharacterCurrentWeight;
                RemoteMaxWeight = message.SecondCharacterMaxWeight;
            }
            else
            {
                CurrentWeight = message.SecondCharacterCurrentWeight;
                MaxWeight = message.SecondCharacterMaxWeight;
                RemoteCurrentWeight = message.FirstCharacterCurrentWeight;
                RemoteMaxWeight = message.FirstCharacterMaxWeight;
            }

            ExchangeStarted?.Invoke();
        }

        public void Update(ExchangeObjectAddedMessage message)
        {
            var newObj = new ObjectEntry(message.Object);

            if (message.Remote)
            {
                RemoteObjects.Add(newObj);
                RemoteCurrentWeight += (uint)newObj.RealWeight * newObj.Quantity;
            }
            else
            {
                Objects.Add(newObj);
                CurrentWeight += (uint)newObj.RealWeight * newObj.Quantity;
            }

            _step++;
            ExchangeContentChanged?.Invoke();
        }

        public void Update(ExchangeObjectModifiedMessage message)
        {
            var modifiedObj = message.Remote ?
                              RemoteObjects.FirstOrDefault(o => o.UID == message.Object.ObjectUID) :
                              Objects.FirstOrDefault(o => o.UID == message.Object.ObjectUID);

            int qtyDiff = (int)message.Object.Quantity - (int)modifiedObj.Quantity;
            modifiedObj.Update(message.Object);

            if (message.Remote)
            {
                RemoteCurrentWeight += (uint)(qtyDiff * modifiedObj.RealWeight);
            }
            else
            {
                CurrentWeight += (uint)(qtyDiff * modifiedObj.RealWeight);
            }

            _step++;
            ExchangeContentChanged?.Invoke();
        }

        public void Update(ExchangeObjectRemovedMessage message)
        {
            var removedObj = message.Remote ?
                              RemoteObjects.FirstOrDefault(o => o.UID == message.ObjectUID) :
                              Objects.FirstOrDefault(o => o.UID == message.ObjectUID);

            if (message.Remote)
            {
                RemoteCurrentWeight += (uint)(removedObj.Quantity * removedObj.RealWeight);
                RemoteObjects.Remove(removedObj);
            }
            else
            {
                CurrentWeight += (uint)(removedObj.Quantity * removedObj.RealWeight);
                Objects.Remove(removedObj);
            }

            _step++;
            ExchangeContentChanged?.Invoke();
        }

        public void Update(ExchangeKamaModifiedMessage message)
        {
            if (message.Remote)
            {
                RemoteKamas = message.Quantity;
            }
            else
            {
                Kamas = message.Quantity;
            }

            _step++;
            ExchangeContentChanged?.Invoke();
        }

        public void Update(ExchangeIsReadyMessage message)
        {
            if (message.Id == _account.Game.Character.Id)
            {
                IsReady = true;
            }
            else
            {
                RemoteIsReady = true;
                RemoteReady?.Invoke();
            }
        }

        public void Update(ExchangeLeaveMessage message)
        {
            if (_account.State != Enums.AccountStates.EXCHANGE)
                return;

            Objects.Clear();
            RemoteObjects.Clear();
            Kamas = RemoteKamas = 0;
            CurrentWeight = MaxWeight = RemoteCurrentWeight = RemoteMaxWeight = 0;
            _step = 0;
            _account.State = Enums.AccountStates.NONE;

            ExchangeLeft?.Invoke();
        }

        #endregion

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                Objects.Clear();
                RemoteObjects.Clear();
                Objects = null;
                RemoteObjects = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~ExchangeGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
