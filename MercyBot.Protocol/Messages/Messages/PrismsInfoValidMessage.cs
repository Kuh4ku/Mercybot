using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismsInfoValidMessage : Message
	{

		// Properties
		public List<PrismFightersInformation> Fights { get; set; }


		// Constructors
		public PrismsInfoValidMessage() { }

		public PrismsInfoValidMessage(List<PrismFightersInformation> fights = null)
		{
			Fights = fights;
		}

	}
}
