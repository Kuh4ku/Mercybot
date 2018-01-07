using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationSuccessMessage : Message
	{

		// Properties
		public string Login { get; set; }
		public string Nickname { get; set; }
		public uint AccountId { get; set; }
		public uint CommunityId { get; set; }
		public bool HasRights { get; set; }
		public string SecretQuestion { get; set; }
		public double SubscriptionEndDate { get; set; }
		public bool WasAlreadyConnected { get; set; }
		public double AccountCreation { get; set; }


		// Constructors
		public IdentificationSuccessMessage() { }

		public IdentificationSuccessMessage(string login = "", string nickname = "", uint accountId = 0, uint communityId = 0, bool hasRights = false, string secretQuestion = "", double subscriptionEndDate = 0, bool wasAlreadyConnected = false, double accountCreation = 0)
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
		}

	}
}
