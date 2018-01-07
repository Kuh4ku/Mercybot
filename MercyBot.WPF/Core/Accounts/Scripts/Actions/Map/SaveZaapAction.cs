using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class SaveZaapAction : ScriptAction
    {

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Managers.Teleportables.SaveZaap())
            {
                account.Scripts.StopScript(LanguageManager.Translate("538"));
                return FailedResult;
            }

            return ProcessingResult;
        }

    }
}
