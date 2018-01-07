using MercyBot.Core.Accounts.Scripts.Actions.Fight;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class FightAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public FightAPI(Account account)
        {
            _account = account;
        }


        public bool CanFight(List<int> forbiddenMonsters = null, List<int> mandatoryMonsters = null, int minMonsters = 1, int maxMonsters = 8, int minMonstersLevel = 1, int maxMonstersLevel = 1000)
            => _account.Game.Map.CanFight(minMonsters, maxMonsters, minMonstersLevel, maxMonstersLevel, forbiddenMonsters, mandatoryMonsters);

        public bool Fight(List<int> forbiddenMonsters = null, List<int> mandatoryMonsters = null, int minMonsters = 1, int maxMonsters = 8, int minMonstersLevel = 1, int maxMonstersLevel = 1000)
        {
            if (CanFight(forbiddenMonsters, mandatoryMonsters, minMonsters, maxMonsters, minMonstersLevel, maxMonstersLevel))
            {
                _account.Scripts.ActionsManager.EnqueueAction(new FightAction(minMonsters, maxMonsters, minMonstersLevel, maxMonstersLevel, forbiddenMonsters, mandatoryMonsters), true);
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

        ~FightAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
