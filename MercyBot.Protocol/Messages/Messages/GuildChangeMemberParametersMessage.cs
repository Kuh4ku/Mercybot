using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildChangeMemberParametersMessage : Message
	{

		// Properties
		public uint MemberId { get; set; }
		public uint Rank { get; set; }
		public uint ExperienceGivenPercent { get; set; }
		public uint Rights { get; set; }


		// Constructors
		public GuildChangeMemberParametersMessage() { }

		public GuildChangeMemberParametersMessage(uint memberId = 0, uint rank = 0, uint experienceGivenPercent = 0, uint rights = 0)
		{
			MemberId = memberId;
			Rank = rank;
			ExperienceGivenPercent = experienceGivenPercent;
			Rights = rights;
		}

	}
}
