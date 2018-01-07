using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class ExchangeRemoveKamasAction : ScriptAction
    {

        // Properties
        public uint Quantity { get; private set; }


        // Constructor
        public ExchangeRemoveKamasAction(uint qty)
        {
            Quantity = qty;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Exchange.RemoveKamas(Quantity))
            {
                await Task.Delay(2000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
