using System.Collections.Generic;

namespace MercyBot.Protocol.Types
{
	public class StartupActionAddObject
	{

		// Properties
		public List<ObjectItemInformationWithQuantity> Items { get; set; }
		public uint Uid { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string DescUrl { get; set; }
		public string PictureUrl { get; set; }


		// Constructors
		public StartupActionAddObject() { }

		public StartupActionAddObject(uint uid = 0, string title = "", string text = "", string descUrl = "", string pictureUrl = "", List<ObjectItemInformationWithQuantity> items = null)
		{
			Uid = uid;
			Title = title;
			Text = text;
			DescUrl = descUrl;
			PictureUrl = pictureUrl;
			Items = items;
		}

	}
}
