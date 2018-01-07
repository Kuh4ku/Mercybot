using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ContactLookMessage : Message
	{

		// Properties
		public uint RequestId { get; set; }
		public string PlayerName { get; set; }
		public uint PlayerId { get; set; }
		public EntityLook Look { get; set; }


		// Constructors
		public ContactLookMessage() { }

		public ContactLookMessage(uint requestId = 0, string playerName = "", uint playerId = 0, EntityLook look = null)
		{
			RequestId = requestId;
			PlayerName = playerName;
			PlayerId = playerId;
			Look = look;
		}

	}
}
