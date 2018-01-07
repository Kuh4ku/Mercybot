using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StatedMapUpdateMessage : Message
	{

		// Properties
		public List<StatedElement> StatedElements { get; set; }


		// Constructors
		public StatedMapUpdateMessage() { }

		public StatedMapUpdateMessage(List<StatedElement> statedElements = null)
		{
			StatedElements = statedElements;
		}

	}
}
