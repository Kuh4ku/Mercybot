using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PrismFightersInformation
	{

		// Properties
		public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
		public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }
		public uint SubAreaId { get; set; }
		public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }


		// Constructors
		public PrismFightersInformation() { }

		public PrismFightersInformation(uint subAreaId = 0, ProtectedEntityWaitingForHelpInfo waitingForHelpInfo = null, List<CharacterMinimalPlusLookInformations> allyCharactersInformations = null, List<CharacterMinimalPlusLookInformations> enemyCharactersInformations = null)
		{
			SubAreaId = subAreaId;
			WaitingForHelpInfo = waitingForHelpInfo;
			AllyCharactersInformations = allyCharactersInformations;
			EnemyCharactersInformations = enemyCharactersInformations;
		}

	}
}
