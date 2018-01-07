using MercyBot.Core.Accounts.Scripts.Actions.Storage;
using MoonSharp.Interpreter;
using System;
using System.Linq;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class StorageAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public StorageAPI(Account account)
        {
            _account = account;
        }


        public int ItemCount(int gid)
            => (int)_account.Game.Storage.Objects.Where(o => o.GID == gid).Sum(o => o.Quantity);

        public int Kamas()
            => _account.Game.Storage.Kamas;

        public bool PutItem(int gid, uint quantity)
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            if (_account.Game.Character.Inventory.GetObjectsByGID(gid).Sum(o => o.Quantity) == 0)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StoragePutItemAction(gid, quantity), true);
            return true;
        }

        public bool GetItem(int gid, uint quantity)
        {
            if (ItemCount(gid) == 0)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StorageGetItemAction(gid, quantity), true);
            return true;
        }

        public bool PutKamas(uint quantity)
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StoragePutKamasAction((int)quantity), true);
            return true;
        }

        public bool GetKamas(uint quantity)
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StorageGetKamasAction((int)quantity), true);
            return true;
        }

        public bool PutAllItems()
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StoragePutAllItemsAction(), true);
            return true;
        }

        public bool GetAllItems()
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StorageGetAllItemsAction(), true);
            return true;
        }

        public bool PutExistingItems()
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StoragePutExistingItemsAction(), true);
            return true;
        }

        public bool GetExistingItems()
        {
            if (_account.State != Enums.AccountStates.STORAGE)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StorageGetExistingItemsAction(), true);
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

        ~StorageAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
