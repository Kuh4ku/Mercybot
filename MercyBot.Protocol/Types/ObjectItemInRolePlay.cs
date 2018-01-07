using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectItemInRolePlay
	{

		// Properties
		public uint CellId { get; set; }
		public uint ObjectGID { get; set; }


		// Constructors
		public ObjectItemInRolePlay() { }

		public ObjectItemInRolePlay(uint cellId = 0, uint objectGID = 0)
		{
			CellId = cellId;
			ObjectGID = objectGID;
		}

	}
}
