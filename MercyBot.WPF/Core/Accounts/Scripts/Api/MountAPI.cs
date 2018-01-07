using MercyBot.Core.Accounts.Scripts.Actions.Mount;
using MoonSharp.Interpreter;
using System;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class MountAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public MountAPI(Account account)
        {
            _account = account;
        }


        public bool HasMount()
            => _account.Game.Character.Mount.HasMount;

        public bool IsRiding()
            => _account.Game.Character.Mount.IsRiding;

        public uint CurrentRatio()
            => _account.Game.Character.Mount.CurrentRatio;

        public bool ToggleRiding()
        {
            if (!_account.Game.Character.Mount.HasMount)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new ToggleRidingAction());
            return true;
        }

        public bool SetRatio(uint ratio)
        {
            if (ratio > 100)
                return false;

            if (!_account.Game.Character.Mount.HasMount)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new SetRatioAction(ratio));
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

        ~MountAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
