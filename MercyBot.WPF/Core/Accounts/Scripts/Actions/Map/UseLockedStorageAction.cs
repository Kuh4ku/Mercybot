using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class UseLockedStorageAction : ScriptAction
    {

        // Properties
        public short ElementCellId { get; }
        public string LockCode { get; }


        // Constructor
        public UseLockedStorageAction(short elementCellId, string lockCode)
        {
            ElementCellId = elementCellId;
            LockCode = lockCode;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Managers.Interactives.UseLockedStorage(ElementCellId, LockCode))
            {
                account.Scripts.StopScript(LanguageManager.Translate("565"));
                return FailedResult;
            }

            return ProcessingResult;
        }

    }
}
