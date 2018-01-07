using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
	{

		// Properties
		public List<AlternativeMonstersInGroupLightInformations> Alternatives { get; set; }


		// Constructors
		public GroupMonsterStaticInformationsWithAlternatives() { }

		public GroupMonsterStaticInformationsWithAlternatives(MonsterInGroupLightInformations mainCreatureLightInfos = null, List<MonsterInGroupInformations> underlings = null, List<AlternativeMonstersInGroupLightInformations> alternatives = null)
		{
			MainCreatureLightInfos = mainCreatureLightInfos;
			Underlings = underlings;
			Alternatives = alternatives;
		}

	}
}
