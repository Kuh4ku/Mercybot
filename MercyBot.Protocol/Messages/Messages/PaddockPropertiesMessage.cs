using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockPropertiesMessage : Message
	{

		// Properties
		public PaddockInformations Properties { get; set; }


		// Constructors
		public PaddockPropertiesMessage() { }

		public PaddockPropertiesMessage(PaddockInformations properties = null)
		{
			Properties = properties;
		}

	}
}
