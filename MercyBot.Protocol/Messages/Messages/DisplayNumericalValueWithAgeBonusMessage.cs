using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DisplayNumericalValueWithAgeBonusMessage : DisplayNumericalValueMessage
	{

		// Properties
		public int ValueOfBonus { get; set; }


		// Constructors
		public DisplayNumericalValueWithAgeBonusMessage() { }

		public DisplayNumericalValueWithAgeBonusMessage(int entityId = 0, int value = 0, uint type = 0, int valueOfBonus = 0)
		{
			EntityId = entityId;
			Value = value;
			Type = type;
			ValueOfBonus = valueOfBonus;
		}

	}
}
