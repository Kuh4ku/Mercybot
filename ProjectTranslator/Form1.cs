using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTranslator
{
    public partial class Form1 : Form
    {

        // Constructor
        public Form1()
        {
            InitializeComponent();
        }


        private void BtnSelectProjectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    TxtProjectFolder.Text = fbd.SelectedPath;
            }
        }

        private void BtnSelectResourcesFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resx file (.resx) | *.resx";

                if (ofd.ShowDialog() == DialogResult.OK)
                    TxtResourcesFilePath.Text = ofd.FileName;
            }
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            if (TxtProjectFolder.TextLength == 0)
                return;

            foreach (var file in Directory.GetFiles(TxtProjectFolder.Text, "*.cs", SearchOption.AllDirectories))
            {
                string allCode = File.ReadAllText(file);

                allCode = Regex.Replace(allCode, "string.Format\\(LanguageManager.Translate\\(\"([^ ]+)\"\\), ([^;]+)\\);", (match) =>
                {
                    AddLog(match.Value);
                    return Correct(match.Groups[1].Value, match.Groups[2].Value);
                });

                File.WriteAllText(file, allCode);
            }
        }

        private string Correct(string key, string @params)
            => $"LanguageManager.Translate(\"{key}\", {@params});";

        //private void BtnTranslate_Click(object sender, EventArgs e)
        //{
        //    if (TxtProjectFolder.TextLength == 0 || TxtResourcesFilePath.TextLength == 0)
        //        return;

        //    int translated = 0;

        //    // Getting all the resources (key, value)
        //    var resources = new Dictionary<string, string>();
        //    var resourcesReader = new ResXResourceReader(TxtResourcesFilePath.Text);
        //    var enumerator = resourcesReader.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        if (resources.ContainsKey(enumerator.Value.ToString()))
        //            continue;

        //        resources.Add(enumerator.Value.ToString(), enumerator.Key.ToString());
        //    }

        //    // Translating only .cs files
        //    foreach (var file in Directory.GetFiles(TxtProjectFolder.Text, "*.cs", SearchOption.AllDirectories))
        //    {
        //        string allCode = File.ReadAllText(file);

        //        allCode = Regex.Replace(allCode, DollarStringPattern, (match) =>
        //        {
        //            string text = match.Groups[1].Value;
        //            AddLog($"$text: {text}");

        //            string formattedText = FormatText(text);
        //            AddLog($"$formattedText: {formattedText}");

        //            // Look for the formattedText in Resources
        //            if (resources.ContainsKey(formattedText))
        //            {
        //                string key = resources[formattedText];
        //                AddLog($"Key: {key}");

        //                // Generate string.Format
        //                translated++;
        //                return GenerateStringFormat(text, key);
        //            }

        //            Console.WriteLine("Translation not found in Resources for: {0}", text);
        //            return match.Value;
        //        });

        //        // Check strings
        //        allCode = Regex.Replace(allCode, NormalStringPattern, (match) =>
        //        {
        //            string text = match.Groups[1].Value;
        //            AddLog($"$text: {text}");

        //            // Look for the formattedText in Resources
        //            if (resources.ContainsKey(text))
        //            {
        //                string key = resources[text];
        //                AddLog($"Key: {key}");

        //                // Generate string.Format
        //                translated++;
        //                return $"LanguageManager.Translate("{key}"");                    }

        //            Console.WriteLine("Translation not found in Resources for: {0}", text);
        //            return match.Value;
        //        });

        //        File.WriteAllText(file, allCode);
        //    }

        //    Console.WriteLine("Translated: {0}", translated);
        //}

        //private string GenerateStringFormat(string text, string key)
        //{
        //    string[] args = Regex.Matches(text, ArgPattern).Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
        //    if (args.Length == 0)
        //        return text;

        //    //return $"string.Format(LanguageManager.Translate("{key}"), {AggregateArgs(args)})";
        //}

        //private static string AggregateArgs(string[] args)
        //    => args.Aggregate((c, n) => $"{c}, {n}");

        //private static string FormatText(string input)
        //{
        //    int i = 0;
        //    return Regex.Replace(input, ArgPattern, match => $"{{{(i++)}}}");
        //}

        private void AddLog(string log)
            => RtbLogs.AppendText($"{log}{Environment.NewLine}");

        //private static string ArgPattern = "\\{([^\\}]+)\\}";
        //private static string DollarStringPattern = "\\$\\\"([^\\\"\\n\\r]+)\\\"";
        //private static string NormalStringPattern = "\\\"([^\\\"\\n\\r]+)\\\"";

    }
}
