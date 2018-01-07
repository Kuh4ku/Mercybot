using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class KrosmasterFigure
	{

		// Properties
		public string Uid { get; set; }
		public uint Figure { get; set; }
		public uint Pedestal { get; set; }
		public bool Bound { get; set; }


		// Constructors
		public KrosmasterFigure() { }

		public KrosmasterFigure(string uid = "", uint figure = 0, uint pedestal = 0, bool bound = false)
		{
			Uid = uid;
			Figure = figure;
			Pedestal = pedestal;
			Bound = bound;
		}

	}
}
