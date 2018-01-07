using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StorageGetKamasAction : ScriptAction
    {

        // Properties
        public int Amount { get; private set; }


        // Constructor
        public StorageGetKamasAction(int amount)
        {
            Amount = amount;
        }

        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.GetKamas(Amount))
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
