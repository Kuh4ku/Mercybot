using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectInteger : ObjectEffect
	{

		// Properties
		public uint Value { get; set; }


		// Constructors
		public ObjectEffectInteger() { }

		public ObjectEffectInteger(uint actionId = 0, uint value = 0)
		{
			ActionId = actionId;
			Value = value;
		}

	}
}
