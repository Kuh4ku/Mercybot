using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagesCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(textBox1.Text).SubItems.Add(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength == 0)
                return;

            Dictionary<string, string> properties = new Dictionary<string, string>();
            foreach (ListViewItem item in listView1.Items)
            {
                properties.Add(item.Text, item.SubItems[1].Text);
            }

            StringBuilder sb = new StringBuilder();

            //using System.IO;
            sb.AppendLine("using System.IO;" + Environment.NewLine);

            //namespace MercyBot.Server.Messages
            sb.AppendLine("namespace MercyBot.Server.Messages");
            sb.AppendLine("{");
            //    {
            //        public class LoginRequestMessage : IServerMessage
            sb.AppendLine($"\tpublic class {textBox4.Text} : IServerMessage");
            sb.AppendLine("\t{");
            //        {

            sb.AppendLine(Environment.NewLine + "\t\t// Fields");
            //            // Fields
            //            public const short ProtocolId = 2;
            sb.AppendLine($"\t\tpublic const short ProtocolId = {numericUpDown1.Value};");


            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("\t\t// Properties");
            sb.AppendLine("\t\tpublic short MessageId => ProtocolId;");
            //            // Properties
            //            public short MessageId => 2;
            //            public string Username { get; private set; }
            //            public string Password { get; private set; }
            foreach (var kvp in properties)
            {
                sb.AppendLine($"\t\tpublic {kvp.Value} {kvp.Key} {{ get; private set; }}");
            }

            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("\t\t// Constructor");
            //            // Constructor
            //            public LoginRequestMessage() { }
            sb.AppendLine($"\t\tpublic {textBox4.Text}() {{ }}");

            //            public LoginRequestMessage(string username, string password)
            //            {
            //                Username = username;
            //                Password = password;
            //            }
            if (properties.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine($"\t\tpublic {textBox4.Text}({properties.Select(kvp => $"{kvp.Value} {ToPascal(kvp.Key)}").Aggregate((c, n) => $"{c}, {n}")})");
                sb.AppendLine("\t\t{");

                foreach (var kvp in properties)
                {
                    sb.AppendLine($"\t\t\t{kvp.Key} = {ToPascal(kvp.Key)};");
                }

                sb.AppendLine("\t\t}");
            }

            sb.AppendLine(Environment.NewLine);

            //            public void Serialize(BinaryWriter writer)
            //            {
            //                writer.Write(Username);
            //                writer.Write(Password);
            //            }
            sb.AppendLine("\t\tpublic void Serialize(BinaryWriter writer)");
            sb.AppendLine("\t\t{");

            foreach (var kvp in properties)
            {
                sb.AppendLine($"\t\t\twriter.Write({kvp.Key});");
            }

            sb.AppendLine("\t\t}" + Environment.NewLine);

            //            public void Deserialize(BinaryReader reader)
            //            {
            //                Username = reader.ReadString();
            //                Password = reader.ReadString();
            //            }

            sb.AppendLine("\t\tpublic void Deserialize(BinaryReader reader)");
            sb.AppendLine("\t\t{");

            foreach (var kvp in properties)
            {
                sb.AppendLine($"\t\t\t{kvp.Key} = reader.Read{ToCamel(kvp.Value)}();");
            }

            sb.AppendLine("\t\t}");

            sb.AppendLine(Environment.NewLine + "\t\t}");
            //        }
            sb.Append(Environment.NewLine + "\t}");
            //    }

            Clipboard.SetText(sb.ToString());

            listView1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private string ToPascal(string text)
            => $"{char.ToLower(text[0])}{text.Substring(1)}";

        private string ToCamel(string text)
            => $"{char.ToUpper(text[0])}{text.Substring(1)}";

    }
}
