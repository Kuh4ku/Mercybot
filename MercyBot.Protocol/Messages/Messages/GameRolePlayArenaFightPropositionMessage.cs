using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayArenaFightPropositionMessage : Message
	{

		// Properties
		public List<uint> AlliesId { get; set; }
		public uint FightId { get; set; }
		public uint Duration { get; set; }


		// Constructors
		public GameRolePlayArenaFightPropositionMessage() { }

		public GameRolePlayArenaFightPropositionMessage(uint fightId = 0, uint duration = 0, List<uint> alliesId = null)
		{
			FightId = fightId;
			Duration = duration;
			AlliesId = alliesId;
		}

	}
}
