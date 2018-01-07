using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectedSuccessMessage : Message
	{

		// Properties
		public CharacterBaseInformations Infos { get; set; }


		// Constructors
		public CharacterSelectedSuccessMessage() { }

		public CharacterSelectedSuccessMessage(CharacterBaseInformations infos = null)
		{
			Infos = infos;
		}

	}
}
