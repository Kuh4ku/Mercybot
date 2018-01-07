using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class IgnoredOnlineInformations : IgnoredInformations
	{

		// Properties
		public uint PlayerId { get; set; }
		public string PlayerName { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }


		// Constructors
		public IgnoredOnlineInformations() { }

		public IgnoredOnlineInformations(uint accountId = 0, string accountName = "", uint playerId = 0, string playerName = "", int breed = 0, bool sex = false)
		{
			AccountId = accountId;
			AccountName = accountName;
			PlayerId = playerId;
			PlayerName = playerName;
			Breed = breed;
			Sex = sex;
		}

	}
}
