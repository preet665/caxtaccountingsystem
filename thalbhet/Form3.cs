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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True;");
            String Nimit = nimittextbox.Text.Trim();
            String query = "INSERT INTO Nimit (Nimit) VALUES ('" + Nimit + "')";
            //"Insert into Nimit_Lookup (Nimit) Values('" & txtNimitGuj.Text.Trim & "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Nimit added successfully");
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
