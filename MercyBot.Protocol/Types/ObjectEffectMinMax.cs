using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectMinMax : ObjectEffect
	{

		// Properties
		public uint Min { get; set; }
		public uint Max { get; set; }


		// Constructors
		public ObjectEffectMinMax() { }

		public ObjectEffectMinMax(uint actionId = 0, uint min = 0, uint max = 0)
		{
			ActionId = actionId;
			Min = min;
			Max = max;
		}

	}
}
