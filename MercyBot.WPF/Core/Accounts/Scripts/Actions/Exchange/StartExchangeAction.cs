using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class StartExchangeAction : ScriptAction
    {

        // Properties
        public int PlayerId { get; private set; }


        // Constructor
        public StartExchangeAction(int playerId)
        {
            PlayerId = playerId;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Exchange.StartExchange(PlayerId))
                return ProcessingResult;

            return DoneResult;
        }

    }
}
