using System.Collections.Generic;
using System.IO;

namespace MercyBot.Server.Messages
{
    public class QuickActionRequestMessage : IServerMessage
    {

        // Fields
        public const short ProtocolId = 39;


        // Properties
        public short MessageId => ProtocolId;
        public string[] Accounts { get; private set; }
        public byte Action { get; private set; }
        public string[] Parameters { get; set; }


        // Constructor
        public QuickActionRequestMessage() { }

        public QuickActionRequestMessage(string[] accounts, byte action, string[] parameters)
        {
            Accounts = accounts;
            Action = action;
            Parameters = parameters;
        }


        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Accounts.Length);
            for (int i = 0; i < Accounts.Length; i++)
                writer.Write(Accounts[i]);
            writer.Write(Action);
            writer.Write(Parameters.Length);
            for (int i = 0; i < Parameters.Length; i++)
                writer.Write(Parameters[i]);
        }

        public void Deserialize(BinaryReader reader)
        {
            int c = reader.ReadInt32();
            Accounts = new string[c];
            for (int i = 0; i < c; i++)
                Accounts[i] = reader.ReadString();
            Action = reader.ReadByte();
            c = reader.ReadInt32();
            Parameters = new string[c];
            for (int i = 0; i < c; i++)
                Parameters[i] = reader.ReadString();
        }

    }

}