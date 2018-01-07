using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceCreationResultMessage : Message
	{

		// Properties
		public uint Result { get; set; }


		// Constructors
		public AllianceCreationResultMessage() { }

		public AllianceCreationResultMessage(uint result = 0)
		{
			Result = result;
		}

	}
}
