using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectionWithRenameMessage : CharacterSelectionMessage
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public CharacterSelectionWithRenameMessage() { }

		public CharacterSelectionWithRenameMessage(int id = 0, string name = "")
		{
			Id = id;
			Name = name;
		}

	}
}
