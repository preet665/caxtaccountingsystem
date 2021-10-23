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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RestSharp;
using System.Configuration;

namespace thalbhet
{
    public partial class Newentry : Form
    {
        //SqlDataReader reader; // = cmd.ExecuteReader();
        
        public static string bal;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        public Newentry(string UserName)
        {
            InitializeComponent();
            this.ActiveControl = textBox4;
            textBox4.Focus();
            
            button1.BackColor = Color.FromArgb(246, 73, 0);
            button2.BackColor = Color.FromArgb(37, 154, 92);
            
            label2.Text = UserName;
            if(label2.Text != "admin")
            {
                addnimitbutton.Visible = false;
                button7.Visible = false;
            }
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;//1 seconds
            timer1.Tick += new System.EventHandler(Timer3_Tick);
            timer1.Start();

            //populatecombobox9();
        }
        public void Nimit2()
        {
           
            SqlCommand cmd;
            SqlDataReader dr;
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
            newentryload();

        }
        private void newentryload()
        {
            Nimit2();
            if (label2.Text != "admin")
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

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            bool isParsable = Int32.TryParse(textBox6.Text, out int number);
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text != null && isParsable == true)
                {
                    int smk = Convert.ToInt32(textBox4.Text);
                    //MessageBox.Show("Number");
                    con2.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where SMKId='" + textBox6.Text + "' ", con2);
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        textBox7.Text = reader2["First Name Guj"].ToString();
                        reader2.Close();
                       
                    }
                    con2.Close();


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True;");
            String SMK = textBox4.Text;
                String name = textBox8.Text;
                String Fathername = textBox9.Text;
                String Surname = textBox10.Text;
                String PresentCity = textBox2.Text;
                String NativeCity = textBox1.Text;
                long MobileNumber = Int64.Parse(textBox3.Text);
                long Amount = Int64.Parse(textBox5.Text);
                //String Nimit = comboBox1.SelectedItem.ToString();
                //long hastaksmk = Int64.Parse(textBox6.Text);
                //String hastak = textBox7.Text;
                string submissiontime = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss");
                string entrytime = DateTime.Now.ToString("HH:mm:ss");
                string enrtydatetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string status = "Credit";
                string loggedinuser = label2.Text;
                String query = "Begin tran credit INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[CrAmount],[submissiontime],[enrtydate],[enrtytime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','"+ enrtydatetime+" "+entrytime+"',CONVERT(TIME, GETDATE()),'" + status + "','" + loggedinuser + "')commit tran credit";
                //String query = "INSERT INTO newentrytable ([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[CrAmount]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "')";
                String ledgequery = "INSERT INTO [dbo].[history]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[CrAmount],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','" + dateTimePicker1.Value.ToString("dd / MMM / yyyy HH: mm:ss:ffff") + "','" + status + "','" + loggedinuser + "')";
                SqlCommand cmd = new SqlCommand(@query, con);
                SqlCommand cmdl = new SqlCommand(@ledgequery, con);
                con.Open();

                cmd.ExecuteNonQuery();
                cmdl.ExecuteNonQuery();
                
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable  where SMK='" + textBox4.Text + "' ", con);
                //balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label15.Text = balsum.ToString();
                bal = balsum.ToString();
                con.Close();
                MessageBox.Show("Entry has been Done successfully");
                reportviewer repv = new reportviewer(SMK, label15.Text, MobileNumber);
                CrystalReport1 cr = new CrystalReport1();
                //TextObject balance = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Text6"];
                //balance.Text = "hello";

                repv.crystalReportViewer1.ReportSource = cr;
                repv.Show();
                
                newentryload();
           
            

        }

        private void addnimitbutton_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            Nimit2();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox4.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox8.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox5.Text = null;
        
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

