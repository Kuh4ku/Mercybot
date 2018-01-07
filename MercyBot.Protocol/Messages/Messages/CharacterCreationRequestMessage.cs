using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterCreationRequestMessage : Message
	{

		// Properties
		public List<int> Colors { get; set; }
		public string Name { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public uint CosmeticId { get; set; }


		// Constructors
		public CharacterCreationRequestMessage() { }

		public CharacterCreationRequestMessage(string name = "", int breed = 0, bool sex = false, uint cosmeticId = 0, List<int> colors = null)
		{
			Name = name;
			Breed = breed;
			Sex = sex;
			CosmeticId = cosmeticId;
			Colors = colors;
		}

	}
}
