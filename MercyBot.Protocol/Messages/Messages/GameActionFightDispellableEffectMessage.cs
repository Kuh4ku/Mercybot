using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public AbstractFightDispellableEffect Effect { get; set; }


		// Constructors
		public GameActionFightDispellableEffectMessage() { }

		public GameActionFightDispellableEffectMessage(uint actionId = 0, int sourceId = 0, AbstractFightDispellableEffect effect = null)
		{
			ActionId = actionId;
			SourceId = sourceId;
			Effect = effect;
		}

	}
}
