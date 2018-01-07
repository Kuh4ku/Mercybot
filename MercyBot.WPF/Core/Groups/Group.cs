using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.Scripts.Actions;
using MercyBot.Core.Accounts.Scripts.Actions.Fight;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Groups
{
    public class Group : IEntity, IDisposable
    {

        // Fields
        private Grouping _grouping;
        private Dictionary<Account, ManualResetEvent> _membersAccountsFinished;


        // Properties
        public Account Chief { get; private set; }
        public ObservableCollection<Account> Members { get; private set; }


        // Constructor
        public Group(Account chief)
        {
            _grouping = new Grouping(this);
            _membersAccountsFinished = new Dictionary<Account, ManualResetEvent>();
            Chief = chief;
            Members = new ObservableCollection<Account>();

            Chief.Group = this;
            Chief.Game.Fight.FightIdReceived += Chief_FightIdReceived;
            Chief.RecaptchaResolved += Account_RecaptchaResolved;
        }


        public void AddMember(Account member)
        {
            // A group can have 7 members maximum
            if (Members.Count >= 7)
                return;

            member.Group = this;
            Members.Add(member);
            _membersAccountsFinished.Add(member, new ManualResetEvent(false));

            member.Scripts.ActionsManager.ActionsFinished += Member_ActionsFinished;
            member.RecaptchaResolved += Account_RecaptchaResolved;
        }

        public void Connect()
        {
            Task.Run(Chief.Connect);

            for (int i = 0; i < Members.Count; i++)
            {
                Task.Run(Members[i].Connect);
            }
        }

        public async Task Disconnect(string reason)
        {
            await Chief.Network.Disconnect(reason);

            for (int i = 0; i < Members.Count; i++)
            {
                await Members[i].Network.Disconnect(reason);
            }
        }

        public void MembersCleaningAndClearing()
        {
            for (int i = 0; i < Members.Count; i++)
            {
                Members[i].Game.Managers.Gathers.CancelGather();
                Members[i].Game.Managers.Interactives.CancelUse();
                Members[i].Scripts.ActionsManager.ClearEverything();
            }
        }

        public async Task RegroupMembersIfNeeded()
        {
            if (Members.All(m => m.Game.Map.CurrentPosition == Chief.Game.Map.CurrentPosition))
                return;

            Chief.Logger.LogInfo("Grouping", LanguageManager.Translate("568"));
            await _grouping.GroupMembers();
            Chief.Logger.LogInfo("Grouping", LanguageManager.Translate("569"));
        }

        #region Checkings

        public bool IsAnyoneBusy()
            => Chief.IsBusy || Members.Any(m => m.IsBusy);

        public bool IsAnyoneFullWeight()
        {
            int maxPods = Chief.Scripts.ScriptManager.GetGlobalOr(LanguageManager.Translate("145"), MoonSharp.Interpreter.DataType.Number, 90);

            if (Chief.Game.Character.Inventory.WeightPercent >= maxPods)
                return true;

            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Game.Character.Inventory.WeightPercent >= maxPods)
                    return true;
            }

            return false;
        }

        public bool IsEveryoneAliveAndKicking()
        {
            if (Chief.Game.Character.LifeStatus != Protocol.Enums.PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING)
                return false;

            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].Game.Character.LifeStatus != Protocol.Enums.PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING)
                    return false;
            }

            return true;
        }

        public async Task ApplyCheckings()
        {
            var checkings = new Task[Members.Count + 1];
            checkings[0] = Chief.Scripts.ApplyCheckings();

            for (int i = 0; i < Members.Count; i++)
            {
                checkings[i + 1] = Members[i].Scripts.ApplyCheckings();
            }

            await Task.WhenAll(checkings);
        }

        public bool IsGroupMember(int playerId)
            => Members.FirstOrDefault(m => m.Game.Character.Id == playerId) != null;

        #endregion

        #region Fights

        public async Task WaitForMembersToJoinFight()
        {
            while (Members.Any(m => m.State != AccountStates.FIGHTING) && !Chief.Game.Fight.IsFightStarted)
            {
                Console.WriteLine("Waiting for members to join the fight..");
                await Task.Delay(1000);
            }
        }

        public void SignalMembersToJoinFight()
        {
            // Just in case
            if (Chief.State != AccountStates.FIGHTING)
                return;

            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].State == AccountStates.FIGHTING)
                    continue;

                // Send a join request to the member
                Console.WriteLine("{0} sending fight join request", Members[i].AccountConfig.Username);
                Members[i].Network.SendMessage(new GameFightJoinRequestMessage(Chief.Game.Character.Id, Chief.Game.Fight.FightId));
            }
        }

        private void Chief_FightIdReceived()
            => SignalMembersToJoinFight();

        #endregion

        #region Actions

        public void EnqueueActionToMembers(ScriptAction action, bool startDequeuingActions = false)
        {
            // Avoid enquing a FightAction to group members, since they will be joining the chief
            if (action is FightAction)
            {
                // We will also set the manual reset events so that the chief continues the script after the fight
                // Since the members don't get this action, ActionSFinished never gets fired
                for (int i = 0; i < Members.Count; i++)
                {
                    _membersAccountsFinished[Members[i]].Set();
                }

                return;
            }

            for (int i = 0; i < Members.Count; i++)
            {
                Members[i].Scripts.ActionsManager.EnqueueAction(action, startDequeuingActions);
            }

            // Reset all the ManualResetEvents of the members if this action will start dequeuing actions
            if (startDequeuingActions)
            {
                for (int i = 0; i < Members.Count; i++)
                {
                    _membersAccountsFinished[Members[i]].Reset();
                }
            }
        }

        public void WaitForAllActionsFinished()
            => WaitHandle.WaitAll(_membersAccountsFinished.Values.ToArray());

        private void Member_ActionsFinished(Account account, bool mapChanged)
        {
            account.Logger.LogDebug("Group", "I finished my actions.");
            _membersAccountsFinished[account].Set();
        }

        #endregion

        private async void Account_RecaptchaResolved(Account account, bool success)
        {
            if (!success)
                return;

            // Check if this was the last member that got the captcha
            // If yes, we need to re-start the script
            if (IsAnyoneBusy())
                return;

            await Task.Delay(2000);
            Chief.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("481"));
            Chief.Scripts.StartScript();
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _grouping.Dispose();
                    Chief.Dispose();

                    for (int i = 0; i < Members.Count; i++)
                    {
                        Members[i].Dispose();
                    }
                }

                _grouping = null;
                _membersAccountsFinished.Clear();
                _membersAccountsFinished = null;
                Members.Clear();
                Members = null;
                Chief = null;

                _disposedValue = true;
            }
        }

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
