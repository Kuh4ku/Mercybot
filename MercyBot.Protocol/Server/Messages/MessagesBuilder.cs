using System;
using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public static class MessagesBuilder
    {

        // Fields
        private static Dictionary<short, Type> _messages;


        // Constructor
        static MessagesBuilder()
        {
            _messages = new Dictionary<short, Type>();
            var ismType = typeof(IServerMessage);

            foreach (var type in ismType.Assembly.GetTypes())
            {
                if (ismType == type)
                    continue;

                if (ismType.IsAssignableFrom(type))
                {
                    var protocolIdField = type.GetField("ProtocolId");
                    short messageId = Convert.ToInt16(protocolIdField.GetValue(type));

                    _messages.Add(messageId, type);
                }
            }

        }


        public static IServerMessage BuildMessage(byte[] data)
        {
            // If the data doesn't even have enough for the message id
            if (data == null || data.Length < 2)
                return null;

            IServerMessage message = null;

            using (BinaryReader reader = new BinaryReader(new MemoryStream(data)))
            {
                short messageId = reader.ReadInt16();

                if (_messages.ContainsKey(messageId))
                {
                    message = Activator.CreateInstance(_messages[messageId]) as IServerMessage;
                    message.Deserialize(reader);
                }
            }

            return message;
        }

    }
}
