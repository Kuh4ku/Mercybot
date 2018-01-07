using System;
using System.Threading.Tasks;

namespace MercyBot.Core.Accounts.Network
{
    public class RegisteredMessage
    {

        // Properties
        public Type Type { get; }
        public Func<Account, object, Task> Action { get; }


        // Constructor
        public RegisteredMessage(Type type, Func<Account, object, Task> action)
        {
            Type = type;
            Action = action;
        }

    }
}