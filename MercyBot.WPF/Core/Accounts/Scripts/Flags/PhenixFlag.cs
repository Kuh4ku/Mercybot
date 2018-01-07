namespace MercyBot.Core.Accounts.Scripts.Flags
{
    public class PhenixFlag : IFlag
    {

        // Properties
        public short CellId { get; private set; }


        // Constructor
        public PhenixFlag(short cellId)
        {
            CellId = cellId;
        }

    }
}
