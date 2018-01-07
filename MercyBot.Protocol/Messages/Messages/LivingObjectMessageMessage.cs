using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LivingObjectMessageMessage : Message
	{

		// Properties
		public uint MsgId { get; set; }
		public uint TimeStamp { get; set; }
		public string Owner { get; set; }
		public uint ObjectGenericId { get; set; }


		// Constructors
		public LivingObjectMessageMessage() { }

		public LivingObjectMessageMessage(uint msgId = 0, uint timeStamp = 0, string owner = "", uint objectGenericId = 0)
		{
			MsgId = msgId;
			TimeStamp = timeStamp;
			Owner = owner;
			ObjectGenericId = objectGenericId;
		}

	}
}
