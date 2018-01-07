using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StartupActionFinishedMessage : Message
	{

		// Properties
		public bool Success { get; set; }
		public uint ActionId { get; set; }
		public bool AutomaticAction { get; set; }


		// Constructors
		public StartupActionFinishedMessage() { }

		public StartupActionFinishedMessage(bool success = false, uint actionId = 0, bool automaticAction = false)
		{
			Success = success;
			ActionId = actionId;
			AutomaticAction = automaticAction;
		}

	}
}
