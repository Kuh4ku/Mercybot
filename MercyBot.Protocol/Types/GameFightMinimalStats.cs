using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightMinimalStats
	{

		// Properties
		public uint LifePoints { get; set; }
		public uint MaxLifePoints { get; set; }
		public uint BaseMaxLifePoints { get; set; }
		public uint PermanentDamagePercent { get; set; }
		public uint ShieldPoints { get; set; }
		public int ActionPoints { get; set; }
		public int MaxActionPoints { get; set; }
		public int MovementPoints { get; set; }
		public int MaxMovementPoints { get; set; }
		public int Summoner { get; set; }
		public bool Summoned { get; set; }
		public int NeutralElementResistPercent { get; set; }
		public int EarthElementResistPercent { get; set; }
		public int WaterElementResistPercent { get; set; }
		public int AirElementResistPercent { get; set; }
		public int FireElementResistPercent { get; set; }
		public int NeutralElementReduction { get; set; }
		public int EarthElementReduction { get; set; }
		public int WaterElementReduction { get; set; }
		public int AirElementReduction { get; set; }
		public int FireElementReduction { get; set; }
		public int CriticalDamageFixedResist { get; set; }
		public int PushDamageFixedResist { get; set; }
		public uint DodgePALostProbability { get; set; }
		public uint DodgePMLostProbability { get; set; }
		public int TackleBlock { get; set; }
		public int TackleEvade { get; set; }
		public int InvisibilityState { get; set; }


		// Constructors
		public GameFightMinimalStats() { }

		public GameFightMinimalStats(uint lifePoints = 0, uint maxLifePoints = 0, uint baseMaxLifePoints = 0, uint permanentDamagePercent = 0, uint shieldPoints = 0, int actionPoints = 0, int maxActionPoints = 0, int movementPoints = 0, int maxMovementPoints = 0, int summoner = 0, bool summoned = false, int neutralElementResistPercent = 0, int earthElementResistPercent = 0, int waterElementResistPercent = 0, int airElementResistPercent = 0, int fireElementResistPercent = 0, int neutralElementReduction = 0, int earthElementReduction = 0, int waterElementReduction = 0, int airElementReduction = 0, int fireElementReduction = 0, int criticalDamageFixedResist = 0, int pushDamageFixedResist = 0, uint dodgePALostProbability = 0, uint dodgePMLostProbability = 0, int tackleBlock = 0, int tackleEvade = 0, int invisibilityState = 0)
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
		}

	}
}
