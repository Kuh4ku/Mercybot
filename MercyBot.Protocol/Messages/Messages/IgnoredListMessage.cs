using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredListMessage : Message
	{

		// Properties
		public List<IgnoredInformations> IgnoredList { get; set; }


		// Constructors
		public IgnoredListMessage() { }

		public IgnoredListMessage(List<IgnoredInformations> ignoredList = null)
		{
			IgnoredList = ignoredList;
		}

	}
}
