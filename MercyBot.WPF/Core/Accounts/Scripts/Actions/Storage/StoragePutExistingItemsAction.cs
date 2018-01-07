using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StoragePutExistingItemsAction : ScriptAction
    {

        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.PutExistingItems())
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
