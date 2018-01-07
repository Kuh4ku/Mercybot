using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnEndMessage : Message
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public GameFightTurnEndMessage() { }

		public GameFightTurnEndMessage(int id = 0)
		{
			Id = id;
		}

	}
}
