using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AccountCapabilitiesMessage : Message
	{

		// Properties
		public int AccountId { get; set; }
		public bool TutorialAvailable { get; set; }
		public uint BreedsVisible { get; set; }
		public uint BreedsAvailable { get; set; }
		public int Status { get; set; }


		// Constructors
		public AccountCapabilitiesMessage() { }

		public AccountCapabilitiesMessage(int accountId = 0, bool tutorialAvailable = false, uint breedsVisible = 0, uint breedsAvailable = 0, int status = -1)
		{
			AccountId = accountId;
			TutorialAvailable = tutorialAvailable;
			BreedsVisible = breedsVisible;
			BreedsAvailable = breedsAvailable;
			Status = status;
		}

	}
}
