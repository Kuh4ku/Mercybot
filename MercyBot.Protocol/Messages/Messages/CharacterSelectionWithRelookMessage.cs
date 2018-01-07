using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectionWithRelookMessage : CharacterSelectionMessage
	{

		// Properties
		public uint CosmeticId { get; set; }


		// Constructors
		public CharacterSelectionWithRelookMessage() { }

		public CharacterSelectionWithRelookMessage(int id = 0, uint cosmeticId = 0)
		{
			Id = id;
			CosmeticId = cosmeticId;
		}

	}
}
