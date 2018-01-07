using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterToRecolorInformation : AbstractCharacterInformation
	{

		// Properties
		public List<int> Colors { get; set; }


		// Constructors
		public CharacterToRecolorInformation() { }

		public CharacterToRecolorInformation(uint id = 0, List<int> colors = null)
		{
			Id = id;
			Colors = colors;
		}

	}
}
