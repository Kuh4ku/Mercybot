using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapNpcsQuestStatusUpdateMessage : Message
	{

		// Properties
		public List<int> NpcsIdsWithQuest { get; set; }
		public List<GameRolePlayNpcQuestFlag> QuestFlags { get; set; }
		public List<int> NpcsIdsWithoutQuest { get; set; }
		public int MapId { get; set; }


		// Constructors
		public MapNpcsQuestStatusUpdateMessage() { }

		public MapNpcsQuestStatusUpdateMessage(int mapId = 0, List<int> npcsIdsWithQuest = null, List<GameRolePlayNpcQuestFlag> questFlags = null, List<int> npcsIdsWithoutQuest = null)
		{
			MapId = mapId;
			NpcsIdsWithQuest = npcsIdsWithQuest;
			QuestFlags = questFlags;
			NpcsIdsWithoutQuest = npcsIdsWithoutQuest;
		}

	}
}
