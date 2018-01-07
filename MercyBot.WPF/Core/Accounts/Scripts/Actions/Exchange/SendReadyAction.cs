using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class SendReadyAction : ScriptAction
    {

        internal override Task<ScriptActionResults> Process(Account account)
        {
            account.Game.Exchange.SendReady();
            return ProcessingResult;
        }

    }
}
