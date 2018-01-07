using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameDataPaddockObjectListAddMessage : Message
	{

		// Properties
		public List<PaddockItem> PaddockItemDescription { get; set; }


		// Constructors
		public GameDataPaddockObjectListAddMessage() { }

		public GameDataPaddockObjectListAddMessage(List<PaddockItem> paddockItemDescription = null)
		{
			PaddockItemDescription = paddockItemDescription;
		}

	}
}
