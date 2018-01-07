using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountEquipedErrorMessage : Message
	{

		// Properties
		public uint ErrorType { get; set; }


		// Constructors
		public MountEquipedErrorMessage() { }

		public MountEquipedErrorMessage(uint errorType = 0)
		{
			ErrorType = errorType;
		}

	}
}
