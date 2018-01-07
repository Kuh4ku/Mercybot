using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LockableShowCodeDialogMessage : Message
	{

		// Properties
		public bool ChangeOrUse { get; set; }
		public uint CodeSize { get; set; }


		// Constructors
		public LockableShowCodeDialogMessage() { }

		public LockableShowCodeDialogMessage(bool changeOrUse = false, uint codeSize = 0)
		{
			ChangeOrUse = changeOrUse;
			CodeSize = codeSize;
		}

	}
}
