using MoonSharp.Interpreter;
using System;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class API : IDisposable
    {

        // Properties
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public CharacterAPI Character { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public FightAPI Fight { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public GatherAPI Gather { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public InventoryAPI Inventory { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public JobsAPI Jobs { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public MapAPI Map { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public NpcAPI Npc { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public MountAPI Mount { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public StorageAPI Storage { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public ExchangeAPI Exchange { get; private set; }
        [Obfuscation(Exclude = false, Feature = "-rename")]
        public BidAPI Bid { get; private set; }


        // Constructor
        public API(Account account)
        {
            Character = new CharacterAPI(account);
            Fight = new FightAPI(account);
            Gather = new GatherAPI(account);
            Inventory = new InventoryAPI(account);
            Jobs = new JobsAPI(account);
            Map = new MapAPI(account);
            Npc = new NpcAPI(account);
            Mount = new MountAPI(account);
            Storage = new StorageAPI(account);
            Exchange = new ExchangeAPI(account);
            Bid = new BidAPI(account);
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Character.Dispose();
                    Fight.Dispose();
                    Gather.Dispose();
                    Inventory.Dispose();
                    Jobs.Dispose();
                    Map.Dispose();
                    Npc.Dispose();
                    Mount.Dispose();
                    Storage.Dispose();
                    Exchange.Dispose();
                    Bid.Dispose();
                }

                Character = null;
                Fight = null;
                Gather = null;
                Inventory = null;
                Jobs = null;
                Map = null;
                Npc = null;
                Mount = null;
                Storage = null;
                Exchange = null;
                Bid = null;

                _disposedValue = true;
            }
        }

        ~API()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
