using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class MountClientData
	{

		// Properties
		public List<uint> Ancestor { get; set; }
		public List<uint> Behaviors { get; set; }
		public List<ObjectEffectInteger> EffectList { get; set; }
		public double Id { get; set; }
		public uint Model { get; set; }
		public string Name { get; set; }
		public bool Sex { get; set; }
		public uint OwnerId { get; set; }
		public double Experience { get; set; }
		public double ExperienceForLevel { get; set; }
		public double ExperienceForNextLevel { get; set; }
		public uint Level { get; set; }
		public bool IsRideable { get; set; }
		public uint MaxPods { get; set; }
		public bool IsWild { get; set; }
		public uint Stamina { get; set; }
		public uint StaminaMax { get; set; }
		public uint Maturity { get; set; }
		public uint MaturityForAdult { get; set; }
		public uint Energy { get; set; }
		public uint EnergyMax { get; set; }
		public int Serenity { get; set; }
		public int AggressivityMax { get; set; }
		public uint SerenityMax { get; set; }
		public uint Love { get; set; }
		public uint LoveMax { get; set; }
		public int FecondationTime { get; set; }
		public bool IsFecondationReady { get; set; }
		public uint BoostLimiter { get; set; }
		public double BoostMax { get; set; }
		public int ReproductionCount { get; set; }
		public uint ReproductionCountMax { get; set; }


		// Constructors
		public MountClientData() { }

		public MountClientData(double id = 0, uint model = 0, string name = "", bool sex = false, uint ownerId = 0, double experience = 0, double experienceForLevel = 0, double experienceForNextLevel = 0, uint level = 0, bool isRideable = false, uint maxPods = 0, bool isWild = false, uint stamina = 0, uint staminaMax = 0, uint maturity = 0, uint maturityForAdult = 0, uint energy = 0, uint energyMax = 0, int serenity = 0, int aggressivityMax = 0, uint serenityMax = 0, uint love = 0, uint loveMax = 0, int fecondationTime = 0, bool isFecondationReady = false, uint boostLimiter = 0, double boostMax = 0, int reproductionCount = 0, uint reproductionCountMax = 0, List<uint> ancestor = null, List<uint> behaviors = null, List<ObjectEffectInteger> effectList = null)
		{
			Id = id;
			Model = model;
			Name = name;
			Sex = sex;
			OwnerId = ownerId;
			Experience = experience;
			ExperienceForLevel = experienceForLevel;
			ExperienceForNextLevel = experienceForNextLevel;
			Level = level;
			IsRideable = isRideable;
			MaxPods = maxPods;
			IsWild = isWild;
			Stamina = stamina;
			StaminaMax = staminaMax;
			Maturity = maturity;
			MaturityForAdult = maturityForAdult;
			Energy = energy;
			EnergyMax = energyMax;
			Serenity = serenity;
			AggressivityMax = aggressivityMax;
			SerenityMax = serenityMax;
			Love = love;
			LoveMax = loveMax;
			FecondationTime = fecondationTime;
			IsFecondationReady = isFecondationReady;
			BoostLimiter = boostLimiter;
			BoostMax = boostMax;
			ReproductionCount = reproductionCount;
			ReproductionCountMax = reproductionCountMax;
			Ancestor = ancestor;
			Behaviors = behaviors;
			EffectList = effectList;
		}

	}
}
