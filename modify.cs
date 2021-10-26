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
        public modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            modifyload();
        }
        private void modifyload()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from newentrytable", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are you sure , you want to delete ?", "delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                {
                    int rowid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    con.Open();
                    SqlCommand c = new SqlCommand("DELETE newentrytable where ID = '" + rowid + "'", con);
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            smksearch();
        }
        private void smksearch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from newentrytable where SMK = '" + textBox1.Text + "'", con);
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            modifyload();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
