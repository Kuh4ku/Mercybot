using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameDataPaddockObjectAddMessage : Message
	{

		// Properties
		public PaddockItem PaddockItemDescription { get; set; }


		// Constructors
		public GameDataPaddockObjectAddMessage() { }

		public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription = null)
		{
			PaddockItemDescription = paddockItemDescription;
		}

	}
}
