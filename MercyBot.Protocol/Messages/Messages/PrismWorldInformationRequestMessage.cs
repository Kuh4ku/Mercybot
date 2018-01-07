using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismWorldInformationRequestMessage : Message
	{

		// Properties
		public bool Join { get; set; }


		// Constructors
		public PrismWorldInformationRequestMessage() { }

		public PrismWorldInformationRequestMessage(bool join = false)
		{
			Join = join;
		}

	}
}
