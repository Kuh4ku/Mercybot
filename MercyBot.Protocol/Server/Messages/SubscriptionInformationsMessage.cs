using ExtensionsEnum = MercyBot.Protocol.Server.Enums.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using MercyBot.Protocol;

namespace MercyBot.Server.Messages
{
    public class SubscriptionInformationsMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 5;


        // Properties
        public short MessageId => ProtocolId;
        public DateTime? TouchEndDate { get; private set; }
        public Dictionary<ExtensionsEnum, DateTime> Extensions { get; }


        // Constructor
        public SubscriptionInformationsMessage()
        {
            Extensions = new Dictionary<ExtensionsEnum, DateTime>();
        }

        public SubscriptionInformationsMessage(DateTime? touchEndDate, Dictionary<ExtensionsEnum, DateTime> extensions)
        {
            TouchEndDate = touchEndDate;
            Extensions = extensions;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write((long)(TouchEndDate == null ? 0 : (TouchEndDate.Value - DateTime.MinValue).TotalMilliseconds));
            writer.Write(Extensions.Count);
            foreach (var kvp in Extensions)
            {
                writer.Write((byte)kvp.Key);
                writer.Write((long)(kvp.Value - DateTime.MinValue).TotalMilliseconds);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            long until = reader.ReadInt64();
            TouchEndDate = until == 0 ? null : new DateTime().AddMilliseconds(until) as DateTime?;
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Extensions.Add((ExtensionsEnum)reader.ReadByte(), new DateTime().AddMilliseconds(reader.ReadInt64()));
            }
        }

    }

}