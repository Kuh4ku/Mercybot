using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StartupActionsListMessage : Message
	{

		// Properties
		public List<StartupActionAddObject> Actions { get; set; }


		// Constructors
		public StartupActionsListMessage() { }

		public StartupActionsListMessage(List<StartupActionAddObject> actions = null)
		{
			Actions = actions;
		}

	}
}
