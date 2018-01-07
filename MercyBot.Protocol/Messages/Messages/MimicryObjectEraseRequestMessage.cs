using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MimicryObjectEraseRequestMessage : Message
	{

		// Properties
		public uint HostUID { get; set; }
		public uint HostPos { get; set; }


		// Constructors
		public MimicryObjectEraseRequestMessage() { }

		public MimicryObjectEraseRequestMessage(uint hostUID = 0, uint hostPos = 0)
		{
			HostUID = hostUID;
			HostPos = hostPos;
		}

	}
}
