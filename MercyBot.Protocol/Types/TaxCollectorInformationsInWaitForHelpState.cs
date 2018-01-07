using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorInformationsInWaitForHelpState : TaxCollectorInformations
	{

		// Properties
		public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }


		// Constructors
		public TaxCollectorInformationsInWaitForHelpState() { }

		public TaxCollectorInformationsInWaitForHelpState(int uniqueId = 0, uint firtNameId = 0, uint lastNameId = 0, AdditionalTaxCollectorInformations additionalInfos = null, int worldX = 0, int worldY = 0, uint subAreaId = 0, int state = 0, EntityLook look = null, uint kamas = 0, double experience = 0, uint pods = 0, uint itemsValue = 0, ProtectedEntityWaitingForHelpInfo waitingForHelpInfo = null)
		{
			UniqueId = uniqueId;
			FirtNameId = firtNameId;
			LastNameId = lastNameId;
			AdditionalInfos = additionalInfos;
			WorldX = worldX;
			WorldY = worldY;
			SubAreaId = subAreaId;
			State = (uint)state;
			Look = look;
			WaitingForHelpInfo = waitingForHelpInfo;
		}

	}
}
