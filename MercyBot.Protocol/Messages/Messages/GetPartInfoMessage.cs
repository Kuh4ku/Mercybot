using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GetPartInfoMessage : Message
	{

		// Properties
		public string Id { get; set; }


		// Constructors
		public GetPartInfoMessage() { }

		public GetPartInfoMessage(string id = "")
		{
			Id = id;
		}

	}
}
