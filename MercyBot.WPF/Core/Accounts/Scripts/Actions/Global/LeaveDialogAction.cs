using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Global
{
    public class LeaveDialogAction : ScriptAction
    {

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (account.IsInDialog())
            {
                account.Network.SendMessage(new LeaveDialogRequestMessage());
                return ProcessingResult;
            }

            return DoneResult;
        }

    }
}
