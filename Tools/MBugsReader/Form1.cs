using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBugsReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadMbug_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "MBug File (.mbug) | *.mbug";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (BinaryReader br = new BinaryReader(File.Open(ofd.FileName, FileMode.Open)))
                    {
                        LblLevel.Text = "Level: " + br.ReadByte();
                        LblWeight.Text = "Weight: " + br.ReadInt32() + "%";
                        LblMapId.Text = "MapId: " + br.ReadInt32();
                        LblMapPos.Text = "Position: " + br.ReadString();

                        int c = br.ReadInt32();
                        LbLogs.Items.Clear();
                        for (int i = 0; i < c; i++)
                        {
                            LbLogs.Items.Add(br.ReadString());
                        }

                        c = br.ReadInt32();
                        DgvMessages.Rows.Clear();
                        for (int i = 0; i < c; i++)
                        {
                            var time = DateTime.FromBinary(br.ReadInt64());
                            bool sent = br.ReadBoolean();
                            string message = br.ReadString();

                            DgvMessages.Rows.Add(time.ToLongTimeString(), message);
                            if (sent) DgvMessages.Rows[DgvMessages.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Beige;
                        }
                    }
                }
            }
        }
    }
}
