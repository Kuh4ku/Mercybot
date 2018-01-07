using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using MercyBot.Utility.Security;
using System.IO;
using System.Linq;

namespace MercyBot.Configurations
{
    public class AccountConfiguration : ViewModelBase
    {

        // Fields
        private bool _planificationActivated;


        // Properties
        public string Username { get; }
        public string Password { get; }
        public string Server { get; }
        public string Character { get; }
        public string Nickname { get; }
        public ProxyConfiguration Proxy { get; private set; }
        public CharacterCreation CharacterCreation { get; set; }
        public bool PlanificationActivated
        {
            get => _planificationActivated;
            set
            {
                Set(ref _planificationActivated, value);
                GlobalConfiguration.Instance.Save();
            }
        }
        public ObservableCollection<bool> Planification { get; }


        // Constructor
        public AccountConfiguration(string username, string password, string server, string character, string nickname)
        {
            Username = username;
            Password = password;
            Server = server;
            Character = character;
            Nickname = nickname;
            Proxy = new ProxyConfiguration();
            CharacterCreation = new CharacterCreation();
            Planification = new ObservableCollection<bool>(Enumerable.Repeat(true, 24));
        }


        public void SetProxy(string ip, ushort port, string username, string password)
        {
            Proxy.Ip = ip;
            Proxy.Port = port;
            Proxy.Username = username;
            Proxy.Password = password;

            RaisePropertyChanged("Proxy");
        }

        public void Save(BinaryWriter bw)
        {
            bw.Write(Username);
            bw.Write(AESEncryption.Encrypt(Password, "M€rcy$Bôt"));
            bw.Write(Server);
            bw.Write(Character);
            bw.Write(Nickname);

            bw.Write(Proxy.Ip);
            bw.Write(Proxy.Port);
            bw.Write(Proxy.Username);
            bw.Write(Proxy.Password);

            CharacterCreation.Save(bw);
        }

        public static AccountConfiguration Load(BinaryReader br)
        {
            try
            {
                var acc = new AccountConfiguration(br.ReadString(), AESEncryption.Decrypt(br.ReadString(), "M€rcy$Bôt"), br.ReadString(), br.ReadString(), br.ReadString());

                acc.Proxy = new ProxyConfiguration
                {
                    Ip = br.ReadString(),
                    Port = br.ReadUInt16(),
                    Username = br.ReadString(),
                    Password = br.ReadString()
                };

                acc.CharacterCreation.Load(br);

                return acc;
            }
            catch
            {
                return null;
            }
        }

    }

    public class ProxyConfiguration
    {

        // Properties
        public string Ip { get; set; }
        public ushort Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsValid => Ip.Length > 0;
        public string Url => Ip.Length > 0 ? $"http://{Ip}:{Port}" : "";


        // Constructor
        public ProxyConfiguration()
        {
            Ip = "";
            Port = 0;
            Username = "";
            Password = "";
        }

    }

}
