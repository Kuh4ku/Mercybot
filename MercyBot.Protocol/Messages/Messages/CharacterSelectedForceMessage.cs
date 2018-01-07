using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectedForceMessage : Message
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public CharacterSelectedForceMessage() { }

		public CharacterSelectedForceMessage(int id = 0)
		{
			Id = id;
		}

	}
}
