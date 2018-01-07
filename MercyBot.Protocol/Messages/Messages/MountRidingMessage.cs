using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountRidingMessage : Message
	{

		// Properties
		public bool IsRiding { get; set; }


		// Constructors
		public MountRidingMessage() { }

		public MountRidingMessage(bool isRiding = false)
		{
			IsRiding = isRiding;
		}

	}
}
