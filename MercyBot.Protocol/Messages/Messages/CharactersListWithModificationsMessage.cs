using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharactersListWithModificationsMessage : CharactersListMessage
	{

		// Properties
		public List<CharacterToRecolorInformation> CharactersToRecolor { get; set; }
		public List<int> CharactersToRename { get; set; }
		public List<int> UnusableCharacters { get; set; }
		public List<CharacterToRelookInformation> CharactersToRelook { get; set; }


		// Constructors
		public CharactersListWithModificationsMessage() { }

		public CharactersListWithModificationsMessage(bool hasStartupActions = false, List<CharacterBaseInformations> characters = null, List<CharacterToRecolorInformation> charactersToRecolor = null, List<int> charactersToRename = null, List<int> unusableCharacters = null, List<CharacterToRelookInformation> charactersToRelook = null)
		{
			HasStartupActions = hasStartupActions;
			Characters = characters;
			CharactersToRecolor = charactersToRecolor;
			CharactersToRename = charactersToRename;
			UnusableCharacters = unusableCharacters;
			CharactersToRelook = charactersToRelook;
		}

	}
}
