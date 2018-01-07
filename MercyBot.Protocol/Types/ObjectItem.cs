using System.Collections.Generic;
using MercyBot.Protocol.Converters;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Types
{
    public class ObjectItem : Item
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public List<ObjectEffect> Effects { get; set; }
		public uint Position { get; set; }
		public uint ObjectGID { get; set; }
		public uint ObjectUID { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ObjectItem() { }

		public ObjectItem(uint position = 63, uint objectGID = 0, uint objectUID = 0, uint quantity = 0, List<ObjectEffect> effects = null)
		{
			Position = position;
			ObjectGID = objectGID;
			ObjectUID = objectUID;
			Quantity = quantity;
			Effects = effects;
		}

	}
}
