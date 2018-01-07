using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LivingObjectDissociateMessage : Message
	{

		// Properties
		public uint LivingUID { get; set; }
		public uint LivingPosition { get; set; }


		// Constructors
		public LivingObjectDissociateMessage() { }

		public LivingObjectDissociateMessage(uint livingUID = 0, uint livingPosition = 0)
		{
			LivingUID = livingUID;
			LivingPosition = livingPosition;
		}

	}
}
