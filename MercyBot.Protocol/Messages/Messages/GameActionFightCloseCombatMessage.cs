using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
	{

		// Properties
		public uint WeaponGenericId { get; set; }


		// Constructors
		public GameActionFightCloseCombatMessage() { }

		public GameActionFightCloseCombatMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int destinationCellId = 0, uint critical = 1, bool silentCast = false, uint weaponGenericId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			DestinationCellId = destinationCellId;
			Critical = critical;
			SilentCast = silentCast;
			WeaponGenericId = weaponGenericId;
		}

	}
}
