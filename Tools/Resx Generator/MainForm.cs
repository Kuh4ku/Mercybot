using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resx_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            File.Delete("_.resx");

            // Write
            var res = new ResXResourceWriter("_.resx");

            var text = File.ReadAllLines("input.txt").Distinct();
            var enumerable = text as IList<string> ?? text.ToList();
            for (var i = 0; i < enumerable.Count(); i++)
                res.AddResource($"{i}", enumerable[i].Trim('"'));
            res.Generate();
            res.Close();


            // Read
            var rr = new ResXResourceReader("_.resx") { UseResXDataNodes = true };

            var dict = rr.GetEnumerator();
            while (dict.MoveNext())
            {
                var node = (ResXDataNode)dict.Value;
                Console.WriteLine(@"{0,-20} {1,-20} {2}",
                    node.Name + @":",
                    node.GetValue((ITypeResolutionService)null),
                    !string.IsNullOrEmpty(node.Comment) ? "// " + node.Comment : "");
            }
            rr.Close();
        }
    }
}
