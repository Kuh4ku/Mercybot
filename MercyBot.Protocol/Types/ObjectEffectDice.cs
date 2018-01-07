using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectDice : ObjectEffect
	{

		// Properties
		public uint DiceNum { get; set; }
		public uint DiceSide { get; set; }
		public uint DiceConst { get; set; }


		// Constructors
		public ObjectEffectDice() { }

		public ObjectEffectDice(uint actionId = 0, uint diceNum = 0, uint diceSide = 0, uint diceConst = 0)
		{
			ActionId = actionId;
			DiceNum = diceNum;
			DiceSide = diceSide;
			DiceConst = diceConst;
		}

	}
}
