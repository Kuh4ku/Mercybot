using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkMountWithOutPaddockMessage : Message
	{

		// Properties
		public List<MountClientData> StabledMountsDescription { get; set; }


		// Constructors
		public ExchangeStartOkMountWithOutPaddockMessage() { }

		public ExchangeStartOkMountWithOutPaddockMessage(List<MountClientData> stabledMountsDescription = null)
		{
			StabledMountsDescription = stabledMountsDescription;
		}

	}
}
