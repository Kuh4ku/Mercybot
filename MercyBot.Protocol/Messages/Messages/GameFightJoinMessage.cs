using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightJoinMessage : Message
	{

		// Properties
		public bool CanBeCancelled { get; set; }
		public bool CanSayReady { get; set; }
		public bool IsSpectator { get; set; }
		public bool IsFightStarted { get; set; }
		public uint TimeMaxBeforeFightStart { get; set; }
		public uint FightType { get; set; }


		// Constructors
		public GameFightJoinMessage() { }

		public GameFightJoinMessage(bool canBeCancelled = false, bool canSayReady = false, bool isSpectator = false, bool isFightStarted = false, uint timeMaxBeforeFightStart = 0, uint fightType = 0)
		{
			CanBeCancelled = canBeCancelled;
			CanSayReady = canSayReady;
			IsSpectator = isSpectator;
			IsFightStarted = isFightStarted;
			TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
			FightType = fightType;
		}

	}
}
