using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageKamasUpdateMessage : Message
	{

		// Properties
		public int KamasTotal { get; set; }


		// Constructors
		public StorageKamasUpdateMessage() { }

		public StorageKamasUpdateMessage(int kamasTotal = 0)
		{
			KamasTotal = kamasTotal;
		}

	}
}
