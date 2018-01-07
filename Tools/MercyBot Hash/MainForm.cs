using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using File = HashTool.File;

namespace MercyBot_Hash
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static string GetSha512HashFromFile(string fileName)
        {
            var file = new FileStream(fileName, FileMode.Open);
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            var byteHash = sha512.ComputeHash(file);
            file.Close();

            var hashString = new StringBuilder();
            for (var i = 0; i < byteHash.Length; i++)
                hashString.Append(byteHash[i].ToString("x2"));

            return hashString.ToString();
        }

        private static string ToJson<T>(T data)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;

                var files = Directory.GetFiles(fbd.SelectedPath);

                var list = new List<File>();

                foreach (var file in files)
                    list.Add(new File(Path.GetFileName(file), GetSha512HashFromFile(file)));

                richTextBox.AppendText(ToJson(list));
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = @"JSON File|*.json";
                sfd.Title = @"Save a JSON File";
                var result = sfd.ShowDialog();

                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName)) return;

                using (var sw = new StreamWriter(sfd.FileName))
                    sw.WriteLine(richTextBox.Text);
            }
        }
    }
}