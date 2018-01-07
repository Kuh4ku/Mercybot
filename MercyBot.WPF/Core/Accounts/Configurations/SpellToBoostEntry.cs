namespace MercyBot.Core.Accounts.Configurations
{
    public class SpellToBoostEntry
    {

        // Properties
        public int Id { get; }
        public string Name { get; }
        public byte Level { get; }


        // Constructor
        public SpellToBoostEntry(int spellId, string name, byte level)
        {
            Id = spellId;
            Name = name;
            Level = level;
        }

    }
}
