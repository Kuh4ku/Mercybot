using MoonSharp.Interpreter;

namespace MercyBot.Core.Accounts.Scripts.Flags
{
    public class CustomFlag : IFlag
    {

        // Properties
        public DynValue Function { get; private set; }


        // Constructor
        public CustomFlag(DynValue function)
        {
            Function = function;
        }

    }
}
