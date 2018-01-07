using System;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MercyBot.Protocol.Messages
{
    public static class MessagesBuilder
    {

        // Fields
        private static readonly Dictionary<string, Type> _types;


        // Constructor
        static MessagesBuilder()
        {
            _types = new Dictionary<string, Type>();
        }


        public static void Initialize()
        {
            Assembly ass = Assembly.GetAssembly(typeof(Message));
            foreach (var type in ass.GetTypes())
            {
                if (!typeof(Message).IsAssignableFrom(type) || type == typeof(Message))
                    continue;

                var typeName = type.Name.Replace("Message", "");
                _types.Add(typeName.ToLower(), type);
            }
        }

        public static Message GetMessage(string type, JObject data)
        {
            type = type.Replace("Message", "").ToLower();

            if (!_types.ContainsKey(type))
                return null;

            var t = _types[type];
            return data.ToObject(t) as Message;
        }

    }
}