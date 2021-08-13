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
    public partial class Newentry : Form
    {
        string strquery;
        public Newentry()
        {
            InitializeComponent();
            fill_combo();
        }
        void fill_combo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Preet\satyaadi.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT SMK FROM [dbo].[Kutumb ID]", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                mycollection.Add(reader["SMK"].ToString());
            }
            textBox4.AutoCompleteCustomSource = mycollection;
            reader.Close();
            con.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Newentry_Load(object sender, EventArgs e)
        {
            
        }
    }
}
