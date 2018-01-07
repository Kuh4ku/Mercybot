using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpellForgetUIMessage : Message
	{

		// Properties
		public bool Open { get; set; }


		// Constructors
		public SpellForgetUIMessage() { }

		public SpellForgetUIMessage(bool open = false)
		{
			Open = open;
		}

	}
}
