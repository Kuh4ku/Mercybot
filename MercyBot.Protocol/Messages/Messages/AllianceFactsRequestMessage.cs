using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceFactsRequestMessage : Message
	{

		// Properties
		public uint AllianceId { get; set; }


		// Constructors
		public AllianceFactsRequestMessage() { }

		public AllianceFactsRequestMessage(uint allianceId = 0)
		{
			AllianceId = allianceId;
		}

	}
}
