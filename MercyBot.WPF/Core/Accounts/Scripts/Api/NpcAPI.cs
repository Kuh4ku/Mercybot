using MercyBot.Core.Accounts.Scripts.Actions.Npcs;
using MoonSharp.Interpreter;
using System;
using System.Linq;
using System.Reflection;

namespace MercyBot.Core.Accounts.Scripts.Api
{
    [MoonSharpUserData]
    [Obfuscation(Exclude = false, Feature = "-rename", ApplyToMembers = true)]
    public class NpcAPI : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public NpcAPI(Account account)
        {
            _account = account;
        }


        public bool NpcBank(int npcId, int replyId)
        {
            if (npcId > 0 && _account.Game.Map.Npcs.FirstOrDefault(n => n.NpcId == npcId) == null)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new NpcBankAction(npcId, replyId), true);
            return true;
        }

        public bool Npc(int npcId, uint actionIndex)
        {
            if (npcId > 0 && _account.Game.Map.Npcs.FirstOrDefault(n => n.NpcId == npcId) == null)
                return false;

            _account.Scripts.ActionsManager.EnqueueAction(new NpcAction(npcId, actionIndex), true);
            return true;
        }

        public void Reply(int replyId)
            => _account.Scripts.ActionsManager.EnqueueAction(new ReplyAction(replyId), true);

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _account = null;


                disposedValue = true;
            }
        }

        ~NpcAPI()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
