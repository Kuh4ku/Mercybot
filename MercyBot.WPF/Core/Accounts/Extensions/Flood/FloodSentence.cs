using MercyBot.Protocol.Enums;
using System.IO;

namespace MercyBot.Core.Accounts.Extensions.Flood
{
    public class FloodSentence
    {

        // Properties
        public string Content { get; private set; }
        public ChatActivableChannelsEnum Channel { get; private set; }
        public bool OnPlayerJoined { get; private set; }
        public bool OnPlayerLeft { get; private set; }


        // Constructor
        public FloodSentence(string content, ChatActivableChannelsEnum channel, bool onPlayerJoined, bool onPlayerLeft)
        {
            Content = content;
            Channel = channel;

            if (Channel == ChatActivableChannelsEnum.PSEUDO_CHANNEL_PRIVATE)
            {
                OnPlayerJoined = onPlayerJoined;
                OnPlayerLeft = onPlayerLeft;
            }
            else
            {
                OnPlayerJoined = false;
                OnPlayerLeft = false;
            }
        }


        public void Save(BinaryWriter bw)
        {
            bw.Write(Content);
            bw.Write((byte)Channel);
            bw.Write(OnPlayerJoined);
            bw.Write(OnPlayerLeft);
        }

        public static FloodSentence Load(BinaryReader br)
            => new FloodSentence(br.ReadString(), (ChatActivableChannelsEnum)br.ReadByte(), br.ReadBoolean(), br.ReadBoolean());

    }
}
