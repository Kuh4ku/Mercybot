using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayDelayedActionFinishedMessage : Message
	{

		// Properties
		public int DelayedCharacterId { get; set; }
		public uint DelayTypeId { get; set; }


		// Constructors
		public GameRolePlayDelayedActionFinishedMessage() { }

		public GameRolePlayDelayedActionFinishedMessage(int delayedCharacterId = 0, uint delayTypeId = 0)
		{
			DelayedCharacterId = delayedCharacterId;
			DelayTypeId = delayTypeId;
		}

	}
}
