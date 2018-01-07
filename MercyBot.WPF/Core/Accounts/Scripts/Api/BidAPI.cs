using MercyBot.Core.Accounts.Scripts.Actions.Bid;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class BidAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public BidAPI(Account account)
        {
            _account = account;
        }


        public bool StartBuying()
        {
            if (_account.IsBusy)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StartBuyingAction(), true);
            return true;
        }

        public uint GetItemPrice(uint gid, uint lot)
            => _account.Game.Bid.GetItemPrice(gid, lot);

        public bool BuyItem(uint gid, uint lot)
        {
            if (_account.State != Enums.AccountStates.BUYING)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new BuyItemAction(gid, lot), true);
            return true;
        }

        public bool StartSelling()
        {
            if (_account.IsBusy)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new StartSellingAction(), true);
            return true;
        }

        public int ItemsInSaleCount()
            => _account.Game.Bid.ObjectsInSale?.Count ?? 0;

        public List<ObjectInSale> GetItemsInSale()
        {
            var itemsInSale = new List<ObjectInSale>();

            // This will automaticly handle the list being null
            if (_account.State != Enums.AccountStates.SELLING)
                return itemsInSale;

            for (int i = 0; i < _account.Game.Bid.ObjectsInSale.Count; i++)
            {
                itemsInSale.Add(new ObjectInSale()
                {
                    GID = _account.Game.Bid.ObjectsInSale[i].ObjectGID,
                    UID = _account.Game.Bid.ObjectsInSale[i].ObjectUID,
                    Lot = _account.Game.Bid.ObjectsInSale[i].Quantity,
                    Price = _account.Game.Bid.ObjectsInSale[i].ObjectPrice
                });
            }

            return itemsInSale;
        }

        public bool SellItem(uint gid, uint lot, uint price)
        {
            if (_account.State != Enums.AccountStates.SELLING)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new SellItemAction(gid, lot, price), true);
            return true;
        }

        public bool RemoveItemInSale(uint uid)
        {
            if (_account.State != Enums.AccountStates.SELLING)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new RemoveItemInSaleAction(uid), true);
            return true;
        }

        public bool EditItemInSalePrice(uint uid, uint newPrice)
        {
            if (_account.State != Enums.AccountStates.SELLING)
                return false;

            if (newPrice == 0)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new EditItemInSalePriceAction(uid, newPrice), true);
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

        ~BidAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }

    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public struct ObjectInSale
    {

        // Properties
        public uint GID { get; internal set; }
        public uint UID { get; internal set; }
        public uint Lot { get; internal set; }
        public uint Price { get; internal set; }

    }

}
