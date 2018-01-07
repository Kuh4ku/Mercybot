using MercyBot.Core.Accounts.InGame.Managers.Movements;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Scripts.Actions.Fight
{
    public class FightAction : ScriptAction
    {

        // Properties
        public int MinMonsters { get; private set; }
        public int MaxMonsters { get; private set; }
        public int MinMonstersLevel { get; private set; }
        public int MaxMonstersLevel { get; private set; }
        public List<int> ForbiddenMonsters { get; private set; }
        public List<int> MandatoryMonsters { get; private set; }


        // Constructor
        public FightAction(int minMonsters, int maxMonsters, int minMonstersLevel, int maxMonstersLevel, List<int> forbiddenMonsters, List<int> mandatoryMonsters)
        {
            MinMonsters = minMonsters;
            MaxMonsters = maxMonsters;
            MinMonstersLevel = minMonstersLevel;
            MaxMonstersLevel = maxMonstersLevel;
            ForbiddenMonsters = forbiddenMonsters;
            MandatoryMonsters = mandatoryMonsters;
        }


        internal override Task<ScriptActionResults> Process(Account account)
        {
            var availableGroups = account.Game.Map.GetMonstersGroup(MinMonsters, MaxMonsters, MinMonstersLevel, MaxMonstersLevel, ForbiddenMonsters, MandatoryMonsters);

            if (availableGroups.Count <= 0)
                return DoneResult;

            for (int i = 0; i < availableGroups.Count; i++)
            {
                if (account.Game.Map.BlacklistedMonsters.Contains(availableGroups[i].Id))
                    continue;

                switch (account.Game.Managers.Movements.MoveToCell(availableGroups[i].CellId))
                {
                    case MovementRequestResults.MOVED:
                        account.Scripts.ActionsManager.MonstersGroupToAttack = availableGroups[i].Id;
                        account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("166", availableGroups[i].CellId, availableGroups[i].MonstersCount, availableGroups[i].TotalLevel));
                        return ProcessingResult;
                    case MovementRequestResults.ALREADY_THERE:
                    case MovementRequestResults.PATH_BLOCKED:
                        account.Logger.LogWarning(LanguageManager.Translate("165"), LanguageManager.Translate("167"));
                        account.Game.Map.BlacklistedMonsters.Add(availableGroups[i].Id);
                        continue;
                    default: // FAILED
                        account.Scripts.StopScript(LanguageManager.Translate("168"));
                        return FailedResult;
                }
            }

            return DoneResult;
        }

    }
}
