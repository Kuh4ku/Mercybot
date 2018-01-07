using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServerOptionalFeaturesMessage : Message
	{

		// Properties
		public List<uint> Features { get; set; }


		// Constructors
		public ServerOptionalFeaturesMessage() { }

		public ServerOptionalFeaturesMessage(List<uint> features = null)
		{
			Features = features;
		}

	}
}
