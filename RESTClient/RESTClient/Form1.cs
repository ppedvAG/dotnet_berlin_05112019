using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = "https://www.googleapis.com/books/v1/volumes?q=net";
            using (var web = new WebClient())
            {
                var json = web.DownloadString(url);
                MessageBox.Show(json);

                var result = JsonSerializer.Deserialize<BooksResults>(json);

                dataGridView1.DataSource = result.items.Select(x => x.volumeInfo).ToList();
            }

        }
    }
}
