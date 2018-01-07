using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SlaveSwitchContextMessage : Message
	{

		// Properties
		public List<SpellItem> SlaveSpells { get; set; }
		public int SummonerId { get; set; }
		public int SlaveId { get; set; }
		public CharacterCharacteristicsInformations SlaveStats { get; set; }


		// Constructors
		public SlaveSwitchContextMessage() { }

		public SlaveSwitchContextMessage(int summonerId = 0, int slaveId = 0, CharacterCharacteristicsInformations slaveStats = null, List<SpellItem> slaveSpells = null)
		{
			SummonerId = summonerId;
			SlaveId = slaveId;
			SlaveStats = slaveStats;
			SlaveSpells = slaveSpells;
		}

	}
}
