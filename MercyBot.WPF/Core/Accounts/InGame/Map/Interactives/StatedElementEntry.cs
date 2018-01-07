using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Map.Interactives
{
    public class StatedElementEntry
    {

        // Properties
        public short CellId { get; private set; }
        public uint Id { get; private set; }
        public byte State { get; private set; }


        // Constructor
        public StatedElementEntry(StatedElement elem)
        {
            Id = elem.ElementId;
            CellId = (short)elem.ElementCellId;
            State = (byte)elem.ElementState;
        }

    }
}
