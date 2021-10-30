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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace thalbhet
{
    public partial class debitreport : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        public debitreport(string Username)
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
            label11.Text = Username;

        }

        private void debitreport_Load(object sender, EventArgs e)
        {
            debitreportload();
            

        }
        public void debitreportload()
        {
            if (label11.Text == "admin")
            {
                string debstring = "Debit";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,  DebAmount,submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where ((status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
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
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount) ) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
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
                string debstring = "Debit";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,  DebAmount, TransAmount, submissiontime, enrtydate, enrtytime, status, loggedinuser FROM newentrytable where ((loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + debstring + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                SqlCommand transquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label12.Text + "') AND (status != 'Credit' AND status != 'Debit')) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label9.Text = transsum.ToString();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount) ) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }
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
            using (FileStream stream = new FileStream(folderpath + "DebitReport.pdf", FileMode.Create))
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (label11.Text == "admin")
            {
                string debstring = "Debit";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,  DebAmount,submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where ((SMK = '" + textBox1.Text + "') AND (status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                con.Close();

            }
            else
            {
                string debstring = "Debit";
                string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status,  DebAmount, TransAmount, submissiontime, enrtydate, enrtytime, status, loggedinuser FROM newentrytable where ((SMK = '" + textBox1.Text + "') AND (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + debstring + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                con.Close();


            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            debitreportload();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string fromReportDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string toReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            MessageBox.Show(fromReportDate);
            MessageBox.Show(toReportDate);
            string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity, MobileNumber, status, DebAmount, submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where ((status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
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
    }
}
