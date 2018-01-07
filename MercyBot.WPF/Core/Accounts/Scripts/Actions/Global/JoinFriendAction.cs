using System.Threading.Tasks;
using MercyBot.Protocol.Messages;

namespace MercyBot.Core.Accounts.Scripts.Actions.Global
{
    public class JoinFriendAction : ScriptAction
    {

        // Properties
        public string Name { get; private set; }



        // Constructor
        public JoinFriendAction(string name)
        {
            Name = name;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (account.IsBusy)
                return FailedResult;

            account.Network.SendMessage(new FriendJoinRequestMessage(Name));
            return DoneResult;
        }

    }
}
