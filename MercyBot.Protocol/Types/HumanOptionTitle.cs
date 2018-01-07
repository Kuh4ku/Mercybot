using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HumanOptionTitle : HumanOption
	{

		// Properties
		public uint TitleId { get; set; }
		public string TitleParam { get; set; }


		// Constructors
		public HumanOptionTitle() { }

		public HumanOptionTitle(uint titleId = 0, string titleParam = "")
		{
			TitleId = titleId;
			TitleParam = titleParam;
		}

	}
}
