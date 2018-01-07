using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightEntityDispositionInformations : EntityDispositionInformations
	{

		// Properties
		public int CarryingCharacterId { get; set; }


		// Constructors
		public FightEntityDispositionInformations() { }

		public FightEntityDispositionInformations(int cellId = 0, uint direction = 1, int carryingCharacterId = 0)
		{
			CellId = cellId;
			Direction = direction;
			CarryingCharacterId = carryingCharacterId;
		}

	}
}
