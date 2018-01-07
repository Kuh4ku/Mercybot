using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightTurnListMessage : Message
	{

		// Properties
		public List<int> Ids { get; set; }
		public List<int> DeadsIds { get; set; }


		// Constructors
		public GameFightTurnListMessage() { }

		public GameFightTurnListMessage(List<int> ids = null, List<int> deadsIds = null)
		{
			Ids = ids;
			DeadsIds = deadsIds;
		}

	}
}
