using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectionMessage : Message
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public CharacterSelectionMessage() { }

		public CharacterSelectionMessage(int id = 0)
		{
			Id = id;
		}

	}
}
