using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterSpellModification
	{

		// Properties
		public uint ModificationType { get; set; }
		public uint SpellId { get; set; }
		public CharacterBaseCharacteristic Value { get; set; }


		// Constructors
		public CharacterSpellModification() { }

		public CharacterSpellModification(uint modificationType = 0, uint spellId = 0, CharacterBaseCharacteristic value = null)
		{
			ModificationType = modificationType;
			SpellId = spellId;
			Value = value;
		}

	}
}
