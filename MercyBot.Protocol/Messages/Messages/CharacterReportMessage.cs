using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterReportMessage : Message
	{

		// Properties
		public uint ReportedId { get; set; }
		public uint Reason { get; set; }


		// Constructors
		public CharacterReportMessage() { }

		public CharacterReportMessage(uint reportedId = 0, uint reason = 0)
		{
			ReportedId = reportedId;
			Reason = reason;
		}

	}
}
