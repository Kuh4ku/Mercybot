using System;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Npcs
{
    public class NpcAction : ScriptAction
    {

        // Properties
        public int NpcId { get; private set; }
        public uint ActionIndex { get; private set; }


        // Constructor
        public NpcAction(int npcId, uint actionIndex)
        {
            NpcId = npcId;
            ActionIndex = actionIndex;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (!account.Game.Npcs.UseNpc(NpcId, (int)ActionIndex))
            {
                account.Scripts.StopScript(LanguageManager.Translate("178", NpcId, ActionIndex));
                return FailedResult;
            }
            
            return ProcessingResult;
        }

    }
}
