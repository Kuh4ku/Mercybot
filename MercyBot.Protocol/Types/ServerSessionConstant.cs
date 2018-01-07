using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ServerSessionConstant
	{

		// Properties
		public uint Id { get; set; }


		// Constructors
		public ServerSessionConstant() { }

		public ServerSessionConstant(uint id = 0)
		{
			Id = id;
		}

	}
}
