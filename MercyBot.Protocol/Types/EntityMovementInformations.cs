using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class EntityMovementInformations
	{

		// Properties
		public List<int> Steps { get; set; }
		public int Id { get; set; }


		// Constructors
		public EntityMovementInformations() { }

		public EntityMovementInformations(int id = 0, List<int> steps = null)
		{
			Id = id;
			Steps = steps;
		}

	}
}
