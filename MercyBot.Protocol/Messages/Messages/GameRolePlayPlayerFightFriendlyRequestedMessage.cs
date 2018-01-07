using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayPlayerFightFriendlyRequestedMessage : Message
	{

		// Properties
		public uint FightId { get; set; }
		public uint SourceId { get; set; }
		public uint TargetId { get; set; }


		// Constructors
		public GameRolePlayPlayerFightFriendlyRequestedMessage() { }

		public GameRolePlayPlayerFightFriendlyRequestedMessage(uint fightId = 0, uint sourceId = 0, uint targetId = 0)
		{
			FightId = fightId;
			SourceId = sourceId;
			TargetId = targetId;
		}

	}
}
