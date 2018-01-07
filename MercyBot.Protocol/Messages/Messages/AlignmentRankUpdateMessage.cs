using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AlignmentRankUpdateMessage : Message
	{

		// Properties
		public uint AlignmentRank { get; set; }
		public bool Verbose { get; set; }


		// Constructors
		public AlignmentRankUpdateMessage() { }

		public AlignmentRankUpdateMessage(uint alignmentRank = 0, bool verbose = false)
		{
			AlignmentRank = alignmentRank;
			Verbose = verbose;
		}

	}
}
