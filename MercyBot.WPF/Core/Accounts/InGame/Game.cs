using MercyBot.Core.Accounts.InGame.Character;
using MercyBot.Core.Accounts.InGame.Map;
using MercyBot.Core.Accounts.InGame.Server;
using MercyBot.Core.Accounts.InGame.Fights;
using MercyBot.Core.Accounts.InGame.Chat;
using MercyBot.Core.Accounts.InGame.Managers;
using MercyBot.Core.Accounts.InGame.Npcs;
using MercyBot.Core.Accounts.InGame.Storage;
using System;
using MercyBot.Core.Accounts.InGame.Exchange;
using MercyBot.Core.Accounts.InGame.Bid;

namespace MercyBot.Core.Accounts.InGame
{
    public class Game : IClearable, IDisposable
    {

        // Properties
        public ServerGame Server { get; private set; }
        public CharacterGame Character { get; private set; }
        public MapGame Map { get; private set; }
        public ManagersGame Managers { get; private set; }
        public FightGame Fight { get; private set; }
        public ChatGame Chat { get; private set; }
        public NpcsGame Npcs { get; private set; }
        public StorageGame Storage { get; private set; }
        public ExchangeGame Exchange { get; private set; }
        public BidGame Bid { get; private set; }


        // Constructor
        internal Game(Account account)
        {
            Server = new ServerGame();
            Character = new CharacterGame(account);
            Map = new MapGame(account);
            Fight = new FightGame(account);
            Managers = new ManagersGame(account, Map);
            Chat = new ChatGame(account);
            Npcs = new NpcsGame(account);
            Storage = new StorageGame(account);
            Exchange = new ExchangeGame(account);
            Bid = new BidGame(account);
        }


        public void Clear()
        {
            Character.Clear();
            Map.Clear();
            Fight.Clear();
            Managers.Clear();
            Bid.Clear();
        }


        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Server.Dispose();
                    Character.Dispose();
                    Map.Dispose();
                    Fight.Dispose();
                    Managers.Dispose();
                    Chat.Dispose();
                    Npcs.Dispose();
                    Storage.Dispose();
                    Exchange.Dispose();
                    Bid.Dispose();
                }

                Server = null;
                Character = null;
                Map = null;
                Fight = null;
                Managers = null;
                Chat = null;
                Npcs = null;
                Storage = null;
                Exchange = null;
                Bid = null;

                disposedValue = true;
            }
        }

        ~Game() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
