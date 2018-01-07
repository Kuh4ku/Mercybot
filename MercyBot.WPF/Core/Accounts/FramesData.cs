using System.Collections.Generic;

namespace MercyBot.Core.Accounts
{
    public class FramesData : IClearable
    {

        // Properties
        public uint Sequence { get; set; }
        public int CaptchasCounter { get; set; }
        public List<sbyte> Key { get; set; }
        public string Salt { get; set; }
        public string Ticket { get; set; }
        public bool Initialized { get; set; }
        public uint ServerToAutoConnectTo { get; set; }


        // Constructor
        public FramesData()
            => Clear();


        public void Clear()
        {
            Sequence = 0;
            CaptchasCounter = 0;
            Key = null;
            Salt = null;
            Ticket = null;
            Initialized = false;
            ServerToAutoConnectTo = 0;
        }

    }
}
