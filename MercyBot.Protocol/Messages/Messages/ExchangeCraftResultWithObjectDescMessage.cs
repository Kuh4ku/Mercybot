using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
	{

		// Properties
		public ObjectItemNotInContainer ObjectInfo { get; set; }


		// Constructors
		public ExchangeCraftResultWithObjectDescMessage() { }

		public ExchangeCraftResultWithObjectDescMessage(uint craftResult = 0, ObjectItemNotInContainer objectInfo = null)
		{
			CraftResult = craftResult;
			ObjectInfo = objectInfo;
		}

	}
}
