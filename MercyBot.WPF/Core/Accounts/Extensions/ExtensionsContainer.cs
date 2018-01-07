using MercyBot.Core.Accounts.Extensions.Bid;
using MercyBot.Core.Accounts.Extensions.Exchanges;
using MercyBot.Core.Accounts.Extensions.Fights;
using MercyBot.Core.Accounts.Extensions.Flood;
using System;
using MercyBot.Core.Accounts.Extensions.CharacterCreator;

namespace MercyBot.Core.Accounts.Extensions
{
    public class ExtensionsContainer : IClearable, IDisposable
    {

        // Properties
        public FightsExtension Fights { get; private set; }
        public BidExtension Bid { get; private set; }
        public RoleplayExtension Roleplay { get; private set; }
        public FloodExtension Flood { get; private set; }
        public CharacterCreatorExtension CharacterCreation { get; private set; }


        // Constructor
        public ExtensionsContainer(Account account)
        {
            Fights = new FightsExtension(account);
            Bid = new BidExtension(account);
            Roleplay = new RoleplayExtension(account);
            Flood = new FloodExtension(account);
            CharacterCreation = new CharacterCreatorExtension(account);
        }


        public void Clear()
        {
            Fights.Clear();
            Bid.Clear();
            CharacterCreation.Clear();
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Fights.Dispose();
                    Bid.Dispose();
                    Roleplay.Dispose();
                    Flood.Dispose();
                    CharacterCreation.Dispose();
                }

                Fights = null;
                Bid = null;
                Roleplay = null;
                Flood = null;
                CharacterCreation = null;

                _disposedValue = true;
            }
        }

        ~ExtensionsContainer() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
