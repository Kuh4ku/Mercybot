using MercyBot.Core.Accounts.Scripts.Actions.Gather;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class GatherAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public GatherAPI(Account account)
        {
            _account = account;
        }


        public bool CanGather(List<int> ressourcesIds = null)
        {
            ressourcesIds = ressourcesIds ?? new List<int>();

            // If no ressources were set, use the character's jobs
            if (ressourcesIds.Count == 0)
                ressourcesIds.AddRange(_account.Game.Character.Jobs.GetCollectSkillsIds());

            return _account.Game.Managers.Gathers.CanGather(ressourcesIds);
        }


        public bool Gather(List<int> ressourcesIds = null)
        {
            ressourcesIds = ressourcesIds ?? new List<int>();

            // Using CanGather will handle the case of ressourcesIds being empty
            if (CanGather(ressourcesIds))
            {
                _account.Scripts.ActionsManager.EnqueueAction(new GatherAction(ressourcesIds), true);
                return true;
            }

            return false;
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

        ~GatherAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
