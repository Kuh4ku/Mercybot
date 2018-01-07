using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectGroundAddedMessage : Message
	{

		// Properties
		public uint CellId { get; set; }
		public uint ObjectGID { get; set; }


		// Constructors
		public ObjectGroundAddedMessage() { }

		public ObjectGroundAddedMessage(uint cellId = 0, uint objectGID = 0)
		{
			CellId = cellId;
			ObjectGID = objectGID;
		}

	}
}
