using System.Runtime.Serialization;

namespace HashTool
{
    [DataContract]
    public class File
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="hash")]
        public string Hash { get; set; }

        public File(string name, string hash)
        {
            Name = name;
            Hash = hash;
        }
    }
}
