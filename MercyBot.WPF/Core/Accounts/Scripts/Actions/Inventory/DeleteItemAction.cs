using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Inventory
{
    public class DeleteItemAction : ScriptAction
    {

        // Properties
        public int GID { get; private set; }
        public uint Quantity { get; private set; }


        // Constructor
        public DeleteItemAction(int gid, uint quantity)
        {
            GID = gid;
            Quantity = quantity;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            var obj = account.Game.Character.Inventory.GetObjectByGID(GID);

            if (obj != null)
            {
                account.Game.Character.Inventory.DeleteObject(obj, Quantity);
                await Task.Delay(500);
            }

            return ScriptActionResults.DONE;
        }

    }
}
