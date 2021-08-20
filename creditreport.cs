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
    public partial class creditreport : Form
    {
        public creditreport()
        {
            InitializeComponent();
            label1.BackColor = Color.FromArgb(246, 73, 0);
            label2.BackColor = Color.FromArgb(37, 154, 92);
        }

        private void creditreport_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime FROM newentrytable", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            dataGridView1.ReadOnly = true;
            DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkcol);
            chkcol.HeaderText = "Select Entry";
            chkcol.Name = "chk";
            dataGridView1.Columns["chk"].DisplayIndex = 0;
            //Credit sum in label
            SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable");
            crquery.Connection = con;
            object crsum = crquery.ExecuteScalar();
            label4.Text = crsum.ToString();
            //Debit sum in label
            SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM DebitTable ");
            debquery.Connection = con;
            object debsum = debquery.ExecuteScalar();
            label5.Text = debsum.ToString();
            //Balance sum in label
            //SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable JOIN DebitTable");
            SqlCommand balquery =  new SqlCommand("SELECT newentrytable.CrAmount,DebitTable.DebAmount " +
                "FROM " +
                "(select SUM(CrAmount) CrAmount FROM newentry) newentrytable " +
                "CROSS JOIN " +
                "(select SUM(DebAmount) DebAmount FROM DebitTable) DebitTable");
            balquery.Connection = con;
            object balsum = balquery.ExecuteScalar();
            label6.Text = balsum.ToString();
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime FROM newentrytable WHERE SMK LIKE '" + textBox2.Text + "%'",con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
    }
}
