using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Inventory
{
    public class UnEquipItemAction : ScriptAction
    {

        // Properties
        public int GID { get; private set; }


        // Constructor
        public UnEquipItemAction(int gid)
        {
            GID = gid;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            var obj = account.Game.Character.Inventory.GetObjectByGID(GID);

            if (obj != null && account.Game.Character.Inventory.UnEquipObject(obj))
            {
                await Task.Delay(500);
            }

            return ScriptActionResults.DONE;
        }

    }
}
