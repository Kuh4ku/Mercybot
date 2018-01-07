using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Bid
{
    public class RemoveItemInSaleAction : ScriptAction
    {

        // Properties
        public uint UID { get; private set; }


        // Constructor
        public RemoveItemInSaleAction(uint uid)
        {
            UID = uid;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Bid.RemoveItemInSale(UID))
            {
                await Task.Delay(1500);
            }

            return ScriptActionResults.DONE;
        }

    }
}
