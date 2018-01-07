using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ServerSessionConstantString : ServerSessionConstant
	{

		// Properties
		public string Value { get; set; }


		// Constructors
		public ServerSessionConstantString() { }

		public ServerSessionConstantString(uint id = 0, string value = "")
		{
			Id = id;
			Value = value;
		}

	}
}
