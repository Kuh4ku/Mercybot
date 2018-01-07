using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildEmblem
	{

		// Properties
		public int SymbolShape { get; set; }
		public int SymbolColor { get; set; }
		public int BackgroundShape { get; set; }
		public int BackgroundColor { get; set; }


		// Constructors
		public GuildEmblem() { }

		public GuildEmblem(int symbolShape = 0, int symbolColor = 0, int backgroundShape = 0, int backgroundColor = 0)
		{
			SymbolShape = symbolShape;
			SymbolColor = symbolColor;
			BackgroundShape = backgroundShape;
			BackgroundColor = backgroundColor;
		}

	}
}
