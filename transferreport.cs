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
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace thalbhet
{
    public partial class transferreport : Form
    {
        public transferreport(string username)
        {
            InitializeComponent();
            label2.BackColor = Color.FromArgb(246, 73, 0);
            label5.BackColor = Color.FromArgb(246, 73, 0);
            label1.BackColor = Color.FromArgb(37, 154, 92);
            label4.BackColor = Color.FromArgb(37, 154, 92);
            label12.Text = username;
        }

        private void transferreport_Load(object sender, EventArgs e)
        {
            if (label12.Text == "admin")
            {
<<<<<<< Updated upstream
                string debstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where status LIKE '" + debstring + "' ", con);
=======
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((status = 'Transfer') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable ");
=======
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((status = 'Transfer') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
>>>>>>> Stashed changes
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
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
<<<<<<< Updated upstream
                string debstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + debstring + "')", con);
=======
                //string debstring = "Transfer";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((taker ='" + label12.Text + "') AND (status = 'Transfer') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ", con);
>>>>>>> Stashed changes
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
<<<<<<< Updated upstream

                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
=======
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where (loggedinuser ='" + label12.Text + "') or taker = '" + label12.Text + "'");
>>>>>>> Stashed changes
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
<<<<<<< Updated upstream
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
=======
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((taker ='" + label12.Text + "') AND (status = 'Transfer')) ");
>>>>>>> Stashed changes
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
<<<<<<< Updated upstream
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable where (loggedinuser = '" + label11.Text + "' OR giver = '" + label11.Text + "')");
=======
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)   ) FROM newentrytable where (loggedinuser = '" + label12.Text + "')");
>>>>>>> Stashed changes
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            string searchValue = textBox1.Text;
=======
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((SMK = '"+textBox1.Text+ "') AND (status = 'Transfer' and status != 'Credit' and status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                dataGridView1.AllowUserToAddRows = false;
                con.Close();
>>>>>>> Stashed changes

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
<<<<<<< Updated upstream
                //MessageBox.Show(exc.Message);
=======
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((SMK = '" + textBox1.Text + "') AND (loggedinuser ='" + label12.Text + "') AND (status = 'Transfer' and status != 'Credit' and status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                con.Close();


>>>>>>> Stashed changes
            }
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            string sqlquery = "SELECT * from newentrytable where submissiontime between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
=======
            string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount,CrAmount,DebAmount,TransAmount,submissiontime, enrtydate, loggedinuser FROM newentrytable where((loggedinuser = 'admin') AND(status = 'Transfer' and status != 'Credit' and status != 'Debit') AND enrtydate between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "') ";
>>>>>>> Stashed changes
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void exporttoexcel()
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
       

        private void button1_Click(object sender, EventArgs e)
        {
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
            using (FileStream stream = new FileStream(folderpath + "TransferReport.pdf", FileMode.Create))
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

        private void button2_Click(object sender, EventArgs e)
        {
            exporttoexcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label12.Text == "admin")
            {
<<<<<<< Updated upstream
                string debstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (status LIKE '" + debstring + "' AND SMK like '" + textBox1.Text + "') ", con);
=======
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                MessageBox.Show(toReportDate);
                //SqlCommand selectCMD = new SqlCommand(", con);
                string sqlquery = "SELECT * FROM newentrytable where((status = 'Transfer' and status != 'Credit' and status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                //DataTable dt = new DataTable();
                //dt.Load(cmd.ExecuteReader());
                //dataGridView1.DataSource = dt;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable ");
=======
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where ((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
>>>>>>> Stashed changes
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
<<<<<<< Updated upstream
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable");
=======
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)   ) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
>>>>>>> Stashed changes
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();

            }
            else
            {
<<<<<<< Updated upstream
                /*DataView dv = DS.Tables[0].DefaultView;
                dv.RowFilter = string.Format("loggedinuser LIKE '%{0}%' OR giver LIKE '%{0}%' OR taker LIKE '%{0}%'", label11.Text);
                dataGridView1.DataSource = dv;*/


                /*label4.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[9].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[9].FormattedValue)).Sum().ToString();*/
                string debstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label12.Text + "' OR taker ='" + label12.Text + "' ) AND (status IS NULL OR status ='" + debstring + "') AND SMK like '" + textBox1.Text + "' ", con);
=======
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                MessageBox.Show(toReportDate);
                //SqlCommand selectCMD = new SqlCommand(", con);
                string sqlquery = "SELECT * FROM newentrytable where((status = 'Transfer') AND (taker = '"+label12.Text+"') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') AND (loggedinuser ='" + label12.Text + "'))";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                //DataTable dt = new DataTable();
                //dt.Load(cmd.ExecuteReader());
                //dataGridView1.DataSource = dt;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
=======
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where ((taker ='" + label12.Text + "') AND (status = 'Transfer') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)   ) FROM newentrytable where ((loggedinuser = '" + label12.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }
            
        }
>>>>>>> Stashed changes


<<<<<<< Updated upstream
=======
            
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where (((status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand sumquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where (((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                sumquery.Connection = con;
                object sum = sumquery.ExecuteScalar();
                label15.Text = sum.ToString();
                con.Close();
                
            }
            else
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND ((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand sumquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (((loggedinuser ='" + label12.Text + "') AND ((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                sumquery.Connection = con;
                object sum = sumquery.ExecuteScalar();
                label15.Text = sum.ToString();
                con.Close();
>>>>>>> Stashed changes
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var deck = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                deck.Add(row.Index);
                var id = row.Cells[0].Value;
                var amount = row.Cells["CrAmount"].Value;
                var debamount = row.Cells["DebAmount"].Value;
                var cramount = row.Cells["CrAmount"].Value;
                var transamount = row.Cells["TransAmount"].Value;
                var smk = row.Cells["SMK"].Value;
                var PresentCity = row.Cells["PresentCIty"].Value;
                var NativeCity = row.Cells["NativeCity"].Value;
                var FatherName = row.Cells["FatherName"].Value;
                var Surname = row.Cells["Surname"].Value;
                var MobileNumber = row.Cells["MobileNumber"].Value;
                var Nimit = row.Cells["Nimit"].Value;
                var name = row.Cells["name"].Value;
                string loggedinuser = row.Cells["loggedinuser"].Value.ToString();
                MessageBox.Show(amount.ToString());

                //string To = comboBox1.SelectedItem.ToString();
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;

                }
                con.Open();
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Credit' , taker = '" + label12.Text + "' , CrAmount=TransAmount , TransAmount= 0  where ID ='" + id + "'", con);
                //SqlCommand selectCMD1 = new SqlCommand("insert into newentrytable (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,giver,taker,CrAmount,TransAmount,note,flag) values ('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Credit','" + label11.Text + "','" + label11.Text + "' ,'" + amount + "',0,,1)", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,taker,TransAmount,CrAmount,DebAmount) values " +
                    "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "', 'Transfer','" + label11.Text + "' ,'" + cramount + "','" + transamount + "','" + debamount + "')", con);

                selectCMD.ExecuteNonQuery();
                //if (loggedinuser == comboBox1.SelectedItem.ToString())
                //{
                //    selectCMD1.ExecuteNonQuery();
                //}
                //selectCMD1.ExecuteNonQuery();
                selectCMD2.ExecuteNonQuery();
                con.Close();
                transferreportload();
            }
        }
    }
}
