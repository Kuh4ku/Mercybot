using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightResumeSlaveInfo
	{

		// Properties
		public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
		public int SlaveId { get; set; }
		public uint SummonCount { get; set; }
		public uint BombCount { get; set; }


		// Constructors
		public GameFightResumeSlaveInfo() { }

		public GameFightResumeSlaveInfo(int slaveId = 0, uint summonCount = 0, uint bombCount = 0, List<GameFightSpellCooldown> spellCooldowns = null)
		{
			SlaveId = slaveId;
			SummonCount = summonCount;
			BombCount = bombCount;
			SpellCooldowns = spellCooldowns;
		}

	}
}
