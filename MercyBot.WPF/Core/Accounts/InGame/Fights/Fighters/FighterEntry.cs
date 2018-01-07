using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;
using System.Linq;

namespace MercyBot.Core.Accounts.InGame.Fights.Fighters
{
    public class FighterEntry
    {

        // Properties
        public int ContextualId { get; private set; }
        public bool Alive { get; private set; }
        public short CellId { get; private set; }
        public TeamEnum Team { get; private set; }
        public GameFightMinimalStats Stats { get; private set; }
        public int LifePoints { get; private set; }
        public int MaxLifePoints { get; private set; }
        public int ActionPoints { get; private set; }
        public int MovementPoints { get; private set; }

        public int LifePercent => (int)((double)LifePoints / MaxLifePoints) / 100;


        // Constructor
        public FighterEntry(GameFightFighterInformations infos)
        {
            Update(infos);
        }


        public string GetName()
        {
            if (this is FightMonsterEntry fme)
                return fme.Name;
            else
                return (this as FightPlayerEntry).Name;
        }

        #region Updates

        public void Update(IdentifiedEntityDispositionInformations infos)
        {
            CellId = (short)infos.CellId;
        }

        public void Update(GameFightFighterInformations infos)
        {
            ContextualId = infos.ContextualId;
            Alive = infos.Alive;
            CellId = (short)infos.Disposition.CellId;
            Team = (TeamEnum)infos.TeamId;
            Stats = infos.Stats;
            LifePoints = (int)Stats.LifePoints;
            MaxLifePoints = (int)Stats.MaxLifePoints;
            ActionPoints = Stats.ActionPoints;
            MovementPoints = Stats.MovementPoints;
        }

        public void Update(CharacterCharacteristicsInformations stats)
        {
            LifePoints = (int)stats.LifePoints;
            MaxLifePoints = (int)stats.MaxLifePoints;
            ActionPoints = stats.ActionPointsCurrent;
            MovementPoints = stats.MovementPointsCurrent;
        }

        public void Update(GameActionFightPointsVariationMessage message)
        {
            switch (message.ActionId)
            {
                case 101:
                case 102:
                case 120:
                    ActionPoints += message.Delta;
                    break;
                case 78:
                case 127:
                case 129:
                case 77:
                    MovementPoints += message.Delta;
                    break;
            }
        }

        public void Update(GameActionFightDeathMessage message)
        {
            LifePoints = 0;
            Alive = false;
        }

        public void Update(GameMapMovementMessage message)
        {
            CellId = (short)message.KeyMovements.Last();
        }

        public void Update(GameActionFightTeleportOnSameMapMessage message)
        {
            CellId = (short)message.CellId;
        }

        public void Update(GameActionFightSlideMessage message)
        {
            CellId = (short)message.EndCellId;
        }

        public void Update(GameActionFightLifePointsLostMessage message)
        {
            LifePoints -= (int)message.Loss;
            MaxLifePoints -= (int)message.PermanentDamages;
        }

        public void Update(GameActionFightLifePointsGainMessage message)
        {
            LifePoints += (int)message.Delta;
            if (LifePoints > MaxLifePoints)
            {
                LifePoints = MaxLifePoints;
            }
        }

        public void Update(GameFightTurnEndMessage message)
        {
            MovementPoints = Stats.MovementPoints;
            ActionPoints = Stats.ActionPoints;
        }

        public void Update(uint actionId, FightTemporaryBoostEffect ftbe)
        {
            if (actionId == 168)
                ActionPoints -= ftbe.Delta;
            else if (actionId == 169)
                MovementPoints -= ftbe.Delta;
        }

        #endregion

    }
}
