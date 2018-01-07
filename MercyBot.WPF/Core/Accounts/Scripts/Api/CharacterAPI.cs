using MercyBot.Protocol.Enums;
using MoonSharp.Interpreter;
using System;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class CharacterAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public CharacterAPI(Account account)
        {
            _account = account;
        }


        public bool IsAlive()
            => _account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING;

        public bool IsTombstone()
            => _account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_TOMBSTONE;

        public bool IsPhantom()
            => _account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_PHANTOM;

        public string Name()
            => _account.Game.Character.Name;

        public byte Level()
            => _account.Game.Character.Level;

        public bool Sex()
            => _account.Game.Character.Sex;

        public uint LifePoints()
            => _account.Game.Character.Stats.LifePoints;

        public uint MaxLifePoints()
            => _account.Game.Character.Stats.MaxLifePoints;

        public int LifePointsP()
            => _account.Game.Character.Stats.LifePercent;

        public int Experience()
            => _account.Game.Character.Stats.ExperiencePercent;

        public uint EnergyPoints()
            => _account.Game.Character.Stats.EnergyPoints;

        public uint MaxEnergyPoints()
            => _account.Game.Character.Stats.MaxEnergyPoints;

        public int EnergyPointsP()
            => _account.Game.Character.Stats.EnergyPercent;

        public int Kamas()
            => _account.Game.Character.Inventory.Kamas;

        public void Sit()
            => _account.Game.Character.Sit();

        public bool FreeSoul()
            => _account.Game.Character.FreeSoul();

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

        ~CharacterAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
