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
            var client = new RestClient("http://wa.krupacc.com/send-cloud-media");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("number", "+918320640724");
            request.AddParameter("caption", "jay swaminarayan");
            request.AddParameter("file", "https://www.upiqrcode.com/upiqrtestapi?apikey=ntljdu&seckey=kundal&paymode=bankac&vpa=SMKV1017905@YESB0CMSNOC&payee=SHRI SWAMINARAYAN MANDIR KARELIBAUG VADODARA");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
