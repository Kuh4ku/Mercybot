using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkJobIndexMessage : Message
	{

		// Properties
		public List<uint> Jobs { get; set; }


		// Constructors
		public ExchangeStartOkJobIndexMessage() { }

		public ExchangeStartOkJobIndexMessage(List<uint> jobs = null)
		{
			Jobs = jobs;
		}

	}
}
