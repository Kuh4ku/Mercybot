using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class UpdateSelfAgressableStatusMessage : Message
	{

		// Properties
		public uint Status { get; set; }
		public uint ProbationTime { get; set; }


		// Constructors
		public UpdateSelfAgressableStatusMessage() { }

		public UpdateSelfAgressableStatusMessage(uint status = 0, uint probationTime = 0)
		{
			Status = status;
			ProbationTime = probationTime;
		}

	}
}
