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
    public partial class rough : Form
    {
        public rough()
        {
            InitializeComponent();
        }

        private void rough_Load(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("Select SMKId from [dbo].[Page1$] ", con2);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd2;
            con2.Open();
            DataTable dt = new DataTable();
            DA.Fill(dt);
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                SqlCommand selectCMD = new SqlCommand("update [dbo].[Page1$] set image = '"+dt.Rows[i].ItemArray[0].ToString()+
                    ".jpg"+"' where SMKId ='" + dt.Rows[i].ItemArray[0].ToString() + "'", con2);
                selectCMD.ExecuteNonQuery();
            }

        }
    }
}
