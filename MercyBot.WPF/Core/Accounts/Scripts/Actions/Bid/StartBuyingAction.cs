using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Bid
{
    public class StartBuyingAction : ScriptAction
    {

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Bid.StartBuying())
            {
                return ProcessingResult;
            }

            return DoneResult;
        }

    }
}
