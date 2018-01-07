using System.Collections.Generic;
using MercyBot.Protocol.Converters;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Messages
{
	public class QuestStepInfoMessage : Message
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public QuestActiveInformations Infos { get; set; }


		// Constructors
		public QuestStepInfoMessage() { }

		public QuestStepInfoMessage(QuestActiveInformations infos = null)
		{
			Infos = infos;
		}

	}
}
