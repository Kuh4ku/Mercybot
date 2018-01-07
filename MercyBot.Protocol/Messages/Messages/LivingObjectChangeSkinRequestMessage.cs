using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LivingObjectChangeSkinRequestMessage : Message
	{

		// Properties
		public uint LivingUID { get; set; }
		public uint LivingPosition { get; set; }
		public uint SkinId { get; set; }


		// Constructors
		public LivingObjectChangeSkinRequestMessage() { }

		public LivingObjectChangeSkinRequestMessage(uint livingUID = 0, uint livingPosition = 0, uint skinId = 0)
		{
			LivingUID = livingUID;
			LivingPosition = livingPosition;
			SkinId = skinId;
		}

	}
}
