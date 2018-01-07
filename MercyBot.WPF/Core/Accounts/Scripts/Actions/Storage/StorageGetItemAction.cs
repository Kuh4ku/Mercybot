using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Storage
{
    public class StorageGetItemAction : ScriptAction
    {

        // Properties
        // Properties
        public int GID { get; private set; }
        public uint Quantity { get; private set; }


        // Constructor
        public StorageGetItemAction(int gid, uint quantity)
        {
            GID = gid;
            Quantity = quantity;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Storage.GetItem(GID, (int)Quantity))
            {
                await Task.Delay(1000);
            }

            return ScriptActionResults.DONE;
        }

    }
}
