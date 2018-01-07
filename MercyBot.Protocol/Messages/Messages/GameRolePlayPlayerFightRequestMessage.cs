using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayPlayerFightRequestMessage : Message
	{

		// Properties
		public uint TargetId { get; set; }
		public int TargetCellId { get; set; }
		public bool Friendly { get; set; }


		// Constructors
		public GameRolePlayPlayerFightRequestMessage() { }

		public GameRolePlayPlayerFightRequestMessage(uint targetId = 0, int targetCellId = 0, bool friendly = false)
		{
			TargetId = targetId;
			TargetCellId = targetCellId;
			Friendly = friendly;
		}

	}
}
