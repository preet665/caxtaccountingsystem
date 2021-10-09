using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace thalbhet
{
    public partial class newsmk : Form
    {
        public newsmk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
            String num = label8.Text;
            String Name = textBox2.Text;
            String Fathername = textBox4.Text;
            String Surname = textBox5.Text;
            String PresentCity = textBox3.Text;
            String NativeCity = textBox1.Text;
            String MobileNumber = textBox6.Text;
            String query = "INSERT INTO [dbo].[Page1$] ([SMKId],[First Name Guj],[Middle Name Guj],[Last Name Guj],[Present City/Village Guj],[Native Guj],[Mobile 1]) VALUES ('" + num + "',N'" + Name + "',N'" + Fathername + "',N'" + Surname + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + MobileNumber + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //var accountSid = "AC51cc33bf09ad302f975388ea751e066c";
            //var authToken = "cc328a2bd06019ace917806bb24fc1fe";
            //TwilioClient.Init(accountSid, authToken);

            //var messageOptions = new CreateMessageOptions(
            //    new Twilio.Types.PhoneNumber("whatsapp:+918488020665"));
            //messageOptions.From = new Twilio.Types.PhoneNumber("whatsapp:+14155238886");
            //messageOptions.Body = "Hello! This is an editable text message. You are free to change it and write whatever you like.";

            //var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body);
            MessageBox.Show("New SMK has generated successfully");

        }

        private void newsmk_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BH74KO7F;Initial Catalog=smkdb;Integrated Security=True");
            //con.Open();
            //SqlDataAdapter da = new SqlDataAdapter("SELECT SMKId FROM [dbo].[Page1$] order by SMKId desc", con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    label8.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
            //}
            //else
            //{
            //    MessageBox.Show("who are you?");

            //}
            string num = GenerateRandomString(5);
            MessageBox.Show(num);
            label8.Text = num;

        }
        public static string GenerateRandomString(int Length)
        {
            string _allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[Length];

            for (int i = 0; i < Length; i++)
            {
                chars[i] = _allowedChars[Convert.ToInt32((_allowedChars.Length - 1) * randNum.NextDouble())];
            }
            return new string(chars);
        }

    }

}
