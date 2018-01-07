using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterNameSuggestionSuccessMessage : Message
	{

		// Properties
		public string Suggestion { get; set; }


		// Constructors
		public CharacterNameSuggestionSuccessMessage() { }

		public CharacterNameSuggestionSuccessMessage(string suggestion = "")
		{
			Suggestion = suggestion;
		}

	}
}
