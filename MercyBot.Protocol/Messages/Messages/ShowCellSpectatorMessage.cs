using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShowCellSpectatorMessage : ShowCellMessage
	{

		// Properties
		public string PlayerName { get; set; }


		// Constructors
		public ShowCellSpectatorMessage() { }

		public ShowCellSpectatorMessage(int sourceId = 0, uint cellId = 0, string playerName = "")
		{
			SourceId = sourceId;
			CellId = cellId;
			PlayerName = playerName;
		}

	}
}
