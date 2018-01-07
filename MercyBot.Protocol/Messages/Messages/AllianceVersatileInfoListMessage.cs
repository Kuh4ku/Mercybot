using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceVersatileInfoListMessage : Message
	{

		// Properties
		public List<AllianceVersatileInformations> Alliances { get; set; }


		// Constructors
		public AllianceVersatileInfoListMessage() { }

		public AllianceVersatileInfoListMessage(List<AllianceVersatileInformations> alliances = null)
		{
			Alliances = alliances;
		}

	}
}
