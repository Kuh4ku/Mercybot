using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextMoveMultipleElementsMessage : Message
	{

		// Properties
		public List<EntityMovementInformations> Movements { get; set; }


		// Constructors
		public GameContextMoveMultipleElementsMessage() { }

		public GameContextMoveMultipleElementsMessage(List<EntityMovementInformations> movements = null)
		{
			Movements = movements;
		}

	}
}
