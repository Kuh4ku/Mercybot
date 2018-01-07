using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpellForgottenMessage : Message
	{

		// Properties
		public List<uint> SpellsId { get; set; }
		public uint BoostPoint { get; set; }


		// Constructors
		public SpellForgottenMessage() { }

		public SpellForgottenMessage(uint boostPoint = 0, List<uint> spellsId = null)
		{
			BoostPoint = boostPoint;
			SpellsId = spellsId;
		}

	}
}
