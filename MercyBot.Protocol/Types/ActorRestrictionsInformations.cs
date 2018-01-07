using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ActorRestrictionsInformations
	{

		// Properties
		public bool CantBeAggressed { get; set; }
		public bool CantBeChallenged { get; set; }
		public bool CantTrade { get; set; }
		public bool CantBeAttackedByMutant { get; set; }
		public bool CantRun { get; set; }
		public bool ForceSlowWalk { get; set; }
		public bool CantMinimize { get; set; }
		public bool CantMove { get; set; }
		public bool CantAggress { get; set; }
		public bool CantChallenge { get; set; }
		public bool CantExchange { get; set; }
		public bool CantAttack { get; set; }
		public bool CantChat { get; set; }
		public bool CantBeMerchant { get; set; }
		public bool CantUseObject { get; set; }
		public bool CantUseTaxCollector { get; set; }
		public bool CantUseInteractive { get; set; }
		public bool CantSpeakToNPC { get; set; }
		public bool CantChangeZone { get; set; }
		public bool CantAttackMonster { get; set; }
		public bool CantWalk8Directions { get; set; }


		// Constructors
		public ActorRestrictionsInformations() { }

		public ActorRestrictionsInformations(bool cantBeAggressed = false, bool cantBeChallenged = false, bool cantTrade = false, bool cantBeAttackedByMutant = false, bool cantRun = false, bool forceSlowWalk = false, bool cantMinimize = false, bool cantMove = false, bool cantAggress = false, bool cantChallenge = false, bool cantExchange = false, bool cantAttack = false, bool cantChat = false, bool cantBeMerchant = false, bool cantUseObject = false, bool cantUseTaxCollector = false, bool cantUseInteractive = false, bool cantSpeakToNPC = false, bool cantChangeZone = false, bool cantAttackMonster = false, bool cantWalk8Directions = false)
		{
			CantBeAggressed = cantBeAggressed;
			CantBeChallenged = cantBeChallenged;
			CantTrade = cantTrade;
			CantBeAttackedByMutant = cantBeAttackedByMutant;
			CantRun = cantRun;
			ForceSlowWalk = forceSlowWalk;
			CantMinimize = cantMinimize;
			CantMove = cantMove;
			CantAggress = cantAggress;
			CantChallenge = cantChallenge;
			CantExchange = cantExchange;
			CantAttack = cantAttack;
			CantChat = cantChat;
			CantBeMerchant = cantBeMerchant;
			CantUseObject = cantUseObject;
			CantUseTaxCollector = cantUseTaxCollector;
			CantUseInteractive = cantUseInteractive;
			CantSpeakToNPC = cantSpeakToNPC;
			CantChangeZone = cantChangeZone;
			CantAttackMonster = cantAttackMonster;
			CantWalk8Directions = cantWalk8Directions;
		}

	}
}
