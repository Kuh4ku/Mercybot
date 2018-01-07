using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PauseDialogMessage : Message
	{

		// Properties
		public uint DialogType { get; set; }


		// Constructors
		public PauseDialogMessage() { }

		public PauseDialogMessage(uint dialogType = 0)
		{
			DialogType = dialogType;
		}

	}
}
