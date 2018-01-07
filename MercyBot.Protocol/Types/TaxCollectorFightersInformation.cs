using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorFightersInformation
	{

		// Properties
		public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
		public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }
		public int CollectorId { get; set; }


		// Constructors
		public TaxCollectorFightersInformation() { }

		public TaxCollectorFightersInformation(int collectorId = 0, List<CharacterMinimalPlusLookInformations> allyCharactersInformations = null, List<CharacterMinimalPlusLookInformations> enemyCharactersInformations = null)
		{
			CollectorId = collectorId;
			AllyCharactersInformations = allyCharactersInformations;
			EnemyCharactersInformations = enemyCharactersInformations;
		}

	}
}
