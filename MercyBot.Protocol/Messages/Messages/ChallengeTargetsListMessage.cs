using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeTargetsListMessage : Message
	{

		// Properties
		public List<int> TargetIds { get; set; }
		public List<int> TargetCells { get; set; }


		// Constructors
		public ChallengeTargetsListMessage() { }

		public ChallengeTargetsListMessage(List<int> targetIds = null, List<int> targetCells = null)
		{
			TargetIds = targetIds;
			TargetCells = targetCells;
		}

	}
}
