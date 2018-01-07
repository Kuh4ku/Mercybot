using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
	{

		// Properties
		public BasicNamedAllianceInformations Alliance { get; set; }


		// Constructors
		public AllianceTaxCollectorDialogQuestionExtendedMessage() { }

		public AllianceTaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo = null, uint maxPods = 0, uint prospecting = 0, uint wisdom = 0, uint taxCollectorsCount = 0, int taxCollectorAttack = 0, uint kamas = 0, double experience = 0, uint pods = 0, uint itemsValue = 0, BasicNamedAllianceInformations alliance = null)
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
			Alliance = alliance;
		}

	}
}
