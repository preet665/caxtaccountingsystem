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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount,DebAmount submissiontime, enrtydatetime, status, loggedinuser FROM newentrytable where ((loggedinuser ='preet') AND (status != 'Credit' AND status != 'Debit')) ", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount,DebAmount submissiontime, enrtydatetime, status, loggedinuser FROM newentrytable where ((loggedinuser ='preet') AND (status != 'Credit' AND status != 'Debit') AND (status = '"+label1.Text+"')) ", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
        }
    }
}
