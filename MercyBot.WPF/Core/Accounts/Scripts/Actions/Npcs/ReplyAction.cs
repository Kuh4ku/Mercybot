using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Npcs
{
    public class ReplyAction : ScriptAction
    {

        // Properties
        public int ReplyId { get; private set; }


        // Constructor
        public ReplyAction(int replyId)
        {
            ReplyId = replyId;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Npcs.Reply(ReplyId))
            {
                account.Scripts.StopScript(LanguageManager.Translate("180", ReplyId));
                return FailedResult;
            }

            return ProcessingResult;
        }

    }
}
