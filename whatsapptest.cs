using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using RestSharp;
using RestSharp.Authenticators;

namespace thalbhet
{
    public partial class whatsapptest : Form
    {
        public whatsapptest()
        {
            InitializeComponent();
        }
        String username = "kundal";
        String password = "Kundal212#";
        private void button1_Click(object sender, EventArgs e)
        {
            //using (WebClient web = new WebClient())
            //{
            //    string url = string.Format("https://wa.krupacc.com/send-message")
            //}
            //HttpClient Client = new HttpClient();
            //StringContent Content = new StringContent("");
            //await Client.PostAsync("https://wa.krupacc.com/send-message", Content);
        }
    }
}
