using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectGroundRemovedMessage : Message
	{

		// Properties
		public uint Cell { get; set; }


		// Constructors
		public ObjectGroundRemovedMessage() { }

		public ObjectGroundRemovedMessage(uint cell = 0)
		{
			Cell = cell;
		}

	}
}
