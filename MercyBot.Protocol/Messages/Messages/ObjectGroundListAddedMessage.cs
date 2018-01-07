using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectGroundListAddedMessage : Message
	{

		// Properties
		public List<uint> Cells { get; set; }
		public List<uint> ReferenceIds { get; set; }


		// Constructors
		public ObjectGroundListAddedMessage() { }

		public ObjectGroundListAddedMessage(List<uint> cells = null, List<uint> referenceIds = null)
		{
			Cells = cells;
			ReferenceIds = referenceIds;
		}

	}
}
