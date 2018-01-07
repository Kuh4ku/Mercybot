using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TitlesAndOrnamentsListMessage : Message
	{

		// Properties
		public List<uint> Titles { get; set; }
		public List<uint> Ornaments { get; set; }
		public uint ActiveTitle { get; set; }
		public uint ActiveOrnament { get; set; }


		// Constructors
		public TitlesAndOrnamentsListMessage() { }

		public TitlesAndOrnamentsListMessage(uint activeTitle = 0, uint activeOrnament = 0, List<uint> titles = null, List<uint> ornaments = null)
		{
			ActiveTitle = activeTitle;
			ActiveOrnament = activeOrnament;
			Titles = titles;
			Ornaments = ornaments;
		}

	}
}
