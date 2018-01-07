using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Bid
{
    public class SellItemAction : ScriptAction
    {

        // Properties
        public uint GID { get; private set; }
        public uint Lot { get; private set; }
        public uint Price { get; private set; }


        // Constructor
        public SellItemAction(uint gid, uint lot, uint price)
        {
            GID = gid;
            Lot = lot;
            Price = price;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Bid.SellItem(GID, Lot, Price))
            {
                await Task.Delay(1500);
            }

            return ScriptActionResults.DONE;
        }

    }
}
