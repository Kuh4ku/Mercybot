using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharactersListMessage : BasicCharactersListMessage
	{

		// Properties
		public bool HasStartupActions { get; set; }


		// Constructors
		public CharactersListMessage() { }

		public CharactersListMessage(bool hasStartupActions = false, List<CharacterBaseInformations> characters = null)
		{
			HasStartupActions = hasStartupActions;
			Characters = characters;
		}

	}
}
