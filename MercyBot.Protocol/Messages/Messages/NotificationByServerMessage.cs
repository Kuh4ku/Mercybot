using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NotificationByServerMessage : Message
	{

		// Properties
		public List<string> Parameters { get; set; }
		public uint Id { get; set; }
		public bool ForceOpen { get; set; }


		// Constructors
		public NotificationByServerMessage() { }

		public NotificationByServerMessage(uint id = 0, bool forceOpen = false, List<string> parameters = null)
		{
			Id = id;
			ForceOpen = forceOpen;
			Parameters = parameters;
		}

	}
}
