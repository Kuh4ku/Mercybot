using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayFightRequestCanceledMessage : Message
	{

		// Properties
		public int FightId { get; set; }
		public uint SourceId { get; set; }
		public int TargetId { get; set; }


		// Constructors
		public GameRolePlayFightRequestCanceledMessage() { }

		public GameRolePlayFightRequestCanceledMessage(int fightId = 0, uint sourceId = 0, int targetId = 0)
		{
			FightId = fightId;
			SourceId = sourceId;
			TargetId = targetId;
		}

	}
}
