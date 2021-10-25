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
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);

        public transferreport(string username)
        {
            InitializeComponent();
            label2.BackColor = Color.FromArgb(246, 73, 0);
            label5.BackColor = Color.FromArgb(246, 73, 0);
            label1.BackColor = Color.FromArgb(37, 154, 92);
            label4.BackColor = Color.FromArgb(37, 154, 92);
            label9.BackColor = Color.FromArgb(246, 73, 0);
            label3.BackColor = Color.FromArgb(37, 154, 92);
            label6.BackColor = Color.FromArgb(37, 154, 92);
            label8.BackColor = Color.FromArgb(246, 73, 0);
            label14.BackColor = Color.FromArgb(246, 73, 0);
            label15.BackColor = Color.FromArgb(246, 73, 0);
            label12.Text = username;
        }

        private void transferreport_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePicker1.Text);
            transferreportload();
            
        }
        private void transferreportload()
        {
            nimitcombo();
            label14.Visible = false;
            label15.Visible = false;
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,DebAmount,enrtydate, enrtytime,submissiontime, loggedinuser FROM newentrytable where ((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                dataGridView1.AllowUserToAddRows = false;
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                //Debit sum in label
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                //Transfer sum in label
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
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
                //string debstring = "Transfer";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, status,DebAmount, enrtydate,enrtytime,submissiontime,loggedinuser FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where (loggedinuser ='" + label12.Text + "') ");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "' ) AND (status = 'Debit'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND (status != 'Credit' AND status != 'Debit')) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where (loggedinuser = '" + label12.Text + "')");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,DebAmount,enrtydate, enrtytime,submissiontime, loggedinuser FROM newentrytable where ((SMK = '"+textBox1.Text+"') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                dataGridView1.AllowUserToAddRows = false;
                con.Close();

            }
            else
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";

                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, status,DebAmount, enrtydate,enrtytime,submissiontime,loggedinuser FROM newentrytable where ((SMK = '" + textBox1.Text + "') AND (loggedinuser ='" + label12.Text + "') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                con.Close();


            }
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount,DebAmount,submissiontime, enrtydate, loggedinuser FROM newentrytable where((loggedinuser = 'admin') AND(status != 'Credit' AND status != 'Debit') AND enrtydate between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "') ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //dataGridView1.DataSource = dt;
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DataSet DS = new DataSet();
            DA.Fill(DS, "newentrytable");
            dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
            con.Close();
        }
        public void exporttoexcel()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
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

            string folderpath = "E:\\PDF\\";
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
                MessageBox.Show("Pdf is exported to E:\\TransferReport");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exporttoexcel();
        }

       
        private void nimitcombo()
        {
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Nimit from Nimit";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Nimit"]);
            }
            con.Close();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                MessageBox.Show(toReportDate);
                //SqlCommand selectCMD = new SqlCommand(", con);
                string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, status, DebAmount, submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                //DataTable dt = new DataTable();
                //dt.Load(cmd.ExecuteReader());
                //dataGridView1.DataSource = dt;
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                //Debit sum in label
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                //Transfer sum in label
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }
            else
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                MessageBox.Show(fromReportDate);
                MessageBox.Show(toReportDate);
                //SqlCommand selectCMD = new SqlCommand(", con);
                string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, status, DebAmount, submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where((status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') AND (loggedinuser ='" + label12.Text + "'))";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                //DataTable dt = new DataTable();
                //dt.Load(cmd.ExecuteReader());
                //dataGridView1.DataSource = dt;
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "' ) AND (status = 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                //Balance sum in label
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where ((loggedinuser = '" + label12.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            transferreportload();
        }

        private void Button5_Click(object sender, EventArgs e)
        {          

            
            if (label12.Text == "admin")
            {
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber,  status, CrAmount,DebAmount, submissiontime, enrtydate,enrtytime, loggedinuser FROM newentrytable where (((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount,DebAmount submissiontime, enrtydate,enrtytime, loggedinuser FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND ((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                SqlCommand sumquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where (((loggedinuser ='" + label12.Text + "') AND ((status != 'Credit' AND status != 'Debit') AND status = '" + comboBox1.SelectedItem.ToString() + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                sumquery.Connection = con;
                object sum = sumquery.ExecuteScalar();
                label15.Text = sum.ToString();
                con.Close();
            }
            label14.Visible = true;
            label15.Visible = true;
        }
    }
}
