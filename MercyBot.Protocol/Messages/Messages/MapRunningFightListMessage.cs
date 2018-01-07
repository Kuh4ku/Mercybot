using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapRunningFightListMessage : Message
	{

		// Properties
		public List<FightExternalInformations> Fights { get; set; }


		// Constructors
		public MapRunningFightListMessage() { }

		public MapRunningFightListMessage(List<FightExternalInformations> fights = null)
		{
			Fights = fights;
		}

	}
}
