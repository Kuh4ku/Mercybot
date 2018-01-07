namespace MercyBot.Core.Accounts.Scripts.Flags
{
    public class DoorFlag : IFlag
    {

        // Properties
        public short CellId { get; private set; }


        // Constructor
        public DoorFlag(short cellId)
        {
            CellId = cellId;
        }

    }
}
