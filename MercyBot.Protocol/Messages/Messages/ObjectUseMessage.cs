using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectUseMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }


		// Constructors
		public ObjectUseMessage() { }

		public ObjectUseMessage(uint objectUID = 0)
		{
			ObjectUID = objectUID;
		}

	}
}
