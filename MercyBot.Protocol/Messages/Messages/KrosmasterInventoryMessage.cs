using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterInventoryMessage : Message
	{

		// Properties
		public List<KrosmasterFigure> Figures { get; set; }


		// Constructors
		public KrosmasterInventoryMessage() { }

		public KrosmasterInventoryMessage(List<KrosmasterFigure> figures = null)
		{
			Figures = figures;
		}

	}
}
