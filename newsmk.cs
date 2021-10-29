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
        public static string temp_smkno;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        public newsmk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(con);
            string s = @"SELECT COUNT(*) FROM [dbo].[Page1$] WHERE ([First Name Guj] = '"+textBox2.Text+"' and [Middle Name Guj] = '"+textBox4.Text+"')";
            SqlCommand sCommand = new SqlCommand(s, con);
            //sCommand.Parameters.AddWithValue("@SMKId", label8.Text);
            con.Open();
            int records = (int)sCommand.ExecuteScalar();
            con.Close();
            if (records == 0)
            {
                String Name = textBox2.Text;
                String Fathername = textBox4.Text;
                String Surname = textBox5.Text;
                String PresentCity = textBox3.Text;
                String NativeCity = textBox1.Text;
                String MobileNumber = textBox6.Text;
                String query = "INSERT INTO [dbo].[Page1$] ([SMKId],[First Name Guj],[Middle Name Guj],[Last Name Guj],[FullNameGuj],[Present City/Village Guj],[Native Guj],[Mobile 1]) VALUES ('" + temp_smkno + "',N'" + Name + "',N'" + Fathername + "',N'" + Surname + "',N'" + Name + " " + Fathername + " " + Surname + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + MobileNumber + "')";
                SqlCommand cmd = new SqlCommand(@query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New SMK has generated successfully");

            }
            else
            {
                MessageBox.Show("Records Already Exists");
            }
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
            //string num = GenerateRandomString(5);
            //MessageBox.Show(num);
            string numbers = "1234567890";

            string characters = numbers;
            int length = 6;
            string id = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (id.IndexOf(character) != -1);
                id += character;
            }
            label8.Text = "T"+id;
            temp_smkno = "T"+id;
            Clipboard.SetText(temp_smkno);
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
