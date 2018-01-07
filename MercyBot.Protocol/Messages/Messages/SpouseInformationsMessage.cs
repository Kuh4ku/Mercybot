using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpouseInformationsMessage : Message
	{

		// Properties
		public FriendSpouseInformations Spouse { get; set; }


		// Constructors
		public SpouseInformationsMessage() { }

		public SpouseInformationsMessage(FriendSpouseInformations spouse = null)
		{
			Spouse = spouse;
		}

	}
}
