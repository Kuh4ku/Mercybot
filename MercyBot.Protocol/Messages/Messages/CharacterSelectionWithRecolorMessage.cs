using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterSelectionWithRecolorMessage : CharacterSelectionMessage
	{

		// Properties
		public List<int> IndexedColor { get; set; }


		// Constructors
		public CharacterSelectionWithRecolorMessage() { }

		public CharacterSelectionWithRecolorMessage(int id = 0, List<int> indexedColor = null)
		{
			Id = id;
			IndexedColor = indexedColor;
		}

	}
}
