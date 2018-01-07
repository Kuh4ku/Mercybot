using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectMovementMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }
		public uint Position { get; set; }


		// Constructors
		public ObjectMovementMessage() { }

		public ObjectMovementMessage(uint objectUID = 0, uint position = 63)
		{
			ObjectUID = objectUID;
			Position = position;
		}

	}
}
