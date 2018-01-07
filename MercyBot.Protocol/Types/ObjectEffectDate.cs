using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectDate : ObjectEffect
	{

		// Properties
		public uint Year { get; set; }
		public uint Month { get; set; }
		public uint Day { get; set; }
		public uint Hour { get; set; }
		public uint Minute { get; set; }


		// Constructors
		public ObjectEffectDate() { }

		public ObjectEffectDate(uint actionId = 0, uint year = 0, uint month = 0, uint day = 0, uint hour = 0, uint minute = 0)
		{
			ActionId = actionId;
			Year = year;
			Month = month;
			Day = day;
			Hour = hour;
			Minute = minute;
		}

	}
}
