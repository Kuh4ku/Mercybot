using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextRemoveMultipleElementsMessage : Message
	{

		// Properties
		public List<int> Id { get; set; }


		// Constructors
		public GameContextRemoveMultipleElementsMessage() { }

		public GameContextRemoveMultipleElementsMessage(List<int> id = null)
		{
			Id = id;
		}

	}
}
