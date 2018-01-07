using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightResumeMessage : GameFightSpectateMessage
	{

		// Properties
		public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
		public uint SummonCount { get; set; }
		public uint BombCount { get; set; }


		// Constructors
		public GameFightResumeMessage() { }

		public GameFightResumeMessage(uint gameTurn = 0, uint summonCount = 0, uint bombCount = 0, List<FightDispellableEffectExtendedInformations> effects = null, List<GameActionMark> marks = null, List<GameFightSpellCooldown> spellCooldowns = null)
		{
			GameTurn = gameTurn;
			SummonCount = summonCount;
			BombCount = bombCount;
			Effects = effects;
			Marks = marks;
			SpellCooldowns = spellCooldowns;
		}

	}
}
