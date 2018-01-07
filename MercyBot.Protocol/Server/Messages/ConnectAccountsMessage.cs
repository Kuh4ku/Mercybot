using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class ConnectAccountsMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 13;


        // Properties
        public short MessageId => ProtocolId;
        public List<string> Usernames { get; private set; }


        // Constructor
        public ConnectAccountsMessage()
        {
            Usernames = new List<string>();
        }

        public ConnectAccountsMessage(List<string> usernames)
        {
            Usernames = usernames;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Usernames.Count);
            for (int i = 0; i < Usernames.Count; i++)
            {
                writer.Write(Usernames[i]);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Usernames.Add(reader.ReadString());
            }
        }

    }

}