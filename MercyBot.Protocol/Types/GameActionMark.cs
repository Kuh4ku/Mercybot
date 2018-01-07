using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameActionMark
	{

		// Properties
		public List<GameActionMarkedCell> Cells { get; set; }
		public int MarkAuthorId { get; set; }
		public uint MarkSpellId { get; set; }
		public int MarkId { get; set; }
		public int MarkType { get; set; }


		// Constructors
		public GameActionMark() { }

		public GameActionMark(int markAuthorId = 0, uint markSpellId = 0, int markId = 0, int markType = 0, List<GameActionMarkedCell> cells = null)
		{
			MarkAuthorId = markAuthorId;
			MarkSpellId = markSpellId;
			MarkId = markId;
			MarkType = markType;
			Cells = cells;
		}

	}
}
