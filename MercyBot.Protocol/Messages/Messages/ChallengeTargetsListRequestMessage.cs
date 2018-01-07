using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeTargetsListRequestMessage : Message
	{

		// Properties
		public uint ChallengeId { get; set; }


		// Constructors
		public ChallengeTargetsListRequestMessage() { }

		public ChallengeTargetsListRequestMessage(uint challengeId = 0)
		{
			ChallengeId = challengeId;
		}

	}
}
