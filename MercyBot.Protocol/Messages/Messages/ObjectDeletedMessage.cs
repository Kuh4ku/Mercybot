using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectDeletedMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }


		// Constructors
		public ObjectDeletedMessage() { }

		public ObjectDeletedMessage(uint objectUID = 0)
		{
			ObjectUID = objectUID;
		}

	}
}
