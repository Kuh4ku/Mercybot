using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LivingObjectMessageRequestMessage : Message
	{

		// Properties
		public List<string> Parameters { get; set; }
		public uint MsgId { get; set; }
		public uint LivingObject { get; set; }


		// Constructors
		public LivingObjectMessageRequestMessage() { }

		public LivingObjectMessageRequestMessage(uint msgId = 0, uint livingObject = 0, List<string> parameters = null)
		{
			MsgId = msgId;
			LivingObject = livingObject;
			Parameters = parameters;
		}

	}
}
