using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ActorAlignmentInformations
	{

		// Properties
		public int AlignmentSide { get; set; }
		public uint AlignmentValue { get; set; }
		public uint AlignmentGrade { get; set; }
		public uint CharacterPower { get; set; }


		// Constructors
		public ActorAlignmentInformations() { }

		public ActorAlignmentInformations(int alignmentSide = 0, uint alignmentValue = 0, uint alignmentGrade = 0, uint characterPower = 0)
		{
			AlignmentSide = alignmentSide;
			AlignmentValue = alignmentValue;
			AlignmentGrade = alignmentGrade;
			CharacterPower = characterPower;
		}

	}
}
