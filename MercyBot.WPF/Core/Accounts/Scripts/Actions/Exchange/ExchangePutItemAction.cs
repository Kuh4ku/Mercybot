using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Exchange
{
    public class ExchangePutItemAction : ScriptAction
    {

        // Properties
        public int GID { get; private set; }
        public uint Quantity { get; private set; }


        // Constructor
        public ExchangePutItemAction(int gid, uint qty)
        {
            GID = gid;
            Quantity = qty;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Exchange.PutItem(GID, Quantity))
            {
                await Task.Delay(2000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
