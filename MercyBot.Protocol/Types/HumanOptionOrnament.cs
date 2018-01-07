using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionOrnament : HumanOption
	{

		// Properties
		public uint OrnamentId { get; set; }


		// Constructors
		public HumanOptionOrnament() { }

		public HumanOptionOrnament(uint ornamentId = 0)
		{
			OrnamentId = ornamentId;
		}

	}
}
