using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameDataPlayFarmObjectAnimationMessage : Message
	{

		// Properties
		public List<uint> CellId { get; set; }


		// Constructors
		public GameDataPlayFarmObjectAnimationMessage() { }

		public GameDataPlayFarmObjectAnimationMessage(List<uint> cellId = null)
		{
			CellId = cellId;
		}

	}
}
