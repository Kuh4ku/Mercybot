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

namespace MercyBot_Translator
{
    public partial class MultiEditForm : Form
    {

        // Constructor
        public MultiEditForm()
        {
            InitializeComponent();
        }

        private void selectLangsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvLangs.Rows.Clear();
            dgvLangs.Columns.Clear();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Core.FileDialog fileDialog = app.FileDialog[Microsoft.Office.Core.MsoFileDialogType.msoFileDialogFolderPicker];
            fileDialog.InitialFileName = @"D:\Programmation\MercyBotCore\MercyBot\Others";
            int nres = fileDialog.Show();
            if (nres == -1) //ok
            {
                Microsoft.Office.Core.FileDialogSelectedItems selectedItems = fileDialog.SelectedItems;

                string[] selectedFolders = selectedItems.Cast<string>().ToArray();

                if (selectedFolders.Length > 0)
                {
                    string selectedFolder = selectedFolders[0];
                    dgvLangs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Key" });
                    string[] files = Directory.GetFiles(selectedFolder, "*.lang", SearchOption.AllDirectories);
                    Dictionary<string, Dictionary<string, string>> langs = new Dictionary<string, Dictionary<string, string>>();

                    string[] keys = File.ReadAllLines(files[0]).Select(line => line.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[0]).ToArray();
                    foreach (string key in keys)
                    {
                        langs.Add(key, new Dictionary<string, string>());
                    }
                    Array.ForEach(files, f =>
                    {
                        string lang = Path.GetFileNameWithoutExtension(f);
                        dgvLangs.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = lang});
                        
                        foreach (var kvp in langs)
                        {
                            kvp.Value.Add(lang, "");
                        }
                    });

                    foreach (string file in files)
                    {
                        string lang = Path.GetFileNameWithoutExtension(file);

                        foreach (string line in File.ReadAllLines(file))
                        {
                            if (line == "")
                                continue;

                            string[] infos = line.Split('|');
                            string key = infos[0];
                            string value = infos[1];

                            langs[key][lang] = value;
                        }
                    }

                    foreach (var kvp in langs)
                    {
                        object[] values = new object[files.Length + 1];
                        values[0] = kvp.Key;
                        for (int i = 1; i < values.Length; i++)
                        {
                            values[i] = kvp.Value[Path.GetFileNameWithoutExtension(files[i - 1])];
                        }

                        dgvLangs.Rows.Add(values);
                    }

                }
            }
        }

        private void saveAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Core.FileDialog fileDialog = app.FileDialog[Microsoft.Office.Core.MsoFileDialogType.msoFileDialogFolderPicker];
            fileDialog.InitialFileName = @"D:\Programmation\MercyBotCore\MercyBot\Others";
            int nres = fileDialog.Show();
            if (nres == -1) //ok
            {
                Microsoft.Office.Core.FileDialogSelectedItems selectedItems = fileDialog.SelectedItems;

                string[] selectedFolders = selectedItems.Cast<string>().ToArray();

                if (selectedFolders.Length > 0)
                {
                    string selectedFolder = selectedFolders[0];

                    Dictionary<string, List<string>> lines = new Dictionary<string, List<string>>();
                    foreach (DataGridViewTextBoxColumn column in dgvLangs.Columns)
                    {
                        if (column.HeaderText == "Key")
                            continue;

                        lines.Add(column.HeaderText, new List<string>());
                    }

                    foreach (DataGridViewRow row in dgvLangs.Rows)
                    {
                        foreach (var kvp in lines)
                        {
                            string line = $"{row.Cells[0].Value}|{row.Cells.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == kvp.Key).Value}";
                            if (line == "|")
                                continue;

                            kvp.Value.Add(line);
                        }
                    }

                    foreach (var kvp in lines)
                    {
                        File.WriteAllLines(Path.Combine(selectedFolder, $"{kvp.Key}.lang"), kvp.Value);
                    }

                }
            }
        }

    }
}
