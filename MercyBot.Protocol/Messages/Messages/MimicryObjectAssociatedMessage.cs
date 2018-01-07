using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MimicryObjectAssociatedMessage : Message
	{

		// Properties
		public uint HostUID { get; set; }


		// Constructors
		public MimicryObjectAssociatedMessage() { }

		public MimicryObjectAssociatedMessage(uint hostUID = 0)
		{
			HostUID = hostUID;
		}

	}
}
