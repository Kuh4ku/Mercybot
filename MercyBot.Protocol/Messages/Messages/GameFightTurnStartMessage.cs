using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnStartMessage : Message
	{

		// Properties
		public int Id { get; set; }
		public uint WaitTime { get; set; }


		// Constructors
		public GameFightTurnStartMessage() { }

		public GameFightTurnStartMessage(int id = 0, uint waitTime = 0)
		{
			Id = id;
			WaitTime = waitTime;
		}

	}
}
