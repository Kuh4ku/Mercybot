using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismAlignmentBonusResultMessage : Message
	{

		// Properties
		public AlignmentBonusInformations AlignmentBonus { get; set; }


		// Constructors
		public PrismAlignmentBonusResultMessage() { }

		public PrismAlignmentBonusResultMessage(AlignmentBonusInformations alignmentBonus = null)
		{
			AlignmentBonus = alignmentBonus;
		}

	}
}
