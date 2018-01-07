using System;

namespace MercyBot.Core.Commands
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {

        // Properties
        public string Command { get; set; }


        // Constructor
        public CommandAttribute(string command)
        {
            Command = command;
        }

    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class RemainerAttribute : Attribute
    {

    }

}
