using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterDeletionErrorMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public CharacterDeletionErrorMessage() { }

		public CharacterDeletionErrorMessage(uint reason = 1)
		{
			Reason = reason;
		}

	}
}
