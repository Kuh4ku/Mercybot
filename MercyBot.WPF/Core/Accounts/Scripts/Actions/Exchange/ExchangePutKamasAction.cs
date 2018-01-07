using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class ExchangePutKamasAction : ScriptAction
    {

        // Properties
        public uint Quantity { get; private set; }


        // Constructor
        public ExchangePutKamasAction(uint qty)
        {
            Quantity = qty;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Exchange.PutKamas(Quantity))
            {
                await Task.Delay(2000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
