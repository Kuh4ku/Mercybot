using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameMapMovementMessage : Message
	{

		// Properties
		public List<uint> KeyMovements { get; set; }
		public int ActorId { get; set; }


		// Constructors
		public GameMapMovementMessage() { }

		public GameMapMovementMessage(int actorId = 0, List<uint> keyMovements = null)
		{
			ActorId = actorId;
			KeyMovements = keyMovements;
		}

	}
}
