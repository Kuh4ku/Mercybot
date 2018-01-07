using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInfosUpgradeMessage : Message
	{

		// Properties
		public List<uint> SpellId { get; set; }
		public List<uint> SpellLevel { get; set; }
		public uint MaxTaxCollectorsCount { get; set; }
		public uint TaxCollectorsCount { get; set; }
		public uint TaxCollectorLifePoints { get; set; }
		public uint TaxCollectorDamagesBonuses { get; set; }
		public uint TaxCollectorPods { get; set; }
		public uint TaxCollectorProspecting { get; set; }
		public uint TaxCollectorWisdom { get; set; }
		public uint BoostPoints { get; set; }


		// Constructors
		public GuildInfosUpgradeMessage() { }

		public GuildInfosUpgradeMessage(uint maxTaxCollectorsCount = 0, uint taxCollectorsCount = 0, uint taxCollectorLifePoints = 0, uint taxCollectorDamagesBonuses = 0, uint taxCollectorPods = 0, uint taxCollectorProspecting = 0, uint taxCollectorWisdom = 0, uint boostPoints = 0, List<uint> spellId = null, List<uint> spellLevel = null)
		{
			MaxTaxCollectorsCount = maxTaxCollectorsCount;
			TaxCollectorsCount = taxCollectorsCount;
			TaxCollectorLifePoints = taxCollectorLifePoints;
			TaxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
			TaxCollectorPods = taxCollectorPods;
			TaxCollectorProspecting = taxCollectorProspecting;
			TaxCollectorWisdom = taxCollectorWisdom;
			BoostPoints = boostPoints;
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
