using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newentrydbDataSet1._newentrytable__1390627997_' table. You can move, or remove it, as needed.
            //this.newentrytable__1390627997_TableAdapter.Fill(this.newentrydbDataSet1._newentrytable__1390627997_);
            // TODO: This line of code loads data into the 'dataSet2.newentrytable' table. You can move, or remove it, as needed.
            //this.newentrytableTableAdapter.Fill(this.dataSet2.newentrytable);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from newentrytable", con);
            adapt.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            con.Close();

        }

        private void AdvancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.newentrytableBindingSource.Sort = this.advancedDataGridView1.SortString;
        }

        private void AdvancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.newentrytableBindingSource.Filter = this.advancedDataGridView1.FilterString;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to save Changes", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                

                this.advancedDataGridView1.Refresh();
                MessageBox.Show("Record Updated");
            }
        }
    }
}
