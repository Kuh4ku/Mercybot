using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
	{

		// Constructors
		public HouseLockFromInsideRequestMessage() { }

		public HouseLockFromInsideRequestMessage(string code = "")
		{
			Code = code;
		}

	}
}
