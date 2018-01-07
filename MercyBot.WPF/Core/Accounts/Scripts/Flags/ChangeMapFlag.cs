namespace MercyBot.Core.Accounts.Scripts.Flags
{
    public class ChangeMapFlag : IFlag
    {

        // Properties
        public string Where { get; private set; }


        // Constructor
        public ChangeMapFlag(string where)
        {
            Where = where;
        }

    }
}
