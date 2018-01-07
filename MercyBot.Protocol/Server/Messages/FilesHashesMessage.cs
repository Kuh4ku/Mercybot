using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class FilesHashesMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 35;


        // Properties
        public short MessageId => ProtocolId;
        public Dictionary<string, string> FilesHashes { get; }


        // Constructor
        public FilesHashesMessage()
        {
            FilesHashes = new Dictionary<string, string>();
        }

        public FilesHashesMessage(Dictionary<string, string> filesHashes)
        {
            FilesHashes = filesHashes;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(FilesHashes.Count);
            foreach (var kvp in FilesHashes)
            {
                writer.Write(kvp.Key);
                writer.Write(kvp.Value);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                FilesHashes.Add(reader.ReadString(), reader.ReadString());
            }
        }

    }

}