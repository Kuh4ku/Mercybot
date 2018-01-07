using System.IO;

namespace MercyBot.Server.Messages
{
    public class AddAuthorizedTradeFromRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 22;


        // Properties
        public short MessageId => ProtocolId;

        public string Account { get; private set; }
        public int CharacterId { get; private set; }


        // Constructor
        public AddAuthorizedTradeFromRequestMessage() { }

        public AddAuthorizedTradeFromRequestMessage(string account, int characterId)
        {
            Account = account;
            CharacterId = characterId;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Account);
            writer.Write(CharacterId);
        }

        public void Deserialize(BinaryReader reader)
        {
            Account = reader.ReadString();
            CharacterId = reader.ReadInt32();
        }

    }

}