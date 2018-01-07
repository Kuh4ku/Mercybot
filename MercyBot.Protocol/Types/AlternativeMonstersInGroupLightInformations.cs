using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AlternativeMonstersInGroupLightInformations
	{

		// Properties
		public List<MonsterInGroupLightInformations> Monsters { get; set; }
		public int PlayerCount { get; set; }


		// Constructors
		public AlternativeMonstersInGroupLightInformations() { }

		public AlternativeMonstersInGroupLightInformations(int playerCount = 0, List<MonsterInGroupLightInformations> monsters = null)
		{
			PlayerCount = playerCount;
			Monsters = monsters;
		}

	}
}
