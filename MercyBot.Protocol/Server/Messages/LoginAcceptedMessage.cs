using System.IO;

namespace MercyBot.Server.Messages
{
    public class LoginAcceptedMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 4;


        // Properties
        public short MessageId => ProtocolId;
        public string Name { get; private set; }
        public string Avatar { get; private set; }


        // Constructor
        public LoginAcceptedMessage() { }

        public LoginAcceptedMessage(string name, string avatar)
        {
            Name = name;
            Avatar = avatar;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Avatar);
        }

        public void Deserialize(BinaryReader reader)
        {
            Name = reader.ReadString();
            Avatar = reader.ReadString();
        }

    }

}