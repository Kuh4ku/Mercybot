using MercyBot.Protocol.Data.Maps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapViewer
{
    public partial class Form1 : Form
    {

        private HttpClient httpClient;


        public Form1()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://ankama.akamaized.net/games/dofus-tablette/assets/2.15.15/maps/");

            comboBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await httpClient.GetAsync($"{textBox1.Text}.json");

            //try
            //{
            string json = await response.Content.ReadAsStringAsync();
            Map map = JsonConvert.DeserializeObject<Map>(json);
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid map");
            //    return;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapViewer1.Zoom = float.Parse(comboBox1.SelectedItem.ToString());
        }

    }

}
