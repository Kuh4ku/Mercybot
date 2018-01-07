using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorInformations
	{

		// Properties
		public List<TaxCollectorComplementaryInformations> Complements { get; set; }
		public int UniqueId { get; set; }
		public uint FirtNameId { get; set; }
		public uint LastNameId { get; set; }
		public AdditionalTaxCollectorInformations AdditionalInfos { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public uint SubAreaId { get; set; }
		public uint State { get; set; }
		public EntityLook Look { get; set; }


		// Constructors
		public TaxCollectorInformations() { }

		public TaxCollectorInformations(int uniqueId = 0, uint firtNameId = 0, uint lastNameId = 0, AdditionalTaxCollectorInformations additionalInfos = null, int worldX = 0, int worldY = 0, uint subAreaId = 0, uint state = 0, EntityLook look = null, List<TaxCollectorComplementaryInformations> complements = null)
		{
			UniqueId = uniqueId;
			FirtNameId = firtNameId;
			LastNameId = lastNameId;
			AdditionalInfos = additionalInfos;
			WorldX = worldX;
			WorldY = worldY;
			SubAreaId = subAreaId;
			State = state;
			Look = look;
			Complements = complements;
		}

	}
}
