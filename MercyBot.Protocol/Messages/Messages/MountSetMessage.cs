using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountSetMessage : Message
	{

		// Properties
		public MountClientData MountData { get; set; }


		// Constructors
		public MountSetMessage() { }

		public MountSetMessage(MountClientData mountData = null)
		{
			MountData = mountData;
		}

	}
}
