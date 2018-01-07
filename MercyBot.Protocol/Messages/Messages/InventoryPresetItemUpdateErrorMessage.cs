using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryPresetItemUpdateErrorMessage : Message
	{

		// Properties
		public uint Code { get; set; }


		// Constructors
		public InventoryPresetItemUpdateErrorMessage() { }

		public InventoryPresetItemUpdateErrorMessage(uint code = 1)
		{
			Code = code;
		}

	}
}
