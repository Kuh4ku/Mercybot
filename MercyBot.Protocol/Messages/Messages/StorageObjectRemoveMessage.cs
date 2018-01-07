using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageObjectRemoveMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }


		// Constructors
		public StorageObjectRemoveMessage() { }

		public StorageObjectRemoveMessage(uint objectUID = 0)
		{
			ObjectUID = objectUID;
		}

	}
}
