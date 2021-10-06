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
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            if (textBox1.Text == "admin" || textBox2.Text == "admin")
            {
                SqlCommand cmd = new SqlCommand("select * from LoginTable where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Registration registration = new Registration();
                    registration.ShowDialog();
                    
                }

            }
            else
            {
                MessageBox.Show("Please recheck your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
