using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightOptionStateUpdateMessage : Message
	{

		// Properties
		public uint FightId { get; set; }
		public uint TeamId { get; set; }
		public uint Option { get; set; }
		public bool State { get; set; }


		// Constructors
		public GameFightOptionStateUpdateMessage() { }

		public GameFightOptionStateUpdateMessage(uint fightId = 0, uint teamId = 2, uint option = 3, bool state = false)
		{
			FightId = fightId;
			TeamId = teamId;
			Option = option;
			State = state;
		}

	}
}
