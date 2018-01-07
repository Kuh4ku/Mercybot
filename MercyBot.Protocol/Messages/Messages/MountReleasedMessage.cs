using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountReleasedMessage : Message
	{

		// Properties
		public double MountId { get; set; }


		// Constructors
		public MountReleasedMessage() { }

		public MountReleasedMessage(double mountId = 0)
		{
			MountId = mountId;
		}

	}
}
