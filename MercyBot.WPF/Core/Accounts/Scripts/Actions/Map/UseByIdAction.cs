using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class UseByIdAction : ScriptAction
    {

        // Properties
        public int ElementId { get; private set; }
        public int SkillInstanceUid { get; private set; }


        // Constructor
        public UseByIdAction(int elementId, int skillInstanceUid)
        {
            ElementId = elementId;
            SkillInstanceUid = skillInstanceUid;
        }

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Managers.Interactives.UseInteractive(ElementId, SkillInstanceUid))
            {
                account.Scripts.StopScript(LanguageManager.Translate("177", ElementId));
                return FailedResult;
            }

            return ProcessingResult;
        }
    }
}
