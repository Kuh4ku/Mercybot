using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DisplayNumericalValueMessage : Message
	{

		// Properties
		public int EntityId { get; set; }
		public int Value { get; set; }
		public uint Type { get; set; }


		// Constructors
		public DisplayNumericalValueMessage() { }

		public DisplayNumericalValueMessage(int entityId = 0, int value = 0, uint type = 0)
		{
			EntityId = entityId;
			Value = value;
			Type = type;
		}

	}
}
