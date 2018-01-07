using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Global
{
    public class DelayAction : ScriptAction
    {

        // Properties
        public int Milliseconds { get; private set; }


        // Constructor
        public DelayAction(int ms)
        {
            Milliseconds = ms;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            await Task.Delay(Milliseconds);
            return ScriptActionResults.DONE;
        }

    }
}
