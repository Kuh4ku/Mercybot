using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectDuration : ObjectEffect
	{

		// Properties
		public uint Days { get; set; }
		public uint Hours { get; set; }
		public uint Minutes { get; set; }


		// Constructors
		public ObjectEffectDuration() { }

		public ObjectEffectDuration(uint actionId = 0, uint days = 0, uint hours = 0, uint minutes = 0)
		{
			ActionId = actionId;
			Days = days;
			Hours = hours;
			Minutes = minutes;
		}

	}
}
