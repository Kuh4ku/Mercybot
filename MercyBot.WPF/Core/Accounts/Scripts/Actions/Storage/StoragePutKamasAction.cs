using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StoragePutKamasAction : ScriptAction
    {

        // Properties
        public int Amount { get; private set; }


        // Constructor
        public StoragePutKamasAction(int amount)
        {
            Amount = amount;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.PutKamas(Amount))
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
