using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ContentPart
	{

		// Properties
		public string Id { get; set; }
		public uint State { get; set; }


		// Constructors
		public ContentPart() { }

		public ContentPart(string id = "", uint state = 0)
		{
			Id = id;
			State = state;
		}

	}
}
