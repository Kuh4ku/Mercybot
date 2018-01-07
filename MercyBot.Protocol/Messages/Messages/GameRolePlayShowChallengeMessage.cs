using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayShowChallengeMessage : Message
	{

		// Properties
		public FightCommonInformations CommonsInfos { get; set; }


		// Constructors
		public GameRolePlayShowChallengeMessage() { }

		public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos = null)
		{
			CommonsInfos = commonsInfos;
		}

	}
}
