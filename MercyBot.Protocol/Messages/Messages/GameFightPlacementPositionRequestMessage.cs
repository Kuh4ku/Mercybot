using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightPlacementPositionRequestMessage : Message
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public GameFightPlacementPositionRequestMessage() { }

		public GameFightPlacementPositionRequestMessage(uint cellId = 0)
		{
			CellId = cellId;
		}

	}
}
