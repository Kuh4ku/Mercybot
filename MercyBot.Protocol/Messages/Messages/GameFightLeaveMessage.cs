using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightLeaveMessage : Message
	{

		// Properties
		public int CharId { get; set; }


		// Constructors
		public GameFightLeaveMessage() { }

		public GameFightLeaveMessage(int charId = 0)
		{
			CharId = charId;
		}

	}
}
