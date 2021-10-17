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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
        public test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount,DebAmount submissiontime, enrtydatetime, status, loggedinuser FROM newentrytable where ((loggedinuser ='preet') AND (status != 'Credit' AND status != 'Debit')) ", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            nimitcombo();
            con.Close();
        }
        private void nimitcombo()
        {
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand();
            //con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Nimit from Nimit";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Nimit"]);
            }
            con.Close();
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, Nimit, CrAmount, DebAmount submissiontime, enrtydatetime, status, loggedinuser FROM newentrytable where((loggedinuser = 'admin') AND ((status != 'Credit' AND status != 'Debit') AND status = 'Dhotiya'))", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            con.Close();
        }
    }
}
