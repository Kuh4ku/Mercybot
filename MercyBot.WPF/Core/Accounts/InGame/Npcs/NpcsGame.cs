using MercyBot.Core.Accounts.InGame.Map.Entities;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Accounts.InGame.Npcs
{
    public class NpcsGame : IDisposable
    {

        // Fields
        private Account _account;


        // Properties
        public List<uint> PossibleReplies { get; private set; }


        // Events
        public event Action DialogCreated;
        public event Action QuestionReceived;
        public event Action DialogLeft;


        // Constructor
        public NpcsGame(Account account)
        {
            _account = account;
        }


        public bool Reply(int replyId)
        {
            if (_account.State != AccountStates.TALKING)
                return false;

            // In case its an index
            if (replyId < 0)
            {
                replyId = (replyId * -1) - 1;

                if (PossibleReplies.Count <= replyId)
                    return false;

                replyId = (int)PossibleReplies[replyId];
            }

            if (PossibleReplies.Contains((uint)replyId))
            {
                _account.Network.SendMessage(new NpcDialogReplyMessage((uint)replyId));
                return true;
            }

            return false;
        }

        public bool UseNpc(int npcId, int actionIndex)
        {
            if (_account.IsBusy)
                return false;

            // In case the actionIndex is negative
            actionIndex--;
            if (actionIndex < 0)
                return false;

            NpcEntry npc = null;
            var npcs = _account.Game.Map.Npcs;

            // In case the npcId is negative
            if (npcId < 0)
            {
                int index = (npcId * -1) - 1;

                // Check if the index is invalid
                if (npcs.Count() <= index)
                    return false;

                npc = npcs.ElementAt(index);
            }
            else
            {
                npc = npcs.FirstOrDefault(n => n.NpcId == npcId);
            }

            // If the npc is not found
            if (npc == null)
                return false;

            // Check if the npc has the action that we want
            if (npc.Data.Actions.Count <= actionIndex)
                return false;

            _account.Network.SendMessage(new NpcGenericActionRequestMessage(npc.Id, (uint)npc.Data.Actions[actionIndex], _account.Game.Map.Id));
            return true;
        }

        #region Updates

        public void Update(NpcDialogCreationMessage message)
        {
            _account.State = AccountStates.TALKING;
            DialogCreated?.Invoke();
        }

        public void Update(NpcDialogQuestionMessage message)
        {
            if (_account.State != AccountStates.TALKING)
                return;

            PossibleReplies = new List<uint>(message.VisibleReplies);
            QuestionReceived?.Invoke();
        }

        public void Update(LeaveDialogMessage message)
        {
            if (_account.State != AccountStates.TALKING)
                return;

            _account.State = AccountStates.NONE;
            PossibleReplies.Clear();
            PossibleReplies = null;
            DialogLeft?.Invoke();
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                PossibleReplies?.Clear();
                PossibleReplies = null;
                _account = null;

                disposedValue = true;
            }
        }

        ~NpcsGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
