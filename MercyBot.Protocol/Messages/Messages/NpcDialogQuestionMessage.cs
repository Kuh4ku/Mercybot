using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NpcDialogQuestionMessage : Message
	{

		// Properties
		public List<string> DialogParams { get; set; }
		public List<uint> VisibleReplies { get; set; }
		public uint MessageId { get; set; }


		// Constructors
		public NpcDialogQuestionMessage() { }

		public NpcDialogQuestionMessage(uint messageId = 0, List<string> dialogParams = null, List<uint> visibleReplies = null)
		{
			MessageId = messageId;
			DialogParams = dialogParams;
			VisibleReplies = visibleReplies;
		}

	}
}
