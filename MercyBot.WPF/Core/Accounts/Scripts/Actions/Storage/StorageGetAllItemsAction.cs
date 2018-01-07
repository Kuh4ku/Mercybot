using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StorageGetAllItemsAction : ScriptAction
    {

        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.GetAllItems())
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
