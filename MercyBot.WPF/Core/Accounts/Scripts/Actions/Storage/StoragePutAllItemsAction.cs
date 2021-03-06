using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StoragePutAllItemsAction : ScriptAction
    {

        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.PutAllItems())
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
