using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class EntityDispositionInformations
	{

		// Properties
		public int CellId { get; set; }
		public uint Direction { get; set; }


		// Constructors
		public EntityDispositionInformations() { }

		public EntityDispositionInformations(int cellId = 0, uint direction = 1)
		{
			CellId = cellId;
			Direction = direction;
		}

	}
}
