using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnStartSlaveMessage : GameFightTurnStartMessage
	{

		// Properties
		public int IdSummoner { get; set; }


		// Constructors
		public GameFightTurnStartSlaveMessage() { }

		public GameFightTurnStartSlaveMessage(int id = 0, uint waitTime = 0, int idSummoner = 0)
		{
			Id = id;
			WaitTime = waitTime;
			IdSummoner = idSummoner;
		}

	}
}
