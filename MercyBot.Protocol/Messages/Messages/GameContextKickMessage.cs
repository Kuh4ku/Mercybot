using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameContextKickMessage : Message
	{

		// Properties
		public int TargetId { get; set; }


		// Constructors
		public GameContextKickMessage() { }

		public GameContextKickMessage(int targetId = 0)
		{
			TargetId = targetId;
		}

	}
}
