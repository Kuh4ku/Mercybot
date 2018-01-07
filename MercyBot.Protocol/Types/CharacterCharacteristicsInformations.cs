using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterCharacteristicsInformations
	{

		// Properties
		public List<CharacterSpellModification> SpellModifications { get; set; }
		public double Experience { get; set; }
		public double ExperienceLevelFloor { get; set; }
		public double ExperienceNextLevelFloor { get; set; }
		public uint Kamas { get; set; }
		public uint StatsPoints { get; set; }
		public uint SpellsPoints { get; set; }
		public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }
		public uint LifePoints { get; set; }
		public uint MaxLifePoints { get; set; }
		public uint EnergyPoints { get; set; }
		public uint MaxEnergyPoints { get; set; }
		public int ActionPointsCurrent { get; set; }
		public int MovementPointsCurrent { get; set; }
		public CharacterBaseCharacteristic Initiative { get; set; }
		public CharacterBaseCharacteristic Prospecting { get; set; }
		public CharacterBaseCharacteristic ActionPoints { get; set; }
		public CharacterBaseCharacteristic MovementPoints { get; set; }
		public CharacterBaseCharacteristic Strength { get; set; }
		public CharacterBaseCharacteristic Vitality { get; set; }
		public CharacterBaseCharacteristic Wisdom { get; set; }
		public CharacterBaseCharacteristic Chance { get; set; }
		public CharacterBaseCharacteristic Agility { get; set; }
		public CharacterBaseCharacteristic Intelligence { get; set; }
		public CharacterBaseCharacteristic Range { get; set; }
		public CharacterBaseCharacteristic SummonableCreaturesBoost { get; set; }
		public CharacterBaseCharacteristic Reflect { get; set; }
		public CharacterBaseCharacteristic CriticalHit { get; set; }
		public uint CriticalHitWeapon { get; set; }
		public CharacterBaseCharacteristic CriticalMiss { get; set; }
		public CharacterBaseCharacteristic HealBonus { get; set; }
		public CharacterBaseCharacteristic AllDamagesBonus { get; set; }
		public CharacterBaseCharacteristic WeaponDamagesBonusPercent { get; set; }
		public CharacterBaseCharacteristic DamagesBonusPercent { get; set; }
		public CharacterBaseCharacteristic TrapBonus { get; set; }
		public CharacterBaseCharacteristic TrapBonusPercent { get; set; }
		public CharacterBaseCharacteristic GlyphBonusPercent { get; set; }
		public CharacterBaseCharacteristic PermanentDamagePercent { get; set; }
		public CharacterBaseCharacteristic TackleBlock { get; set; }
		public CharacterBaseCharacteristic TackleEvade { get; set; }
		public CharacterBaseCharacteristic PAAttack { get; set; }
		public CharacterBaseCharacteristic PMAttack { get; set; }
		public CharacterBaseCharacteristic PushDamageBonus { get; set; }
		public CharacterBaseCharacteristic CriticalDamageBonus { get; set; }
		public CharacterBaseCharacteristic NeutralDamageBonus { get; set; }
		public CharacterBaseCharacteristic EarthDamageBonus { get; set; }
		public CharacterBaseCharacteristic WaterDamageBonus { get; set; }
		public CharacterBaseCharacteristic AirDamageBonus { get; set; }
		public CharacterBaseCharacteristic FireDamageBonus { get; set; }
		public CharacterBaseCharacteristic DodgePALostProbability { get; set; }
		public CharacterBaseCharacteristic DodgePMLostProbability { get; set; }
		public CharacterBaseCharacteristic NeutralElementResistPercent { get; set; }
		public CharacterBaseCharacteristic EarthElementResistPercent { get; set; }
		public CharacterBaseCharacteristic WaterElementResistPercent { get; set; }
		public CharacterBaseCharacteristic AirElementResistPercent { get; set; }
		public CharacterBaseCharacteristic FireElementResistPercent { get; set; }
		public CharacterBaseCharacteristic NeutralElementReduction { get; set; }
		public CharacterBaseCharacteristic EarthElementReduction { get; set; }
		public CharacterBaseCharacteristic WaterElementReduction { get; set; }
		public CharacterBaseCharacteristic AirElementReduction { get; set; }
		public CharacterBaseCharacteristic FireElementReduction { get; set; }
		public CharacterBaseCharacteristic PushDamageReduction { get; set; }
		public CharacterBaseCharacteristic CriticalDamageReduction { get; set; }
		public CharacterBaseCharacteristic PvpNeutralElementResistPercent { get; set; }
		public CharacterBaseCharacteristic PvpEarthElementResistPercent { get; set; }
		public CharacterBaseCharacteristic PvpWaterElementResistPercent { get; set; }
		public CharacterBaseCharacteristic PvpAirElementResistPercent { get; set; }
		public CharacterBaseCharacteristic PvpFireElementResistPercent { get; set; }
		public CharacterBaseCharacteristic PvpNeutralElementReduction { get; set; }
		public CharacterBaseCharacteristic PvpEarthElementReduction { get; set; }
		public CharacterBaseCharacteristic PvpWaterElementReduction { get; set; }
		public CharacterBaseCharacteristic PvpAirElementReduction { get; set; }
		public CharacterBaseCharacteristic PvpFireElementReduction { get; set; }
		public uint ProbationTime { get; set; }


		// Constructors
		public CharacterCharacteristicsInformations() { }

		public CharacterCharacteristicsInformations(double experience = 0, double experienceLevelFloor = 0, double experienceNextLevelFloor = 0, uint kamas = 0, uint statsPoints = 0, uint spellsPoints = 0, ActorExtendedAlignmentInformations alignmentInfos = null, uint lifePoints = 0, uint maxLifePoints = 0, uint energyPoints = 0, uint maxEnergyPoints = 0, int actionPointsCurrent = 0, int movementPointsCurrent = 0, CharacterBaseCharacteristic initiative = null, CharacterBaseCharacteristic prospecting = null, CharacterBaseCharacteristic actionPoints = null, CharacterBaseCharacteristic movementPoints = null, CharacterBaseCharacteristic strength = null, CharacterBaseCharacteristic vitality = null, CharacterBaseCharacteristic wisdom = null, CharacterBaseCharacteristic chance = null, CharacterBaseCharacteristic agility = null, CharacterBaseCharacteristic intelligence = null, CharacterBaseCharacteristic range = null, CharacterBaseCharacteristic summonableCreaturesBoost = null, CharacterBaseCharacteristic reflect = null, CharacterBaseCharacteristic criticalHit = null, uint criticalHitWeapon = 0, CharacterBaseCharacteristic criticalMiss = null, CharacterBaseCharacteristic healBonus = null, CharacterBaseCharacteristic allDamagesBonus = null, CharacterBaseCharacteristic weaponDamagesBonusPercent = null, CharacterBaseCharacteristic damagesBonusPercent = null, CharacterBaseCharacteristic trapBonus = null, CharacterBaseCharacteristic trapBonusPercent = null, CharacterBaseCharacteristic glyphBonusPercent = null, CharacterBaseCharacteristic permanentDamagePercent = null, CharacterBaseCharacteristic tackleBlock = null, CharacterBaseCharacteristic tackleEvade = null, CharacterBaseCharacteristic pAAttack = null, CharacterBaseCharacteristic pMAttack = null, CharacterBaseCharacteristic pushDamageBonus = null, CharacterBaseCharacteristic criticalDamageBonus = null, CharacterBaseCharacteristic neutralDamageBonus = null, CharacterBaseCharacteristic earthDamageBonus = null, CharacterBaseCharacteristic waterDamageBonus = null, CharacterBaseCharacteristic airDamageBonus = null, CharacterBaseCharacteristic fireDamageBonus = null, CharacterBaseCharacteristic dodgePALostProbability = null, CharacterBaseCharacteristic dodgePMLostProbability = null, CharacterBaseCharacteristic neutralElementResistPercent = null, CharacterBaseCharacteristic earthElementResistPercent = null, CharacterBaseCharacteristic waterElementResistPercent = null, CharacterBaseCharacteristic airElementResistPercent = null, CharacterBaseCharacteristic fireElementResistPercent = null, CharacterBaseCharacteristic neutralElementReduction = null, CharacterBaseCharacteristic earthElementReduction = null, CharacterBaseCharacteristic waterElementReduction = null, CharacterBaseCharacteristic airElementReduction = null, CharacterBaseCharacteristic fireElementReduction = null, CharacterBaseCharacteristic pushDamageReduction = null, CharacterBaseCharacteristic criticalDamageReduction = null, CharacterBaseCharacteristic pvpNeutralElementResistPercent = null, CharacterBaseCharacteristic pvpEarthElementResistPercent = null, CharacterBaseCharacteristic pvpWaterElementResistPercent = null, CharacterBaseCharacteristic pvpAirElementResistPercent = null, CharacterBaseCharacteristic pvpFireElementResistPercent = null, CharacterBaseCharacteristic pvpNeutralElementReduction = null, CharacterBaseCharacteristic pvpEarthElementReduction = null, CharacterBaseCharacteristic pvpWaterElementReduction = null, CharacterBaseCharacteristic pvpAirElementReduction = null, CharacterBaseCharacteristic pvpFireElementReduction = null, uint probationTime = 0, List<CharacterSpellModification> spellModifications = null)
		{
			Experience = experience;
			ExperienceLevelFloor = experienceLevelFloor;
			ExperienceNextLevelFloor = experienceNextLevelFloor;
			Kamas = kamas;
			StatsPoints = statsPoints;
			SpellsPoints = spellsPoints;
			AlignmentInfos = alignmentInfos;
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			EnergyPoints = energyPoints;
			MaxEnergyPoints = maxEnergyPoints;
			ActionPointsCurrent = actionPointsCurrent;
			MovementPointsCurrent = movementPointsCurrent;
			Initiative = initiative;
			Prospecting = prospecting;
			ActionPoints = actionPoints;
			MovementPoints = movementPoints;
			Strength = strength;
			Vitality = vitality;
			Wisdom = wisdom;
			Chance = chance;
			Agility = agility;
			Intelligence = intelligence;
			Range = range;
			SummonableCreaturesBoost = summonableCreaturesBoost;
			Reflect = reflect;
			CriticalHit = criticalHit;
			CriticalHitWeapon = criticalHitWeapon;
			CriticalMiss = criticalMiss;
			HealBonus = healBonus;
			AllDamagesBonus = allDamagesBonus;
			WeaponDamagesBonusPercent = weaponDamagesBonusPercent;
			DamagesBonusPercent = damagesBonusPercent;
			TrapBonus = trapBonus;
			TrapBonusPercent = trapBonusPercent;
			GlyphBonusPercent = glyphBonusPercent;
			PermanentDamagePercent = permanentDamagePercent;
			TackleBlock = tackleBlock;
			TackleEvade = tackleEvade;
			PAAttack = pAAttack;
			PMAttack = pMAttack;
			PushDamageBonus = pushDamageBonus;
			CriticalDamageBonus = criticalDamageBonus;
			NeutralDamageBonus = neutralDamageBonus;
			EarthDamageBonus = earthDamageBonus;
			WaterDamageBonus = waterDamageBonus;
			AirDamageBonus = airDamageBonus;
			FireDamageBonus = fireDamageBonus;
			DodgePALostProbability = dodgePALostProbability;
			DodgePMLostProbability = dodgePMLostProbability;
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
			PushDamageReduction = pushDamageReduction;
			CriticalDamageReduction = criticalDamageReduction;
			PvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
			PvpEarthElementResistPercent = pvpEarthElementResistPercent;
			PvpWaterElementResistPercent = pvpWaterElementResistPercent;
			PvpAirElementResistPercent = pvpAirElementResistPercent;
			PvpFireElementResistPercent = pvpFireElementResistPercent;
			PvpNeutralElementReduction = pvpNeutralElementReduction;
			PvpEarthElementReduction = pvpEarthElementReduction;
			PvpWaterElementReduction = pvpWaterElementReduction;
			PvpAirElementReduction = pvpAirElementReduction;
			PvpFireElementReduction = pvpFireElementReduction;
			ProbationTime = probationTime;
			SpellModifications = spellModifications;
		}

	}
}
