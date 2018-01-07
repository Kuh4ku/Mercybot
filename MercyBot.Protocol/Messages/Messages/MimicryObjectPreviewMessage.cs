using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MimicryObjectPreviewMessage : Message
	{

		// Properties
		public ObjectItem Result { get; set; }


		// Constructors
		public MimicryObjectPreviewMessage() { }

		public MimicryObjectPreviewMessage(ObjectItem result = null)
		{
			Result = result;
		}

	}
}
