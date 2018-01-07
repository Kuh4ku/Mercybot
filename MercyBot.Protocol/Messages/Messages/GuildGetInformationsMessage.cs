using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildGetInformationsMessage : Message
	{

		// Properties
		public uint InfoType { get; set; }


		// Constructors
		public GuildGetInformationsMessage() { }

		public GuildGetInformationsMessage(uint infoType = 0)
		{
			InfoType = infoType;
		}

	}
}
