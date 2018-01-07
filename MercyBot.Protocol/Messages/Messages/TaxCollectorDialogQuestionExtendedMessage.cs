using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
	{

		// Properties
		public uint MaxPods { get; set; }
		public uint Prospecting { get; set; }
		public uint Wisdom { get; set; }
		public uint TaxCollectorsCount { get; set; }
		public int TaxCollectorAttack { get; set; }
		public uint Kamas { get; set; }
		public double Experience { get; set; }
		public uint Pods { get; set; }
		public uint ItemsValue { get; set; }


		// Constructors
		public TaxCollectorDialogQuestionExtendedMessage() { }

		public TaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo = null, uint maxPods = 0, uint prospecting = 0, uint wisdom = 0, uint taxCollectorsCount = 0, int taxCollectorAttack = 0, uint kamas = 0, double experience = 0, uint pods = 0, uint itemsValue = 0)
		{
			GuildInfo = guildInfo;
			MaxPods = maxPods;
			Prospecting = prospecting;
			Wisdom = wisdom;
			TaxCollectorsCount = taxCollectorsCount;
			TaxCollectorAttack = taxCollectorAttack;
			Kamas = kamas;
			Experience = experience;
			Pods = pods;
			ItemsValue = itemsValue;
		}

	}
}
