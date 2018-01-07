using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismBalanceResultMessage : Message
	{

		// Properties
		public uint TotalBalanceValue { get; set; }
		public uint SubAreaBalanceValue { get; set; }


		// Constructors
		public PrismBalanceResultMessage() { }

		public PrismBalanceResultMessage(uint totalBalanceValue = 0, uint subAreaBalanceValue = 0)
		{
			TotalBalanceValue = totalBalanceValue;
			SubAreaBalanceValue = subAreaBalanceValue;
		}

	}
}
