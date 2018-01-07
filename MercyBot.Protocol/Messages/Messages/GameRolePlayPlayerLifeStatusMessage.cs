using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayPlayerLifeStatusMessage : Message
	{

		// Properties
		public uint State { get; set; }


		// Constructors
		public GameRolePlayPlayerLifeStatusMessage() { }

		public GameRolePlayPlayerLifeStatusMessage(uint state = 0)
		{
			State = state;
		}

	}
}
