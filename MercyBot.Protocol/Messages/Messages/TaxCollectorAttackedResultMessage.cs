using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorAttackedResultMessage : Message
	{

		// Properties
		public bool DeadOrAlive { get; set; }
		public TaxCollectorBasicInformations BasicInfos { get; set; }
		public BasicGuildInformations Guild { get; set; }


		// Constructors
		public TaxCollectorAttackedResultMessage() { }

		public TaxCollectorAttackedResultMessage(bool deadOrAlive = false, TaxCollectorBasicInformations basicInfos = null, BasicGuildInformations guild = null)
		{
			DeadOrAlive = deadOrAlive;
			BasicInfos = basicInfos;
			Guild = guild;
		}

	}
}
