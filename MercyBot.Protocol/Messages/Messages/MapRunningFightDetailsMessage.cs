using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapRunningFightDetailsMessage : Message
	{

		// Properties
		public List<GameFightFighterLightInformations> Attackers { get; set; }
		public List<GameFightFighterLightInformations> Defenders { get; set; }
		public uint FightId { get; set; }


		// Constructors
		public MapRunningFightDetailsMessage() { }

		public MapRunningFightDetailsMessage(uint fightId = 0, List<GameFightFighterLightInformations> attackers = null, List<GameFightFighterLightInformations> defenders = null)
		{
			FightId = fightId;
			Attackers = attackers;
			Defenders = defenders;
		}

	}
}
