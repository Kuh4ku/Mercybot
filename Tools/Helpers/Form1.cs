using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            MessageBox.Show(FecthMACAddressInternal());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\((?<name>[^ ]+) message\)";

            StringBuilder sb = new StringBuilder();
            foreach (Match match in Regex.Matches(richTextBox1.Text, pattern))
            {
                string name = match.Groups["name"].Value;
                sb.AppendLine($"RmIds.Add(Account.Network.RegisterMessage<{name}>(Handle{name}));");
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show("COPIED !");
        }

        public static string FecthMACAddressInternal()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        if (moc != null)
                        {
                            foreach (ManagementObject mo in moc)
                            {
                                if (mo["MacAddress"] != null && mo["IPEnabled"] != null && (bool)mo["IPEnabled"] == true)
                                {
                                    return (mo["MacAddress"].ToString()).Replace(":", "");
                                }

                                mo.Dispose();
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

    }
}
