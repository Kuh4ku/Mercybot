using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayArenaRegistrationStatusMessage : Message
	{

		// Properties
		public bool Registered { get; set; }
		public uint Step { get; set; }
		public uint BattleMode { get; set; }


		// Constructors
		public GameRolePlayArenaRegistrationStatusMessage() { }

		public GameRolePlayArenaRegistrationStatusMessage(bool registered = false, uint step = 0, uint battleMode = 3)
		{
			Registered = registered;
			Step = step;
			BattleMode = battleMode;
		}

	}
}
