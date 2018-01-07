using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceFactsErrorMessage : Message
	{

		// Properties
		public uint AllianceId { get; set; }


		// Constructors
		public AllianceFactsErrorMessage() { }

		public AllianceFactsErrorMessage(uint allianceId = 0)
		{
			AllianceId = allianceId;
		}

	}
}
