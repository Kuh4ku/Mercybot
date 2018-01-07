using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CompassResetMessage : Message
	{

		// Properties
		public uint Type { get; set; }


		// Constructors
		public CompassResetMessage() { }

		public CompassResetMessage(uint type = 0)
		{
			Type = type;
		}

	}
}
