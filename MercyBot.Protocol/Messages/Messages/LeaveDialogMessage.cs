using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LeaveDialogMessage : Message
	{

		// Properties
		public uint DialogType { get; set; }


		// Constructors
		public LeaveDialogMessage() { }

		public LeaveDialogMessage(uint dialogType = 0)
		{
			DialogType = dialogType;
		}

	}
}
