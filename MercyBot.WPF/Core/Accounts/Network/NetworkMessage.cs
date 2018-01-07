using System;

namespace MercyBot.Core.Accounts.Network
{
    public class NetworkMessage
    {

        // Properties
        public string Message { get; }
        public bool Sent { get; }
        public DateTime Time { get; }


        // Constructor
        public NetworkMessage(string message, bool sent)
        {
            Message = message;
            Sent = sent;
            Time = DateTime.Now;
        }

    }

}
