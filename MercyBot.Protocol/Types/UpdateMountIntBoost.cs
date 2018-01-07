using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class UpdateMountIntBoost : UpdateMountBoost
	{

		// Properties
		public int Value { get; set; }


		// Constructors
		public UpdateMountIntBoost() { }

		public UpdateMountIntBoost(int type = 0, int value = 0)
		{
			Type = type;
			Value = value;
		}

	}
}
