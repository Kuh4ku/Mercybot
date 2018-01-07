using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Npcs
{
    public class NpcBankAction : ScriptAction
    {

        // Properties
        public int NpcId { get; private set; }
        public int ReplyId { get; private set; }


        // Constructor
        public NpcBankAction(int npcId, int replyId)
        {
            NpcId = npcId;
            ReplyId = replyId;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Npcs.UseNpc(NpcId, 1))
            {
                account.Scripts.StopScript(LanguageManager.Translate("179"));
                return FailedResult;
            }

            return ProcessingResult;
        }

    }
}
