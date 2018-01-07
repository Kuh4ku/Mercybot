using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
	{

		// Properties
		public uint ElementEventId { get; set; }


		// Constructors
		public GameContextRemoveElementWithEventMessage() { }

		public GameContextRemoveElementWithEventMessage(int id = 0, uint elementEventId = 0)
		{
			Id = id;
			ElementEventId = elementEventId;
		}

	}
}
