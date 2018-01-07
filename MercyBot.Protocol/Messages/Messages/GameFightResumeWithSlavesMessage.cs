using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
	{

		// Properties
		public List<GameFightResumeSlaveInfo> SlavesInfo { get; set; }


		// Constructors
		public GameFightResumeWithSlavesMessage() { }

		public GameFightResumeWithSlavesMessage(uint gameTurn = 0, uint summonCount = 0, uint bombCount = 0, List<FightDispellableEffectExtendedInformations> effects = null, List<GameActionMark> marks = null, List<GameFightSpellCooldown> spellCooldowns = null, List<GameFightResumeSlaveInfo> slavesInfo = null)
		{
			GameTurn = gameTurn;
			SummonCount = summonCount;
			BombCount = bombCount;
			Effects = effects;
			Marks = marks;
			SpellCooldowns = spellCooldowns;
			SlavesInfo = slavesInfo;
		}

	}
}
