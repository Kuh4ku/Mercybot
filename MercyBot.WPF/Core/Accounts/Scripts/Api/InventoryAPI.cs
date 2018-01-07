using MercyBot.Core.Accounts.Scripts.Actions.Inventory;
using MercyBot.Protocol.Enums;
using MoonSharp.Interpreter;
using System;
using System.Linq;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class InventoryAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public InventoryAPI(Account account)
        {
            _account = account;
        }


        public int Pods()
            => _account.Game.Character.Inventory.Weight;

        public int PodsMax()
            => _account.Game.Character.Inventory.MaxWeight;

        public int PodsP()
            => _account.Game.Character.Inventory.WeightPercent;

        public int ItemCount(int gid)
            => _account.Game.Character.Inventory.GetObjectsByGID(gid).Sum(o => (int)o.Quantity);

        public int ItemWeight(int gid)
           => _account.Game.Character.Inventory.GetObjectByGID(gid)?.RealWeight ?? 0;

        public bool UseItem(int gid, uint quantity = 1)
        {
            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new UseItemAction(gid, quantity), true);
            return true;
        }

        public bool EquipItem(int gid)
        {
            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null || item.Position != CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new EquipItemAction(gid), true);
            return true;
        }

        public bool UnEquipItem(int gid)
        {
            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null || item.Position == CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new UnEquipItemAction(gid), true);
            return true;
        }

        public bool DropItem(int gid, uint quantity = 1)
        {
            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new DropItemAction(gid, quantity), true);
            return true;
        }

        public bool DeleteItem(int gid, uint quantity = 1)
        {
            var item = _account.Game.Character.Inventory.GetObjectByGID(gid);

            if (item == null)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new DeleteItemAction(gid, quantity), true);
            return true;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _account = null;


                disposedValue = true;
            }
        }

        ~InventoryAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
