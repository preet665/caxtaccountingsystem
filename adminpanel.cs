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
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        public adminpanel(string UserName)
        {
            InitializeComponent();
            label1.Text = UserName;
            //dataGridView1.Columns[1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {


            adminpaneload();

            
        }
        private void adminpaneload()
        {
            string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            MessageBox.Show(fromReportDate);
            MessageBox.Show(toReportDate);
            var c = con;
            var select = "select loggedinuser, sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') group by loggedinuser";
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];

            int colsum = 0;
            for (int r = 0; r < dataGridView1.Rows.Count; ++r)
            {
                colsum += Convert.ToInt32(dataGridView1.Rows[r].Cells[3].Value);
            }
            label2.Text = colsum.ToString();
            long sum = (long)ds.Tables[0].Compute("Sum(Credit)", "True");
            label2.Text = sum.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            MessageBox.Show(fromReportDate);
            MessageBox.Show(toReportDate);
            string sqlquery = "select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount) - sum(DebAmount)) AS 'Balance' from newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') group by loggedinuser";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            int colsum = 0;
            for (int r = 0; r < dataGridView1.Rows.Count; ++r)
            {
                colsum += Convert.ToInt32(dataGridView1.Rows[r].Cells[3].Value);
            }
            label2.Text = colsum.ToString();
            con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            adminpaneload();
        }
    }
}
