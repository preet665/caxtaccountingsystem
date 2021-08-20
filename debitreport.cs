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
    public partial class debitreport : Form
    {
        public debitreport()
        {
            InitializeComponent();
        }

        private void debitreport_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, DebAmount, hastaksmk, hastak, submissiontime, enrtydatetime FROM DebitTable", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;

            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            dataGridView1.ReadOnly = true;
            // Adding Checkbox Column
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
            SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM DebitTable");
            debquery.Connection = con;
            object debsum = debquery.ExecuteScalar();
            label5.Text = debsum.ToString();
            //Balance sum in label
            SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable");
            balquery.Connection = con;
            object balsum = balquery.ExecuteScalar();
            label6.Text = balsum.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, DebAmount, hastaksmk, hastak, submissiontime, enrtydatetime FROM DebitTable WHERE SMK LIKE '" + textBox1.Text + "%'", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
    }
}
