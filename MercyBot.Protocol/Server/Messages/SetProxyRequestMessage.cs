using System.IO;

namespace MercyBot.Server.Messages
{
    public class SetProxyRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 20;


        // Properties
        public short MessageId => ProtocolId;

        public string Account { get; private set; }
        public string IpAddress { get; private set; }
        public ushort Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }


        // Constructor
        public SetProxyRequestMessage() { }

        public SetProxyRequestMessage(string account, string ipAddress, ushort port, string username, string password)
        {
            Account = account;
            IpAddress = ipAddress;
            Port = port;
            Username = username;
            Password = password;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Account);
            writer.Write(IpAddress);
            writer.Write(Port);
            writer.Write(Username);
            writer.Write(Password);
        }

        public void Deserialize(BinaryReader reader)
        {
            Account = reader.ReadString();
            IpAddress = reader.ReadString();
            Port = reader.ReadUInt16();
            Username = reader.ReadString();
            Password = reader.ReadString();
        }

    }

}