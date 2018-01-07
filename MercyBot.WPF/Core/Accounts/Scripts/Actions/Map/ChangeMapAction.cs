using MercyBot.Core.Accounts.InGame.Managers.Movements;
using MercyBot.Utility;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using MercyBot.Core.Enums;

namespace MercyBot.Core.Accounts.Scripts.Actions.Map
{
    public class ChangeMapAction : ScriptAction
    {

        // Properties
        public MapChangeDirections Direction { get; private set; }
        public short CellId { get; private set; }

        public bool IsSpecificDirection => Direction != MapChangeDirections.NONE && CellId != -1;
        public bool IsSimpleDirection => Direction != MapChangeDirections.NONE && CellId == -1;


        // Constructor
        internal ChangeMapAction(MapChangeDirections direction, short cellId)
        {
            Direction = direction;
            CellId = cellId;
        }

        internal override Task<ScriptActionResults> Process(Account account)
        {
            if (IsSpecificDirection)
            {
                if (!account.Game.Managers.Movements.ChangeMap(Direction, CellId))
                {
                    account.Scripts.StopScript(LanguageManager.Translate("170", Direction.ToString().ToLower(), CellId));
                    return FailedResult;
                }

                account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("171", Direction.ToString().ToLower(), CellId));
            }
            else if (IsSimpleDirection)
            {
                if (!account.Game.Managers.Movements.ChangeMap(Direction))
                {
                    account.Scripts.StopScript(LanguageManager.Translate("172", Direction.ToString().ToLower()));
                    return FailedResult;
                }

                account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("173", Direction.ToString().ToLower()));
            }
            else // Move to a cell that will change the map
            {
                var result = account.Game.Managers.Movements.MoveToCell(CellId);

                if (result != MovementRequestResults.MOVED)
                {
                    account.Scripts.StopScript(LanguageManager.Translate("174", CellId, result));
                    return FailedResult;
                }

                account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("175", CellId));
            }

            return ProcessingResult;
        }

        public static bool TryParse(string text, out ChangeMapAction action)
        {
            string[] parts = text.Split('|');
            string randomPart = parts[Randomize.GetRandomInt(0, parts.Length)];

            // Specific direction
            Match m = Regex.Match(randomPart, @"(?<direction>top|haut|right|droite|bottom|bas|left|gauche)\((?<cellId>\d{1,3})\)");
            if (m.Success)
            {
                action = new ChangeMapAction((MapChangeDirections)Enum.Parse(typeof(MapChangeDirections), m.Groups["direction"].Value, true),
                    Convert.ToInt16(m.Groups["cellId"].Value));
                return true;
            }
            else
            {
                // Simple directions
                m = Regex.Match(randomPart, @"(?<direction>top|haut|right|droite|bottom|bas|left|gauche)");
                if (m.Success)
                {
                    action = new ChangeMapAction((MapChangeDirections)Enum.Parse(typeof(MapChangeDirections), m.Groups["direction"].Value, true),
                        -1);
                    return true;
                }
                else
                {
                    // Change maps from cells
                    m = Regex.Match(randomPart, @"(?<cellId>\d{1,3})");
                    if (m.Success)
                    {
                        action = new ChangeMapAction(MapChangeDirections.NONE, Convert.ToInt16(m.Groups["cellId"].Value));
                        return true;
                    }
                }
            }

            action = null;
            return false;
        }

    }
}