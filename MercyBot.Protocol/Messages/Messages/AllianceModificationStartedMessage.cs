using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceModificationStartedMessage : Message
	{

		// Properties
		public bool CanChangeName { get; set; }
		public bool CanChangeTag { get; set; }
		public bool CanChangeEmblem { get; set; }


		// Constructors
		public AllianceModificationStartedMessage() { }

		public AllianceModificationStartedMessage(bool canChangeName = false, bool canChangeTag = false, bool canChangeEmblem = false)
		{
			CanChangeName = canChangeName;
			CanChangeTag = canChangeTag;
			CanChangeEmblem = canChangeEmblem;
		}

	}
}
