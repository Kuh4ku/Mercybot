using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace MercyBot_Translator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            var openFileDialog = new OpenFileDialog
            {
                //InitialDirectory = "c:\\",
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = @"resx files (*.resx)|*.resx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = true
            };


            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    var rr = new ResXResourceReader(fileName) { UseResXDataNodes = true };

                    var enumerator = rr.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var node = (ResXDataNode)enumerator.Value;
                        dict.Add(node.Name, node.GetValue((ITypeResolutionService)null).ToString());
                        //dataGridView.Rows.Add(node.Name, node.GetValue((ITypeResolutionService)null));
                    }

                    for (int i = 1; i <= 556; i++)
                    {
                        if (!dict.ContainsKey(i.ToString()))
                            dict.Add(i.ToString(), "");
                    }

                    File.WriteAllLines(Path.GetFileNameWithoutExtension(fileName) + ".lang", dict.Select(kvp => $"{kvp.Key}|{kvp.Value}"));
                    rr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = @"resx files (*.resx)|*.resx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var path = sfd.FileName;

                File.Delete(path);

                var res = new ResXResourceWriter(path);
                int i = 1;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    res.AddResource(i.ToString(), row.Cells["value"].Value);
                    i++;
                }

                res.Generate();
                res.Close();

                MessageBox.Show(@"Vos traductions ont bien étés sauvegardés! Merci!");
            }
        }

    }
}