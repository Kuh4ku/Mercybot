using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class OrnamentGainedMessage : Message
	{

		// Properties
		public uint OrnamentId { get; set; }


		// Constructors
		public OrnamentGainedMessage() { }

		public OrnamentGainedMessage(uint ornamentId = 0)
		{
			OrnamentId = ornamentId;
		}

	}
}
