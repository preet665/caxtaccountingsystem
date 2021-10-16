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
    public partial class adminpanel : Form
    {
        public adminpanel(string UserName)
        {
            InitializeComponent();
            label1.Text = UserName;
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True";);
            //SqlCommand selectCMD = new SqlCommand("select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable where loggedinuser = '"+label1.Text+"' group by loggedinuser", con);
            //SqlDataAdapter DA = new SqlDataAdapter();
            //DA.SelectCommand = selectCMD;
            //con.Open();
            //DataSet DS = new DataSet();
            //DA.Fill(DS, "newentrytable");

            //var select = "select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable where loggedinuser = '" + label1.Text + "' group by loggedinuser";
            var c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True"); // Your Connection String here
            if (label1.Text != "admin")
            {
                var select = "select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable where loggedinuser = '" + label1.Text + "' group by loggedinuser";
                var dataAdapter = new SqlDataAdapter(select, c);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                var select = "select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable group by loggedinuser";
                var dataAdapter = new SqlDataAdapter(select, c);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            //var dataAdapter = new SqlDataAdapter(select, c);

            
        }
    }
}
