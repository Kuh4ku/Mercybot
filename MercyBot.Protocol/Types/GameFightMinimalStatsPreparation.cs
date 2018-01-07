using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightMinimalStatsPreparation : GameFightMinimalStats
	{

		// Properties
		public uint Initiative { get; set; }


		// Constructors
		public GameFightMinimalStatsPreparation() { }

		public GameFightMinimalStatsPreparation(uint lifePoints = 0, uint maxLifePoints = 0, uint baseMaxLifePoints = 0, uint permanentDamagePercent = 0, uint shieldPoints = 0, int actionPoints = 0, int maxActionPoints = 0, int movementPoints = 0, int maxMovementPoints = 0, int summoner = 0, bool summoned = false, int neutralElementResistPercent = 0, int earthElementResistPercent = 0, int waterElementResistPercent = 0, int airElementResistPercent = 0, int fireElementResistPercent = 0, int neutralElementReduction = 0, int earthElementReduction = 0, int waterElementReduction = 0, int airElementReduction = 0, int fireElementReduction = 0, int criticalDamageFixedResist = 0, int pushDamageFixedResist = 0, uint dodgePALostProbability = 0, uint dodgePMLostProbability = 0, int tackleBlock = 0, int tackleEvade = 0, int invisibilityState = 0, uint initiative = 0)
		{
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			BaseMaxLifePoints = baseMaxLifePoints;
			PermanentDamagePercent = permanentDamagePercent;
			ShieldPoints = shieldPoints;
			ActionPoints = actionPoints;
			MaxActionPoints = maxActionPoints;
			MovementPoints = movementPoints;
			MaxMovementPoints = maxMovementPoints;
			Summoner = summoner;
			Summoned = summoned;
			NeutralElementResistPercent = neutralElementResistPercent;
			EarthElementResistPercent = earthElementResistPercent;
			WaterElementResistPercent = waterElementResistPercent;
			AirElementResistPercent = airElementResistPercent;
			FireElementResistPercent = fireElementResistPercent;
			NeutralElementReduction = neutralElementReduction;
			EarthElementReduction = earthElementReduction;
			WaterElementReduction = waterElementReduction;
			AirElementReduction = airElementReduction;
			FireElementReduction = fireElementReduction;
			CriticalDamageFixedResist = criticalDamageFixedResist;
			PushDamageFixedResist = pushDamageFixedResist;
			DodgePALostProbability = dodgePALostProbability;
			DodgePMLostProbability = dodgePMLostProbability;
			TackleBlock = tackleBlock;
			TackleEvade = tackleEvade;
			InvisibilityState = invisibilityState;
			Initiative = initiative;
		}

	}
}
