using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectGroundRemovedMultipleMessage : Message
	{

		// Properties
		public List<uint> Cells { get; set; }


		// Constructors
		public ObjectGroundRemovedMultipleMessage() { }

		public ObjectGroundRemovedMultipleMessage(List<uint> cells = null)
		{
			Cells = cells;
		}

	}
}
