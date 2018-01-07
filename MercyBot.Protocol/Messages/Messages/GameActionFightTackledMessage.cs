using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightTackledMessage : AbstractGameActionMessage
	{

		// Properties
		public List<int> TacklersIds { get; set; }


		// Constructors
		public GameActionFightTackledMessage() { }

		public GameActionFightTackledMessage(uint actionId = 0, int sourceId = 0, List<int> tacklersIds = null)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TacklersIds = tacklersIds;
		}

	}
}
