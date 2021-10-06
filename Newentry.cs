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
using System.Runtime.InteropServices;

namespace thalbhet
{
    public partial class Newentry : Form
    {
        //SqlDataReader reader; // = cmd.ExecuteReader();
        public Newentry(string UserName)
        {
            InitializeComponent();
            fill_smk();
            this.ActiveControl = textBox4;
            textBox4.Focus();
            
            button1.BackColor = Color.FromArgb(246, 73, 0);
            button2.BackColor = Color.FromArgb(37, 154, 92);
            
            label2.Text = UserName;
            //populatecombobox9();
        }
        void fill_smk()
        {
            /*SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Preet\satyaadi.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT SMK FROM [dbo].[SMKID]", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                textBox4.Text = Convert.ToString(reader.GetInt32(0));
            }*/
        }
        void Nimit()
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            
          
            SqlCommand cmd = new SqlCommand("SELECT Nimit from Nimit", con);
            //SqlDataReader reader; //= cmd.ExecuteReader();
            con.Open();
            //radDropDownList1.Items.Clear();
            /*while (reader.Read())
            {
                radDropDownList1.Items.Add(new ListViewItem (reader[0].ToString(), reader[0].ToString()));
            }
            //reader.Close();*/
            //radDropDownList1.DataSource = cmd.ExecuteReader();
            //radDropDownList1.DisplayMember = "Nimit";
            //radDropDownList1.ValueMember = "Nimit";
            //radDropDownList1.DataBindings
            con.Close();
            con.Open();
        }
        public void Nimit2()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Nimit from Nimit";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Nimit"]);
            }
            con.Close();
        }
        public void populatecombobox9()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nimit");
            table.Rows.Add("Rajipo");
            table.Rows.Add("Utsav");
            table.Rows.Add("Ravi Sabha");
            table.Rows.Add("Marriage");
            table.Rows.Add("Birthday");
            //comboBox9.DataSource = table;
            //comboBox9.DisplayMember = "Nimit";
        }

        private void Newentry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newentrydbDataSet.newentrytable' table. You can move, or remove it, as needed.
            //this.newentrytableTableAdapter.Fill(this.newentrydbDataSet.newentrytable);
            Nimit2();
            if(label2.Text != "admin")
            {
                button6.Visible = false;
            }
            this.Refresh();
            
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            /*bool isParsable = Int32.TryParse(textBox4.Text, out int number);
            if (textBox4.Text != null && isParsable == true)
            {
                int smk = Convert.ToInt32(textBox4.Text);
                MessageBox.Show("Number");

            }*/
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            bool isParsable = Int32.TryParse(textBox4.Text, out int number);
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text != null && isParsable == true)
                {
                    int smk = Convert.ToInt32(textBox4.Text);
                    //MessageBox.Show("Number");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where SMKId='" + textBox4.Text + "' ", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
                        textBox8.Text = reader1["First Name Guj"].ToString();
                        textBox2.Text = reader1["Present City/Village Guj"].ToString();
                        textBox9.Text = reader1["Middle Name Guj"].ToString();
                        textBox10.Text = reader1["Last Name GUj"].ToString();
                        textBox1.Text = reader1["Native Guj"].ToString();
                        textBox3.Text = reader1["Mobile 1"].ToString();

                        reader1.Close();
                        con.Close();
                    }



                }
            }

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            bool isParsable = Int32.TryParse(textBox6.Text, out int number);
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text != null && isParsable == true)
                {
                    int smk = Convert.ToInt32(textBox4.Text);
                    //MessageBox.Show("Number");
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where SMKId='" + textBox6.Text + "' ", con);
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        textBox7.Text = reader2["First Name Guj"].ToString();
                        reader2.Close();
                        con.Close();
                    }



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");

            long SMK = Int64.Parse(textBox4.Text);
            String name = textBox8.Text;
            String Fathername = textBox9.Text;
            String Surname = textBox10.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            String Nimit = comboBox1.SelectedItem.ToString();
            long hastaksmk = Int64.Parse(textBox6.Text);
            String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("F");
            string enrtydatetime = dateTimePicker1.Value.ToString();
            string status = "Credit";
            string loggedinuser = label2.Text;
            String query = " Begin tran credit INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[CrAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "',N'" + Nimit + "','" + Amount + "','" + hastaksmk + "',N'" + hastak + "','" + submissiontime + "','" + enrtydatetime + "','" + status + "','" + loggedinuser + "')commit tran credit";
            String ledgequery = "INSERT INTO [dbo].[ledgertable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[CrAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "',N'" + Nimit + "','" + Amount + "','" + hastaksmk + "',N'" + hastak + "','" + submissiontime + "','" + enrtydatetime + "','" + status + "','" + loggedinuser + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            SqlCommand cmdl = new SqlCommand(@ledgequery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmdl.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry has been Done successfully");
        }

        private void addnimitbutton_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            Nimit2();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBoxBase)
                {
                    c.Text = String.Empty;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reportoption repoption = new Reportoption(label2.Text);
            repoption.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");

            long SMK = Int64.Parse(textBox4.Text);
            String name = textBox8.Text;
            String Fathername = textBox9.Text;
            String Surname = textBox10.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            String Nimit = comboBox1.SelectedItem.ToString();
            long hastaksmk = Int64.Parse(textBox6.Text);
            String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("F");
            string enrtydatetime = dateTimePicker1.Value.ToString();
            string status = "Debit";
            string loggedinuser = label2.Text;
            String query = "INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[DebAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "' ,'" + PresentCity + "','" + NativeCity + "', '" + Fathername + "','" + Surname + "','" + MobileNumber + "','" + name + "','" + Nimit + "','" + Amount + "','" + hastaksmk + "','" + hastak + "','" + submissiontime + "','" + enrtydatetime + "','" + status + "','" + loggedinuser + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            String ledgequery = "INSERT INTO [dbo].[ledgertable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[DebAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "' ,'" + PresentCity + "','" + NativeCity + "', '" + Fathername + "','" + Surname + "','" + MobileNumber + "','" + name + "','" + Nimit + "','" + Amount + "','" + hastaksmk + "','" + hastak + "','" + submissiontime + "','" + enrtydatetime + "','" + status + "','" + loggedinuser + "')";
            SqlCommand cmdl = new SqlCommand(@ledgequery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmdl.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry has been Done successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Newentry_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            newsmk n = new newsmk();
            n.ShowDialog();
        }
    }
}
