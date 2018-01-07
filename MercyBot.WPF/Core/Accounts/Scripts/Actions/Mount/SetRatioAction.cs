using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Mount
{
    public class SetRatioAction : ScriptAction
    {

        // Properties
        public uint Ratio { get; private set; }


        // Constructor
        public SetRatioAction(uint ratio)
        {
            Ratio = ratio;
        }


        internal override async Task<ScriptActionResults> Process(Account account)
        {
            if (account.Game.Character.Mount.HasMount)
            {
                account.Game.Character.Mount.SetRatio(Ratio);
                await Task.Delay(400);
            }

            return ScriptActionResults.DONE;
        }

    }
}
