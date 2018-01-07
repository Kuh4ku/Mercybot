using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AtlasPointInformationsMessage : Message
	{

		// Properties
		public AtlasPointsInformations Type { get; set; }


		// Constructors
		public AtlasPointInformationsMessage() { }

		public AtlasPointInformationsMessage(AtlasPointsInformations type = null)
		{
			Type = type;
		}

	}
}
