using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ServerSessionConstantLong : ServerSessionConstant
	{

		// Properties
		public double Value { get; set; }


		// Constructors
		public ServerSessionConstantLong() { }

		public ServerSessionConstantLong(uint id = 0, double value = 0)
		{
			Id = id;
			Value = value;
		}

	}
}
