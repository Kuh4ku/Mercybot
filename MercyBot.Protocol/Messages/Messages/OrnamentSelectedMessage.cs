using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class OrnamentSelectedMessage : Message
	{

		// Properties
		public uint OrnamentId { get; set; }


		// Constructors
		public OrnamentSelectedMessage() { }

		public OrnamentSelectedMessage(uint ornamentId = 0)
		{
			OrnamentId = ornamentId;
		}

	}
}
