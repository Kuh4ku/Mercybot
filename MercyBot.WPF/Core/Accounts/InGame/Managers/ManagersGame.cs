using MercyBot.Core.Accounts.InGame.Managers.Interactives;
using MercyBot.Core.Accounts.InGame.Managers.Movements;
using MercyBot.Core.Accounts.InGame.Managers.Gathers;
using MercyBot.Core.Accounts.InGame.Map;
using System;
using MercyBot.Core.Accounts.InGame.Managers.Teleportables;

namespace MercyBot.Core.Accounts.InGame.Managers
{
    public class ManagersGame : IClearable, IDisposable
    {

        // Properties
        public MovementsManager Movements { get; private set; }
        public InteractivesManager Interactives { get; private set; }
        public GathersManager Gathers { get; private set; }
        public TeleportablesManager Teleportables { get; private set; }


        // Constructor
        public ManagersGame(Account account, MapGame map)
        {
            Movements = new MovementsManager(account, map);
            Interactives = new InteractivesManager(account, Movements);
            Gathers = new GathersManager(account, Movements, map);
            Teleportables = new TeleportablesManager(account, Interactives, map);
        }


        public void Cancel()
        {
            Movements.Cancel();
            Interactives.CancelUse();
            Gathers.CancelGather();
            Teleportables.Cancel();
        }

        public void Clear()
        {
            Movements.Clear();
            Interactives.Clear();
            Gathers.Clear();
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
                return;

            if (disposing)
            {
                Movements.Dispose();
                Interactives.Dispose();
                Gathers.Dispose();
                Teleportables.Dispose();
            }

            Movements = null;
            Interactives = null;
            Gathers = null;
            Teleportables = null;

            _disposedValue = true;
        }

        ~ManagersGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
