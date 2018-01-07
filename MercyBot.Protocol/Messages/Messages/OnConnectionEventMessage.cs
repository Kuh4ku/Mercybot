using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class OnConnectionEventMessage : Message
	{

		// Properties
		public uint EventType { get; set; }


		// Constructors
		public OnConnectionEventMessage() { }

		public OnConnectionEventMessage(uint eventType = 0)
		{
			EventType = eventType;
		}

	}
}
