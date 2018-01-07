using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyMemberInFightMessage : AbstractPartyMessage
	{

		// Properties
		public uint Reason { get; set; }
		public int MemberId { get; set; }
		public uint MemberAccountId { get; set; }
		public string MemberName { get; set; }
		public int FightId { get; set; }
		public MapCoordinatesExtended FightMap { get; set; }
		public int SecondsBeforeFightStart { get; set; }


		// Constructors
		public PartyMemberInFightMessage() { }

		public PartyMemberInFightMessage(uint partyId = 0, uint reason = 0, int memberId = 0, uint memberAccountId = 0, string memberName = "", int fightId = 0, MapCoordinatesExtended fightMap = null, int secondsBeforeFightStart = 0)
		{
			PartyId = partyId;
			Reason = reason;
			MemberId = memberId;
			MemberAccountId = memberAccountId;
			MemberName = memberName;
			FightId = fightId;
			FightMap = fightMap;
			SecondsBeforeFightStart = secondsBeforeFightStart;
		}

	}
}
