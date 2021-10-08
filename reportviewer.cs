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
    public partial class reportviewer : Form
    {
        public reportviewer(string smk)
        {
            InitializeComponent();
            label1.Text = smk;
        }

        private void reportviewer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("select * from (SELECT TOP 4 * FROM newentrytable where SMK LIKE '1254' ORDER BY submissiontime DESC)AS TEMP where SMK LIKE '"+label1.Text+"'  order by submissiontime ASC; ", con);
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("Select FullNameGuj From [dbo].[Page1$] where SMKId LIKE '" + label1.Text + "'", con2);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            con2.Open();
            DataSet2 DS = new DataSet2();
           
            DA.Fill(DS, "newentrytable");
            DA.SelectCommand = cmd2;
            DA.Fill(DS, "Page1$");
            //dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

            CrystalReport1 crypt = new CrystalReport1();
           crypt.Database.Tables["newentrytable"].SetDataSource(DS);
            crypt.Database.Tables["Page1_"].SetDataSource(DS);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = crypt;

        }
    }
}
