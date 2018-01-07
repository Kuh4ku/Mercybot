using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnResumeMessage : GameFightTurnStartMessage
	{

		// Constructors
		public GameFightTurnResumeMessage() { }

		public GameFightTurnResumeMessage(int id = 0, uint waitTime = 0)
		{
			Id = id;
			WaitTime = waitTime;
		}

	}
}
