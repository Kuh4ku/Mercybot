using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextMoveElementMessage : Message
	{

		// Properties
		public EntityMovementInformations Movement { get; set; }


		// Constructors
		public GameContextMoveElementMessage() { }

		public GameContextMoveElementMessage(EntityMovementInformations movement = null)
		{
			Movement = movement;
		}

	}
}
