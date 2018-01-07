using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapRunningFightDetailsRequestMessage : Message
	{

		// Properties
		public uint FightId { get; set; }


		// Constructors
		public MapRunningFightDetailsRequestMessage() { }

		public MapRunningFightDetailsRequestMessage(uint fightId = 0)
		{
			FightId = fightId;
		}

	}
}
