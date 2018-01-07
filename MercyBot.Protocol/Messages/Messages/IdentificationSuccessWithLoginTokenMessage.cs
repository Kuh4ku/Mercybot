using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
	{

		// Properties
		public string LoginToken { get; set; }


		// Constructors
		public IdentificationSuccessWithLoginTokenMessage() { }

		public IdentificationSuccessWithLoginTokenMessage(string login = "", string nickname = "", uint accountId = 0, uint communityId = 0, bool hasRights = false, string secretQuestion = "", double subscriptionEndDate = 0, bool wasAlreadyConnected = false, double accountCreation = 0, string loginToken = "")
		{
			Login = login;
			Nickname = nickname;
			AccountId = accountId;
			CommunityId = communityId;
			HasRights = hasRights;
			SecretQuestion = secretQuestion;
			SubscriptionEndDate = subscriptionEndDate;
			WasAlreadyConnected = wasAlreadyConnected;
			AccountCreation = accountCreation;
			LoginToken = loginToken;
		}

	}
}
