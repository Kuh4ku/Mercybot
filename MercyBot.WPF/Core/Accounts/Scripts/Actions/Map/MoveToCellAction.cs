using MercyBot.Core.Accounts.InGame.Managers.Movements;
using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class MoveToCellAction : ScriptAction
    {

        // Properties
        public short CellId { get; private set; }


        // Constructor
        public MoveToCellAction(short cellId)
        {
            CellId = cellId;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            switch (account.Game.Managers.Movements.MoveToCell(CellId))
            {
                case MovementRequestResults.MOVED:
                    return ProcessingResult;
                case MovementRequestResults.PATH_BLOCKED:
                case MovementRequestResults.ALREADY_THERE:
                    return DoneResult;
                default: // FAILED
                    return FailedResult;
            }
        }

    }
}
