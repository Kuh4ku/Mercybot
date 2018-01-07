using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountRenameRequestMessage : Message
	{

		// Properties
		public string Name { get; set; }
		public double MountId { get; set; }


		// Constructors
		public MountRenameRequestMessage() { }

		public MountRenameRequestMessage(string name = "", double mountId = 0)
		{
			Name = name;
			MountId = mountId;
		}

	}
}
