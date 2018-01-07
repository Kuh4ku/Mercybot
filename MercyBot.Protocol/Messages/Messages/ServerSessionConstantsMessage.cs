using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServerSessionConstantsMessage : Message
	{

		// Properties
		public List<ServerSessionConstant> Variables { get; set; }


		// Constructors
		public ServerSessionConstantsMessage() { }

		public ServerSessionConstantsMessage(List<ServerSessionConstant> variables = null)
		{
			Variables = variables;
		}

	}
}
