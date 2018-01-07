using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
	{

		// Properties
		public uint Honor { get; set; }
		public uint HonorGradeFloor { get; set; }
		public uint HonorNextGradeFloor { get; set; }
		public uint Aggressable { get; set; }


		// Constructors
		public ActorExtendedAlignmentInformations() { }

		public ActorExtendedAlignmentInformations(int alignmentSide = 0, uint alignmentValue = 0, uint alignmentGrade = 0, uint characterPower = 0, uint honor = 0, uint honorGradeFloor = 0, uint honorNextGradeFloor = 0, uint aggressable = 0)
		{
			AlignmentSide = alignmentSide;
			AlignmentValue = alignmentValue;
			AlignmentGrade = alignmentGrade;
			CharacterPower = characterPower;
			Honor = honor;
			HonorGradeFloor = honorGradeFloor;
			HonorNextGradeFloor = honorNextGradeFloor;
			Aggressable = aggressable;
		}

	}
}
