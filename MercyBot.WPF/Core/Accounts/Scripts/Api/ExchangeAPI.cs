using MercyBot.Core.Accounts.Scripts.Actions.Exchange;
using MoonSharp.Interpreter;
using System;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class ExchangeAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public ExchangeAPI(Account account)
        {
            _account = account;
        }


        public int WeightP()
            => _account.Game.Exchange.WeightPercent;

        public int TargetWeightP()
            => _account.Game.Exchange.RemoteWeightPercent;

        public void StartExchange(uint playerId)
            => _account.Scripts.ActionsManager.EnqueueAction(new StartExchangeAction((int)playerId), true);

        public void SendReady()
            => _account.Scripts.ActionsManager.EnqueueAction(new SendReadyAction(), true);

        public void PutItem(int gid, uint qty)
            => _account.Scripts.ActionsManager.EnqueueAction(new ExchangePutItemAction(gid, qty), true);

        public void RemoveItem(int gid, uint qty)
            => _account.Scripts.ActionsManager.EnqueueAction(new ExchangeRemoveItemAction(gid, qty), true);

        public void PutAllItems()
            => _account.Scripts.ActionsManager.EnqueueAction(new ExchangePutAllItemsAction(), true);

        public void PutKamas(uint qty)
            => _account.Scripts.ActionsManager.EnqueueAction(new ExchangePutKamasAction(qty), true);

        public void RemoveKamas(uint qty)
            => _account.Scripts.ActionsManager.EnqueueAction(new ExchangeRemoveKamasAction(qty), true);

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

        ~ExchangeAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
