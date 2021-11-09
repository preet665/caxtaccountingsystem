using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace thalbhet
{
    public partial class modify : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
        int rind ;
        public modify(string UserName)
        {
            InitializeComponent();
            label2.Text = UserName;
        }
        private void Modify_Load(object sender, EventArgs e)
        {
            modifyload();
            if (label2.Text != "admin")
            {
                dateTimePicker1.Visible = false;
                button2.Visible = false;
            }
            string fromReportDate = dateTimePicker1.Value.Date.ToString();
            MessageBox.Show(fromReportDate);
        }
        private void modifyload()
        {
            
            //MessageBox.Show(DateTime.Now.ToString("dd-MM-yyyy"));
            if (label2.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                //string toReportDate = dateTimePicker2.Value.ToString("dd-MM-yyyy") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[Nimit],[name],[CrAmount],[DebAmount],[TransAmount],[hastaksmk],[hastak],[status],[note],[submissiontime1] ,[enrtydate],[enrtytime],[giver],[taker],[loggedinuser],[flag],[submissiontime] from newentrytable where submissiontime = '" + fromReportDate + "'", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                string fromReportDate = DateTime.Now.ToString("dd-MM-yyyy");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[Nimit],[name],[CrAmount],[DebAmount],[TransAmount],[hastaksmk],[hastak],[status],[note],[submissiontime1] ,[enrtydate],[enrtytime],[giver],[taker],[loggedinuser],[flag],[submissiontime] from newentrytable where (submissiontime LIKE '" + fromReportDate + "' and loggedinuser = '"+label2.Text+"')", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rind = e.RowIndex;

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            smksearch();
        }
        private void smksearch()
        {
            if (label2.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                //string toReportDate = dateTimePicker2.Value.ToString("dd-MM-yyyy") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[Nimit],[name],[CrAmount],[DebAmount],[TransAmount],[hastaksmk],[hastak],[status],[note],[submissiontime1] ,[enrtydate],[enrtytime],[giver],[taker],[loggedinuser],[flag],[submissiontime] from newentrytable where (submissiontime LIKE '" + fromReportDate + "' and SMK = '"+textBox1.Text+"')", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                string fromReportDate = DateTime.Now.ToString("dd-MM-yyyy");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[Nimit],[name],[CrAmount],[DebAmount],[TransAmount],[hastaksmk],[hastak],[status],[note],[submissiontime1] ,[enrtydate],[enrtytime],[giver],[taker],[loggedinuser],[flag],[submissiontime] from newentrytable where (submissiontime LIKE '" + fromReportDate + "' and loggedinuser = '" + label2.Text + "' and SMK = '" + textBox1.Text + "')", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            modifyload();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (label2.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                //string toReportDate = dateTimePicker2.Value.ToString("dd-MM-yyyy") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID],[SMK],[PresentCity],[NativeCity],[FatherName],[Surname],[MobileNumber],[Nimit],[name],[CrAmount],[DebAmount],[TransAmount],[hastaksmk],[hastak],[status],[note],[submissiontime1] ,[enrtydate],[enrtytime],[giver],[taker],[loggedinuser],[flag],[submissiontime] from newentrytable where submissiontime LIKE '" + fromReportDate + "'", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure , you want to delete ?", "delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                {
                    int rowid = Convert.ToInt32(dataGridView1.Rows[rind].Cells["ID"].Value);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO trash_entries SELECT *, CURRENT_TIMESTAMP as deleted_at FROM newentrytablewhere ID = '" + rowid + "'");
                    SqlCommand c = new SqlCommand("DELETE newentrytable where ID = '" + rowid + "'", con);
                    cmd.ExecuteNonQuery();
                    c.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully deleted");
                    smksearch();
                }
            }
            else
            {
                modifyload();
            }
        }
    }
}
