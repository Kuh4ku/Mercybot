using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MercyBot.Protocol.Types
{
    public static class TypesBuilder
    {

        // Fields
        private static Dictionary<string, Type> types;


        static TypesBuilder()
        {
            types = new Dictionary<string, Type>();
        }


        public static void Initialize()
        {
            foreach (var type in Assembly.GetAssembly(typeof(Message)).GetTypes())
            {
                if (!type.FullName.StartsWith("MercyBot.Protocol.Types"))
                    continue;

                types.Add(type.Name, type);
            }
        }

        public static Type GetType(string name) => types.ContainsKey(name) ? types[name] : null;

    }
}
