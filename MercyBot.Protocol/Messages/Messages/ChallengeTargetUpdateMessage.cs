using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeTargetUpdateMessage : Message
	{

		// Properties
		public uint ChallengeId { get; set; }
		public int TargetId { get; set; }


		// Constructors
		public ChallengeTargetUpdateMessage() { }

		public ChallengeTargetUpdateMessage(uint challengeId = 0, int targetId = 0)
		{
			ChallengeId = challengeId;
			TargetId = targetId;
		}

	}
}
