using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeInfoMessage : Message
	{

		// Properties
		public uint ChallengeId { get; set; }
		public int TargetId { get; set; }
		public uint XpBonus { get; set; }
		public uint DropBonus { get; set; }


		// Constructors
		public ChallengeInfoMessage() { }

		public ChallengeInfoMessage(uint challengeId = 0, int targetId = 0, uint xpBonus = 0, uint dropBonus = 0)
		{
			ChallengeId = challengeId;
			TargetId = targetId;
			XpBonus = xpBonus;
			DropBonus = dropBonus;
		}

	}
}
