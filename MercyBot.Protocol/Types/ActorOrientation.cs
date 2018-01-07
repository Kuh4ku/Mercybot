using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ActorOrientation
	{

		// Properties
		public int Id { get; set; }
		public uint Direction { get; set; }


		// Constructors
		public ActorOrientation() { }

		public ActorOrientation(int id = 0, uint direction = 1)
		{
			Id = id;
			Direction = direction;
		}

	}
}
