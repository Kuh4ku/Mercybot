using System.IO;

namespace MercyBot.Server.Messages
{
    public class AddAuthorizedTradeFromMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 23;


        // Properties
        public short MessageId => ProtocolId;

        public string Account { get; private set; }
        public int CharacterId { get; private set; }


        // Constructor
        public AddAuthorizedTradeFromMessage() { }

        public AddAuthorizedTradeFromMessage(string account, int characterId)
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