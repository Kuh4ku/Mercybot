using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Bid
{
    public class EditItemInSalePriceAction : ScriptAction
    {

        // Properties
        public uint UID { get; private set; }
        public uint NewPrice { get; private set; }


        // Constructor
        public EditItemInSalePriceAction(uint uid, uint newPrice)
        {
            UID = uid;
            NewPrice = newPrice;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Bid.EditItemInSalePrice(UID, NewPrice))
            {
                await Task.Delay(3000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
