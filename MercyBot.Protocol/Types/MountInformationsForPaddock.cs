using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class MountInformationsForPaddock
	{

		// Properties
		public int ModelId { get; set; }
		public string Name { get; set; }
		public string OwnerName { get; set; }


		// Constructors
		public MountInformationsForPaddock() { }

		public MountInformationsForPaddock(int modelId = 0, string name = "", string ownerName = "")
		{
			ModelId = modelId;
			Name = name;
			OwnerName = ownerName;
		}

	}
}