            String SMK = textBox4.Text;
            String name = textBox8.Text;
            String Fathername = textBox9.Text;
            String Surname = textBox10.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            //String Nimit = comboBox1.SelectedItem.ToString();
            //long hastaksmk = Int64.Parse(textBox6.Text);
            //String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss");
            string entrytime = DateTime.Now.ToString("HH:mm:ss");
            string enrtydatetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string status = "Debit";
            string loggedinuser = label2.Text;
            String query = "INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[DebAmount],[submissiontime],[enrtydate],[enrtytime],[status],[loggedinuser]) VALUES ('" + SMK + "' ,N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','" + enrtydatetime + " " + entrytime + "',CONVERT(TIME, GETDATE()),'" + status + "','" + loggedinuser + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            String ledgequery = "INSERT INTO [dbo].[history]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[DebAmount],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "' ,N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "',N'" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','" + enrtydatetime + "','" + status + "','" + loggedinuser + "')";
            SqlCommand cmdl = new SqlCommand(@ledgequery, con);
            con.Open();
            if (Int64.Parse(textBox5.Text) > Int64.Parse(label15.Text))
            {
                MessageBox.Show("Amount is greaer than balance");
            }
            else
            {
                cmd.ExecuteNonQuery();
                cmdl.ExecuteNonQuery();
            }
            SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable  where SMK='" + textBox4.Text + "' ", con);
            //balquery.Connection = con;
            object balsum = balquery.ExecuteScalar();
            label15.Text = balsum.ToString();
            bal = balsum.ToString();
           
            MessageBox.Show("Entry has been Done successfully");
            reportviewer repv = new reportviewer(SMK,label15.Text,MobileNumber);
            repv.ShowDialog();
            con.Close();
            newentryload();

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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            bool isParsable = Int32.TryParse(textBox3.Text, out int number);
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text != null && isParsable == true)
                {
                    int smk = Convert.ToInt32(textBox3.Text);
                    //MessageBox.Show("Number");

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where [Mobile 1] ='" + textBox3.Text + "' ", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
                        textBox8.Text = reader1["First Name Guj"].ToString();
                        textBox2.Text = reader1["Present City/Village Guj"].ToString();
                        textBox9.Text = reader1["Middle Name Guj"].ToString();
                        textBox10.Text = reader1["Last Name GUj"].ToString();
                        textBox1.Text = reader1["Native Guj"].ToString();
                        textBox4.Text = reader1["SMK"].ToString();

                        reader1.Close();
                        con.Close();
                    }



                }
                con.Open();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where [MobileNumber] ='" + textBox3.Text + "'", con);
                //balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label15.Text = balsum.ToString();
                con.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            String SMK = textBox4.Text;
            String name = textBox8.Text;
            String Fathername = textBox9.Text;
            String Surname = textBox10.Text;
            String PresentCity = textBox2.Text;
            String NativeCity = textBox1.Text;
            long MobileNumber = Int64.Parse(textBox3.Text);
            long Amount = Int64.Parse(textBox5.Text);
            String Nimit = comboBox1.SelectedItem.ToString();
            //long hastaksmk = Int64.Parse(textBox6.Text);
            //String hastak = textBox7.Text;
            string submissiontime = DateTime.Now.ToString("dd/MMMM/yyyy ");
            string entrytime = DateTime.Now.ToString("HH:mm:ss");
            string enrtydatetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string status = "Credit";
            string loggedinuser = label2.Text;
            String query = "INSERT INTO [dbo].[newentrytable]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[DebAmount],[submissiontime],[enrtydate],[enrtytime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','" + enrtydatetime + " " + entrytime + "',CONVERT(TIME, GETDATE()),'" + Nimit + "','" + loggedinuser + "')";
            String ledgequery = "INSERT INTO [dbo].[history]([SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[name],[DebAmount],[submissiontime],[enrtydatetime],[status],[loggedinuser]) VALUES ('" + SMK + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + Fathername + "',N'" + Surname + "','" + MobileNumber + "',N'" + name + "','" + Amount + "','" + submissiontime + "','" + enrtydatetime + "','" + Nimit + "','" + loggedinuser + "')";
            SqlCommand cmd = new SqlCommand(@query, con);
            SqlCommand cmdl = new SqlCommand(@ledgequery, con);
            con.Open();
            if (Int64.Parse(textBox5.Text) > Int64.Parse(label15.Text))
            {
                MessageBox.Show("Amount is greaer than balance");
            }
            else
            {
                cmd.ExecuteNonQuery();
                cmdl.ExecuteNonQuery();
            }

            getbal();
            MessageBox.Show("Entry has been Done successfully");
            reportviewer repv = new reportviewer(SMK, label15.Text, MobileNumber);
            repv.ShowDialog();
            con.Close();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                bool isParsable = Int32.TryParse(textBox3.Text, out int number);
                if (textBox3.Text != null)
                {
                    
                    //double smk = Convert.ToInt64(textBox3.Text);
                    //MessageBox.Show("Number");

                    
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where [Mobile 1] ='" + textBox3.Text + "' ", con2);
                    con2.Open();
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.Read())
                    {
                        textBox8.Text = reader1["First Name Guj"].ToString();
                        textBox2.Text = reader1["Present City/Village Guj"].ToString();
                        textBox9.Text = reader1["Middle Name Guj"].ToString();
                        textBox10.Text = reader1["Last Name GUj"].ToString();
                        textBox1.Text = reader1["Native Guj"].ToString();
                        textBox4.Text = reader1["SMKId"].ToString();

                        reader1.Close();
                        con2.Close();
                    }



                }
                con.Open();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where [MobileNumber] ='" + textBox3.Text + "'", con);
                //balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label15.Text = balsum.ToString();
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string SMK = textBox4.Text;
            string mnum = textBox3.Text.Trim();
            long MobileNumber = Int64.Parse(mnum);
            //reportviewer repv = new reportviewer(SMK.ToString());
            //repv.ShowDialog();
            reportviewer repv = new reportviewer(SMK,label15.Text,MobileNumber);
            CrystalReport1 cr = new CrystalReport1();
            //TextObject balance = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["Text6"];
            //balance.Text = "hello";

            repv.crystalReportViewer1.ReportSource = cr;
            repv.crystalReportViewer1.Refresh();
            repv.Show();
            //PrintDialog printDialog = new PrintDialog();
            //string path = @"E:\bank management system\thalbhet\CrystalReport1.rpt";
            //CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //reportDocument.Load(path);
            //reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
            //reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            //try
            //{
            //    ExportOptions CrExportOptions;
            //    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            //    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            //    CrDiskFileDestinationOptions.DiskFileName = "E:\\bmsreceipt.pdf";
            //    CrExportOptions = cr.ExportOptions;
            //    {
            //        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            //        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            //        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            //        CrExportOptions.FormatOptions = CrFormatTypeOptions;
            //    }
            //    cr.Export();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void Newentry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic result = MessageBox.Show("Do You Want To Exit?", "Bank Management System", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            //bool isParsable = Int32.TryParse(textBox4.Text, out int number);
            textBox5.Text = null;
            SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            if (textBox4.Text != null)
                {
                    //int smk = Convert.ToInt32(textBox4.Text);
                    //MessageBox.Show("Number");

                    con2.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Page1$] where SMKId='" + textBox4.Text + "' ", con2);
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
                    }
                    con2.Close();
                


            }
                     getbal();
        }

        private void TextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                button2.Focus();

                button2_Click(sender, e);
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                button1.PerformClick();
            }
        }
        private void getbal()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            else
            {
                con.Close();
                con.Open();
            }
            SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable  where SMK='" + textBox4.Text + "' ", con);
            object balsum = balquery.ExecuteScalar();
            label15.Text = balsum.ToString();
            bal = balsum.ToString();
            con.Close();
        }
        private void Timer3_Tick(object sender, EventArgs e)
        {

            getbal();


        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
