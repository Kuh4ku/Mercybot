using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismsListRegisterMessage : Message
	{

		// Properties
		public uint Listen { get; set; }


		// Constructors
		public PrismsListRegisterMessage() { }

		public PrismsListRegisterMessage(uint listen = 0)
		{
			Listen = listen;
		}

	}
}
