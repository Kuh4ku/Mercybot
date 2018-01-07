using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapFightCountMessage : Message
	{

		// Properties
		public uint FightCount { get; set; }


		// Constructors
		public MapFightCountMessage() { }

		public MapFightCountMessage(uint fightCount = 0)
		{
			FightCount = fightCount;
		}

	}
}
