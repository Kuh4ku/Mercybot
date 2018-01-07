using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionEmote : HumanOption
	{

		// Properties
		public uint EmoteId { get; set; }
		public double EmoteStartTime { get; set; }


		// Constructors
		public HumanOptionEmote() { }

		public HumanOptionEmote(uint emoteId = 0, double emoteStartTime = 0)
		{
			EmoteId = emoteId;
			EmoteStartTime = emoteStartTime;
		}

	}
}
