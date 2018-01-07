using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildCharacsUpgradeRequestMessage : Message
	{

		// Properties
		public uint CharaTypeTarget { get; set; }


		// Constructors
		public GuildCharacsUpgradeRequestMessage() { }

		public GuildCharacsUpgradeRequestMessage(uint charaTypeTarget = 0)
		{
			CharaTypeTarget = charaTypeTarget;
		}

	}
}
