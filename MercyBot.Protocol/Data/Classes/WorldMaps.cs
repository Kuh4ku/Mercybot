using Newtonsoft.Json;
using System.Collections.Generic;

namespace MercyBot.Protocol.Data
{
	public class WorldMaps : IData
	{

		// Properties
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("origineX")]
		public int OrigineX { get; set; }
		[JsonProperty("origineY")]
		public int OrigineY { get; set; }
		[JsonProperty("mapWidth")]
		public float MapWidth { get; set; }
		[JsonProperty("mapHeight")]
		public float MapHeight { get; set; }
		[JsonProperty("horizontalChunck")]
		public int HorizontalChunck { get; set; }
		[JsonProperty("verticalChunck")]
		public int VerticalChunck { get; set; }
		[JsonProperty("viewableEverywhere")]
		public bool ViewableEverywhere { get; set; }
		[JsonProperty("minScale")]
		public float MinScale { get; set; }
		[JsonProperty("maxScale")]
		public int MaxScale { get; set; }
		[JsonProperty("startScale")]
		public float StartScale { get; set; }
		[JsonProperty("centerX")]
		public int CenterX { get; set; }
		[JsonProperty("centerY")]
		public int CenterY { get; set; }
		[JsonProperty("totalWidth")]
		public int TotalWidth { get; set; }
		[JsonProperty("totalHeight")]
		public int TotalHeight { get; set; }
		[JsonProperty("zoom")]
		public List<string> Zoom { get; set; }


		//Constructor
		internal WorldMaps() {}

	}
}
