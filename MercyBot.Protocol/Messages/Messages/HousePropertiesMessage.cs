using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HousePropertiesMessage : Message
	{

		// Properties
		public HouseInformations Properties { get; set; }


		// Constructors
		public HousePropertiesMessage() { }

		public HousePropertiesMessage(HouseInformations properties = null)
		{
			Properties = properties;
		}

	}
}
