using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayArenaFighterStatusMessage : Message
	{

		// Properties
		public int FightId { get; set; }
		public uint PlayerId { get; set; }
		public bool Accepted { get; set; }


		// Constructors
		public GameRolePlayArenaFighterStatusMessage() { }

		public GameRolePlayArenaFighterStatusMessage(int fightId = 0, uint playerId = 0, bool accepted = false)
		{
			FightId = fightId;
			PlayerId = playerId;
			Accepted = accepted;
		}

	}
}
