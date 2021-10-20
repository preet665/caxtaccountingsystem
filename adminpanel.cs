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
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            var c = con;            
                var select = "select loggedinuser,sum(CrAmount) AS 'Credit',sum(DebAmount) AS 'Debit',(sum(CrAmount)-sum(DebAmount)) AS 'Balance' from newentrytable group by loggedinuser";
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
            
            

            
        }
    }
}
