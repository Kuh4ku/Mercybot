using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectMount : ObjectEffect
	{

		// Properties
		public uint MountId { get; set; }
		public double Date { get; set; }
		public uint ModelId { get; set; }


		// Constructors
		public ObjectEffectMount() { }

		public ObjectEffectMount(uint actionId = 0, uint mountId = 0, double date = 0, uint modelId = 0)
		{
			ActionId = actionId;
			MountId = mountId;
			Date = date;
			ModelId = modelId;
		}

	}
}
