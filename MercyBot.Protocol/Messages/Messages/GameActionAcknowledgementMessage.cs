using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionAcknowledgementMessage : Message
	{

		// Properties
		public bool Valid { get; set; }
		public int ActionId { get; set; }


		// Constructors
		public GameActionAcknowledgementMessage() { }

		public GameActionAcknowledgementMessage(bool valid = false, int actionId = 0)
		{
			Valid = valid;
			ActionId = actionId;
		}

	}
}
