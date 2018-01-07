using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageObjectsRemoveMessage : Message
	{

		// Properties
		public List<uint> ObjectUIDList { get; set; }


		// Constructors
		public StorageObjectsRemoveMessage() { }

		public StorageObjectsRemoveMessage(List<uint> objectUIDList = null)
		{
			ObjectUIDList = objectUIDList;
		}

	}
}
