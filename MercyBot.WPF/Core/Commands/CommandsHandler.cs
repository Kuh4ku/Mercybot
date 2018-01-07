using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MercyBot.Core.Commands
{
    public static class CommandsHandler
    {

        // Fields
        private static readonly Dictionary<string, List<MethodInfo>> _commandsHandlers;


        // Constructor
        static CommandsHandler()
        {
            _commandsHandlers = new Dictionary<string, List<MethodInfo>>();
        }


        public static void Initialize()
        {
            foreach (var type in typeof(CommandsHandler).GetTypeInfo().Assembly.GetTypes())
            {
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    // If this method doesn't return a Task
                    if (method.ReturnType != typeof(Task))
                        continue;

                    var cmdAttribute = method.GetCustomAttribute<CommandAttribute>();
                    if (cmdAttribute != null)
                    {
                        // If a command handler already exists
                        if (_commandsHandlers.ContainsKey(cmdAttribute.Command))
                            continue;

                        // Ensure it exists
                        if (!_commandsHandlers.ContainsKey(cmdAttribute.Command))
                            _commandsHandlers.Add(cmdAttribute.Command, new List<MethodInfo>());
                        
                        _commandsHandlers[cmdAttribute.Command].Add(method);
                    }
                }
            }
        }

        public static List<MethodInfo> GetCommandHandlers(string command)
        {
            if (!_commandsHandlers.ContainsKey(command))
                return null;

            return _commandsHandlers[command];
        }

    }
}
