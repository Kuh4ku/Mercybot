using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AlliancePartialListMessage : AllianceListMessage
	{

		// Constructors
		public AlliancePartialListMessage() { }

		public AlliancePartialListMessage(List<AllianceFactSheetInformations> alliances = null)
		{
			Alliances = alliances;
		}

	}
}
