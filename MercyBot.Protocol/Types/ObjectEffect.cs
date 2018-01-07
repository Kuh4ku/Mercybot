using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffect
	{

		// Properties
		public uint ActionId { get; set; }


		// Constructors
		public ObjectEffect() { }

		public ObjectEffect(uint actionId = 0)
		{
			ActionId = actionId;
		}

	}
}
