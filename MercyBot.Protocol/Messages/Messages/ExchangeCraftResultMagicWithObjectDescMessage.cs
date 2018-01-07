using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
	{

		// Properties
		public int MagicPoolStatus { get; set; }


		// Constructors
		public ExchangeCraftResultMagicWithObjectDescMessage() { }

		public ExchangeCraftResultMagicWithObjectDescMessage(uint craftResult = 0, ObjectItemNotInContainer objectInfo = null, int magicPoolStatus = 0)
		{
			CraftResult = craftResult;
			ObjectInfo = objectInfo;
			MagicPoolStatus = magicPoolStatus;
		}

	}
}
