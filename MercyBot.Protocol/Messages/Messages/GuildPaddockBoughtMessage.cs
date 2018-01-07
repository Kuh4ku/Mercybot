using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildPaddockBoughtMessage : Message
	{

		// Properties
		public PaddockContentInformations PaddockInfo { get; set; }


		// Constructors
		public GuildPaddockBoughtMessage() { }

		public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo = null)
		{
			PaddockInfo = paddockInfo;
		}

	}
}
