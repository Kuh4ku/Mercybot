using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockItem : ObjectItemInRolePlay
	{

		// Properties
		public ItemDurability Durability { get; set; }


		// Constructors
		public PaddockItem() { }

		public PaddockItem(uint cellId = 0, uint objectGID = 0, ItemDurability durability = null)
		{
			CellId = cellId;
			ObjectGID = objectGID;
			Durability = durability;
		}

	}
}
