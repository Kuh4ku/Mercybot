using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnReadyRequestMessage : Message
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public GameFightTurnReadyRequestMessage() { }

		public GameFightTurnReadyRequestMessage(int id = 0)
		{
			Id = id;
		}

	}
}
