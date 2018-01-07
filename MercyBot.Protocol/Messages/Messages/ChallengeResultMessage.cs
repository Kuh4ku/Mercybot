using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeResultMessage : Message
	{

		// Properties
		public uint ChallengeId { get; set; }
		public bool Success { get; set; }


		// Constructors
		public ChallengeResultMessage() { }

		public ChallengeResultMessage(uint challengeId = 0, bool success = false)
		{
			ChallengeId = challengeId;
			Success = success;
		}

	}
}
