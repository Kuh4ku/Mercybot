using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterToRelookInformation : AbstractCharacterInformation
	{

		// Properties
		public uint CosmeticId { get; set; }


		// Constructors
		public CharacterToRelookInformation() { }

		public CharacterToRelookInformation(uint id = 0, uint cosmeticId = 0)
		{
			Id = id;
			CosmeticId = cosmeticId;
		}

	}
}
