using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorDialogQuestionBasicMessage : Message
	{

		// Properties
		public BasicGuildInformations GuildInfo { get; set; }


		// Constructors
		public TaxCollectorDialogQuestionBasicMessage() { }

		public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo = null)
		{
			GuildInfo = guildInfo;
		}

	}
}
