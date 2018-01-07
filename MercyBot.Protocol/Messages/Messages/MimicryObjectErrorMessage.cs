using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MimicryObjectErrorMessage : ObjectErrorMessage
	{

		// Properties
		public bool Preview { get; set; }
		public int ErrorCode { get; set; }


		// Constructors
		public MimicryObjectErrorMessage() { }

		public MimicryObjectErrorMessage(int reason = 0, bool preview = false, int errorCode = 0)
		{
			Reason = reason;
			Preview = preview;
			ErrorCode = errorCode;
		}

	}
}
