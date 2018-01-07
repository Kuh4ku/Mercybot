using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
	{

		// Properties
		public uint ObjectGID { get; set; }


		// Constructors
		public GameRolePlayDelayedObjectUseMessage() { }

		public GameRolePlayDelayedObjectUseMessage(int delayedCharacterId = 0, uint delayTypeId = 0, double delayEndTime = 0, uint objectGID = 0)
		{
			DelayedCharacterId = delayedCharacterId;
			DelayTypeId = delayTypeId;
			DelayEndTime = delayEndTime;
			ObjectGID = objectGID;
		}

	}
}
