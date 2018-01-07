namespace MercyBot.Core.Accounts.InGame.Map.Interactives
{
    public class ElementInCellEntry
    {

        // Properties
        public InteractiveElementEntry Element { get; }
        public short CellId { get; }


        // Constructor
        public ElementInCellEntry(InteractiveElementEntry element, short cellId)
        {
            Element = element;
            CellId = cellId;
        }

    }
}
