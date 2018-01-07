using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightLoot
	{

		// Properties
		public List<uint> Objects { get; set; }
		public uint Kamas { get; set; }


		// Constructors
		public FightLoot() { }

		public FightLoot(uint kamas = 0, List<uint> objects = null)
		{
			Kamas = kamas;
			Objects = objects;
		}

	}
}
