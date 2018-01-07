using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeErrorMessage : Message
	{

		// Properties
		public int ErrorType { get; set; }


		// Constructors
		public ExchangeErrorMessage() { }

		public ExchangeErrorMessage(int errorType = 0)
		{
			ErrorType = errorType;
		}

	}
}
