using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicWhoIsMessage : Message
	{

		// Properties
		public List<AbstractSocialGroupInfos> SocialGroups { get; set; }
		public bool Self { get; set; }
		public int Position { get; set; }
		public string AccountNickname { get; set; }
		public uint AccountId { get; set; }
		public string PlayerName { get; set; }
		public uint PlayerId { get; set; }
		public int AreaId { get; set; }
		public bool Verbose { get; set; }
		public uint PlayerState { get; set; }


		// Constructors
		public BasicWhoIsMessage() { }

		public BasicWhoIsMessage(bool self = false, int position = -1, string accountNickname = "", uint accountId = 0, string playerName = "", uint playerId = 0, int areaId = 0, bool verbose = false, uint playerState = 99, List<AbstractSocialGroupInfos> socialGroups = null)
		{
			Self = self;
			Position = position;
			AccountNickname = accountNickname;
			AccountId = accountId;
			PlayerName = playerName;
			PlayerId = playerId;
			AreaId = areaId;
			Verbose = verbose;
			PlayerState = playerState;
			SocialGroups = socialGroups;
		}

	}
}
