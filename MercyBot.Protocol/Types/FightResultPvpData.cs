using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultPvpData : FightResultAdditionalData
	{

		// Properties
		public uint Grade { get; set; }
		public uint MinHonorForGrade { get; set; }
		public uint MaxHonorForGrade { get; set; }
		public uint Honor { get; set; }
		public int HonorDelta { get; set; }


		// Constructors
		public FightResultPvpData() { }

		public FightResultPvpData(uint grade = 0, uint minHonorForGrade = 0, uint maxHonorForGrade = 0, uint honor = 0, int honorDelta = 0)
		{
			Grade = grade;
			MinHonorForGrade = minHonorForGrade;
			MaxHonorForGrade = maxHonorForGrade;
			Honor = honor;
			HonorDelta = honorDelta;
		}

	}
}
