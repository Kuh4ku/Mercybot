using MercyBot.Protocol.Data;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;
using System;
using System.Collections.Generic;

namespace MercyBot.Core.Accounts.InGame.Server
{
    public class ServerGame : IDisposable
    {

        // Properties
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<CharacterBaseInformations> Characters { get; private set; }


        // Events
        public event Action ServerSelected;


        // Constructor
        internal ServerGame()
        {
            Characters = new List<CharacterBaseInformations>();
        }


        #region Update

        public void Update(SelectedServerDataMessage message)
        {
            Id = message.ServerId;
            Name = DataManager.Get<Servers>(Id).NameId;

            ServerSelected?.Invoke();
        }

        public void Update(CharactersListMessage message)
        {
            if (message.Characters.Count > 0)
            {
                Characters.AddRange(message.Characters);
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

                Name = null;
                Characters.Clear();
                Characters = null;

                disposedValue = true;
            }
        }

        ~ServerGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
