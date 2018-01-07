using MercyBot.Core.Accounts.InGame.Managers.Teleportables;
using MercyBot.Utility.Extensions;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class UseTeleportableAction : ScriptAction
    {

        // Properties
        public Teleportables Type { get; }
        public uint DestinationMapId { get; }


        // Constructor
        public UseTeleportableAction(Teleportables type, uint destinationMapId)
        {
            Type = type;
            DestinationMapId = destinationMapId;
        }

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if ((Type == Teleportables.ZAAP && !account.Game.Managers.Teleportables.UseZaap(DestinationMapId) ||
                Type == Teleportables.ZAAPI && !account.Game.Managers.Teleportables.UseZaapi(DestinationMapId)))
            {
                account.Scripts.StopScript(LanguageManager.Translate("540", Type.ToString().PureCapitalize()));
                return FailedResult;
            }

            return ProcessingResult;
        }

    }
}
