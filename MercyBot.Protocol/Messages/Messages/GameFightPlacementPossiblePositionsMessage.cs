using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightPlacementPossiblePositionsMessage : Message
	{

		// Properties
		public List<uint> PositionsForChallengers { get; set; }
		public List<uint> PositionsForDefenders { get; set; }
		public uint TeamNumber { get; set; }


		// Constructors
		public GameFightPlacementPossiblePositionsMessage() { }

		public GameFightPlacementPossiblePositionsMessage(uint teamNumber = 2, List<uint> positionsForChallengers = null, List<uint> positionsForDefenders = null)
		{
			TeamNumber = teamNumber;
			PositionsForChallengers = positionsForChallengers;
			PositionsForDefenders = positionsForDefenders;
		}

	}
}
