using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;



namespace thalbhet
{
    public partial class creditreporttrial : Form
    {
        public creditreporttrial(string Username)
        {
            InitializeComponent();
            label2.BackColor = Color.FromArgb(246, 73, 0);
            label5.BackColor = Color.FromArgb(246, 73, 0);
            label1.BackColor = Color.FromArgb(37, 154, 92);
            label4.BackColor = Color.FromArgb(37, 154, 92);
            label11.Text = Username; 


        }

       

        private void creditreport_Load(object sender, EventArgs e)
        {
            reportload();
            
            

        }
        public void reportload()
        {
            // TODO: This line of code loads data into the 'newentrydbDataSet.newentrytable' table. You can move, or remove it, as needed.
            //this.newentrytableTableAdapter1.Fill(this.newentrydbDataSet.newentrytable);
            // TODO: This line of code loads data into the 'newentrydbDataSet2.newentrytable' table. You can move, or remove it, as needed.
            //this.newentrytableTableAdapter.Fill(this.newentrydbDataSet2.newentrytable);
            
            if (label11.Text == "admin")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                //Debit sum in label
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable ");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                //Transfer sum in label
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();

            }
            else
            {
                /*DataView dv = DS.Tables[0].DefaultView;
                dv.RowFilter = string.Format("loggedinuser LIKE '%{0}%' OR giver LIKE '%{0}%' OR taker LIKE '%{0}%'", label11.Text);
                dataGridView1.DataSource = dv;*/


                /*label4.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[9].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[9].FormattedValue)).Sum().ToString();*/
                string transstring = "Transfer";
                string crestring = "Credit";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + transstring + "' OR status ='" + crestring + "')", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where (loggedinuser ='"+label11.Text+ "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }

            //DataView dv = DS.Tables[0].DefaultView;
            //dv.RowFilter = string.Format("status LIKE '%{0}%'", label11.Text);
            //dataGridView1.DataSource = dv;
            //dataGridView1.ReadOnly = true;
            //dataGridView1.AutoResizeColumns();

            /*DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chkcol);
            chkcol.HeaderText = "Select Entry";
            chkcol.Name = "chkcol";
            dataGridView1.Columns["chkcol"].DisplayIndex = 0;*/
            //Credit sum in label

            this.Refresh();
            usercombo();
        }
        public void usercombo()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT username from LoginTable";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["username"]);
            }
            con.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        /*  private void Displayindatagrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime FROM newentrytable", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }
        void Displaydata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlDataAdapter adap = new SqlDataAdapter("Select * from newentrytable", con);
            DataTable dt = new DataTable();
            con.Open();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
             //Displaydata();
            var deck = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                deck.Add(row.Index);
                var id = row.Cells[0].Value;
                string note = textBox1.Text;
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;
                }

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True;");
                con.Open();
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Debit', DebAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                //SqlCommand selectCMD1 = new SqlCommand("update newentrytable set DebAmount = CrAmount where ID ='" + id + "'", con);
                //SqlCommand selectCMD2 = new SqlCommand("update newentrytable set note = '" + note + "' where ID ='" + id + "'", con);

                selectCMD.ExecuteNonQuery();
                //selectCMD1.ExecuteNonQuery();
                //selectCMD2.ExecuteNonQuery();
                con.Close();


                /*for(int i =0; i < deck.Count; i++ )
                {
                    int id = deck[i] + 1;
                    string note = textBox1.Text;
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True;") ;
                    con.Open();
                    SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Debit' where ID ='" +id + "'", con);
                    SqlCommand selectCMD1 = new SqlCommand("update newentrytable set DebAmount = CrAmount where ID ='" + id + "'", con);
                    SqlCommand selectCMD2 = new SqlCommand("update newentrytable set note = '" +note+ "' where ID ='" + id + "'", con);
                    
                    selectCMD.ExecuteNonQuery();
                    selectCMD1.ExecuteNonQuery();
                    selectCMD2.ExecuteNonQuery();
                    con.Close();
                }*/

                //return deck.ToArray();
            }
            reportload();
            //advancedDataGridView1.Refresh();
            Displaydata();
        }
        SqlDataAdapter adap;
        SqlCommandBuilder cmdl;
        DataSet DS = new System.Data.DataSet();
       
        /*private void button1_Click(object sender, EventArgs e)
        {
           

            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                r.Cells["status"].Value = "Debit"; //use the column name instead of column index
                cmdl = new SqlCommandBuilder(adap);
                adap.Update(DS, "datagridview1");
            }
            this.BindingContext[dataGridView1.DataSource].EndCurrentEdit();


        }*/


        private void button2_Click(object sender, EventArgs e)
        {
            var deck = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                deck.Add(row.Index);
                var id = row.Cells[0].Value;
                string note = textBox1.Text;
                //string From = label11.Text;
                string To = comboBox1.SelectedItem.ToString();
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;
                }
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True;");
                con.Open();
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Transfer' , giver = '"+label11.Text+"', taker = '"+To+"' , TransAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                selectCMD.ExecuteNonQuery();
                con.Close();
                reportload();
            }
            Displaydata();
        }

        private void dateTimePicker3_CloseUp(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            string sqlquery = "SELECT * from newentrytable where submissiontime between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //exporttopdf2(dataGridView1, "test");
            //export ex = new export();
            //ex.ShowDialog();
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            pdfTable.DefaultCell.BorderWidth = 2;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(30, 144, 255);
                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {

                    }
                    else
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }

            string folderpath = "C:\\PDF\\";
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            using (FileStream stream = new FileStream(folderpath + "CreditReport.pdf", FileMode.Create))
            {
                Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(document, stream);
                document.Open();
                document.Add(pdfTable);
                document.Close();
                stream.Close();
                MessageBox.Show("Pdf is exported ");
            }
        }
        public void exporttoexcel2()
        {
            Microsoft.Office.Interop.Excel.Application excl = new Microsoft.Office.Interop.Excel.Application();
            excl.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                excl.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    excl.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            excl.Columns.AutoFit();
            excl.Visible = true;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            exporttoexcel2();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string searchValue = textBox2.Text;
            int rowIndex = -1;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridView1.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (label11.Text == "admin")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where SMK like '"+textBox2.Text+"' ", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                //Debit sum in label
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable ");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                //Transfer sum in label
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();

            }
            else
            {
                /*DataView dv = DS.Tables[0].DefaultView;
                dv.RowFilter = string.Format("loggedinuser LIKE '%{0}%' OR giver LIKE '%{0}%' OR taker LIKE '%{0}%'", label11.Text);
                dataGridView1.DataSource = dv;*/


                /*label4.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[9].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[9].FormattedValue)).Sum().ToString();*/
                string transstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + transstring + "') AND SMK like '" + textBox2.Text + "'", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
            }
        }
    }
}
