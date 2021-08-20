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

namespace thalbhet
{
    public partial class Newentry : Form
    {
        //SqlDataReader reader; // = cmd.ExecuteReader();
        public Newentry()
        {
            InitializeComponent();
            fill_smk();
            this.ActiveControl = textBox4;
            textBox4.Focus();
            
            button1.BackColor = Color.FromArgb(246, 73, 0);
            button2.BackColor = Color.FromArgb(37, 154, 92);
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
           
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            
          
            SqlCommand cmd = new SqlCommand("SELECT Nimit from Nimit", con);
            //SqlDataReader reader; //= cmd.ExecuteReader();
            con.Open();
            //radDropDownList1.Items.Clear();
            /*while (reader.Read())
            {
                radDropDownList1.Items.Add(new ListViewItem (reader[0].ToString(), reader[0].ToString()));
            }
            //reader.Close();*/
            radDropDownList1.DataSource = cmd.ExecuteReader();
            radDropDownList1.DisplayMember = "Nimit";
            radDropDownList1.ValueMember = "Nimit";
            //radDropDownList1.DataBindings
            con.Close();
            con.Open();
        }
        /*public void Nimit2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("SELECT Nimit from Nimit", con);
            //SqlDataReader reader; //= cmd.ExecuteReader();
            con.Open();
            //radDropDownList1.Items.Clear();
            /*while (reader.Read())
            {
                radDropDownList1.Items.Add(new ListViewItem (reader[0].ToString(), reader[0].ToString()));
            }
            //reader.Close();
            radDropDownList1.DataSource = cmd.ExecuteReader();
            radDropDownList1.DisplayMember = "Nimit";
            radDropDownList1.ValueMember = "Nimit";
            //radDropDownList1.DataBindings
            con.Close();
            con.Open();
        }*/
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
            Nimit();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            bool isParsable = Int32.TryParse(textBox4.Text, out int number);
            if (textBox4.Text != null && isParsable == true)
            {
                int smk = Convert.ToInt32(textBox4.Text);
                MessageBox.Show("Number");

            }
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
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[SMKID] where SMK='" + textBox4.Text + "' ", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
                        radTextBox2.Text = reader1["name"].ToString();
                        textBox2.Text = reader1["PresentCity"].ToString();
                        radTextBox3.Text = reader1["FatherName"].ToString();
                        radTextBox4.Text = reader1["Surname"].ToString();
                        textBox1.Text = reader1["NativeCity"].ToString();
                        textBox3.Text = reader1["MobileNumber"].ToString();

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
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[SMKID] where SMK='" + textBox6.Text + "' ", con);
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        /*radTextBox2.Text = reader1["name"].ToString();
                        textBox2.Text = reader1["Present City"].ToString();
                        radTextBox3.Text = reader1["Father Name"].ToString();
                        radTextBox4.Text = reader1["Surname"].ToString();
                        textBox1.Text = reader1["Native City"].ToString();
                        textBox3.Text = reader1["Mobile Number"].ToString();*/
                        textBox7.Text = reader2["name"].ToString();
                        reader2.Close();
                        con.Close();
                    }



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            
            long SMK = Int64.Parse(textBox4.Text);
            String name = radTextBox2.Text;
            String Fathername = radTextBox3.Text;
            String Surname = radTextBox4.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            String Nimit = radDropDownList1.SelectedItem.ToString();
            long hastaksmk = Int64.Parse(textBox6.Text);
            String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("F");
            string enrtydatetime = dateTimePicker1.Value.ToString();
            String query = "INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[CrAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime]) VALUES ('" + SMK+ "' ,'" +PresentCity+ "','" +NativeCity+ "', '" +Fathername+"','" +Surname+"','"+MobileNumber+"','"+name+"','"+Nimit+"','"+Amount+"','"+hastaksmk+"','"+hastak+"','"+ submissiontime+ "','"+ enrtydatetime+ "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry has been Done successfully");
        }

        private void addnimitbutton_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();

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

        
        private void radDropDownList1_MouseClick(object sender, MouseEventArgs e)
        {
            Nimit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reportoption repoption = new Reportoption();
            repoption.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");

            long SMK = Int64.Parse(textBox4.Text);
            String name = radTextBox2.Text;
            String Fathername = radTextBox3.Text;
            String Surname = radTextBox4.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            String Nimit = radDropDownList1.SelectedItem.ToString();
            long hastaksmk = Int64.Parse(textBox6.Text);
            String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("F");
            string enrtydatetime = dateTimePicker1.Value.ToString();
            String query = "INSERT INTO [dbo].[DebitTable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[Nimit],[DebAmount],[hastaksmk],[hastak],[submissiontime],[enrtydatetime]) VALUES ('" + SMK + "' ,'" + PresentCity + "','" + NativeCity + "', '" + Fathername + "','" + Surname + "','" + MobileNumber + "','" + name + "','" + Nimit + "','" + Amount + "','" + hastaksmk + "','" + hastak + "','" + submissiontime + "','" + enrtydatetime + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry has been Done successfully");
        }
    }
}
