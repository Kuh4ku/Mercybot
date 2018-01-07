using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Bid
{
    public class BuyItemAction : ScriptAction
    {

        // Properties
        public uint GID { get; private set; }
        public uint Lot { get; private set; }


        // Constructor
        public BuyItemAction(uint gid, uint lot)
        {
            GID = gid;
            Lot = lot;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Bid.BuyItem(GID, Lot))
            {
                await Task.Delay(1500);
            }

            return ScriptActionResults.DONE;
        }

    }
}
