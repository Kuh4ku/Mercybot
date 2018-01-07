using System.Collections.Generic;

namespace MercyBot.Protocol.Messages
{
    public class LoginMessage : Message
    {

        // Properties
        public string Salt { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public List<sbyte> Key { get; set; }


        // Constructor
        public LoginMessage(string salt, string username, string token, List<sbyte> key)
        {
            Salt = salt;
            Username = username;
            Token = token;
            Key = key;
        }

    }
}