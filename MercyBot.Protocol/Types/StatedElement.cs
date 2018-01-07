using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class StatedElement
	{

		// Properties
		public uint ElementId { get; set; }
		public uint ElementCellId { get; set; }
		public uint ElementState { get; set; }


		// Constructors
		public StatedElement() { }

		public StatedElement(uint elementId = 0, uint elementCellId = 0, uint elementState = 0)
		{
			ElementId = elementId;
			ElementCellId = elementCellId;
			ElementState = elementState;
		}

	}
}
