using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterFirstSelectionMessage : CharacterSelectionMessage
	{

		// Properties
		public bool DoTutorial { get; set; }


		// Constructors
		public CharacterFirstSelectionMessage() { }

		public CharacterFirstSelectionMessage(int id = 0, bool doTutorial = false)
		{
			Id = id;
			DoTutorial = doTutorial;
		}

	}
}
