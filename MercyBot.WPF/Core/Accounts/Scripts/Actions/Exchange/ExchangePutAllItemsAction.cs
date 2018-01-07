using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class ExchangePutAllItemsAction : ScriptAction
    {

        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (await account.Game.Exchange.PutAllItems())
            {
                await Task.Delay(2000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
