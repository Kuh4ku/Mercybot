using System.Collections.Generic;
using System.IO;

namespace MercyBot.Configurations
{
    public class CharacterCreation
    {

        // Properties
        public bool Create { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public int Breed { get; set; }
        public int Sex { get; set; }
        public int Head { get; set; }
        public List<int> Colors { get; set; }
        public string ParametersToCopy { get; set; }
        public string FightsConfigurationToCopy { get; set; }
        public bool CompleteTutorial { get; set; }


        public void Save(BinaryWriter writer)
        {
            writer.Write(Create);

            if (!Create)
                return;

            writer.Write(Name);
            writer.Write(Server);
            writer.Write(Breed);
            writer.Write(Sex);
            writer.Write(Head);
            Colors.ForEach(writer.Write);
            writer.Write(ParametersToCopy);
            writer.Write(FightsConfigurationToCopy);
            writer.Write(CompleteTutorial);
        }

        public void Load(BinaryReader reader)
        {
            Create = reader.ReadBoolean();

            if (!Create)
                return;

            Name = reader.ReadString();
            Server = reader.ReadString();
            Breed = reader.ReadInt32();
            Sex = reader.ReadInt32();
            Head = reader.ReadInt32();
            Colors = new List<int>();
            for (int i = 0; i < 5; i++)
                Colors.Add(reader.ReadInt32());
            ParametersToCopy = reader.ReadString();
            FightsConfigurationToCopy = reader.ReadString();
            CompleteTutorial = reader.ReadBoolean();
        }

    }
}
