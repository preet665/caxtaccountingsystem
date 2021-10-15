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
    public partial class ledger : Form
    {
        public ledger()
        {
            InitializeComponent();
        }

        private void ledger_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT SMK,name,MobileNumber,PresentCity, Count(*) FROM newentrytable GROUP BY SMK,name,MobileNumber,PresentCity", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "history");
            dataGridView1.DataSource = DS.Tables["history"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("SELECT SMK,name,MobileNumber,PresentCity, Count(*) FROM newentrytable where SMK like '" + textBox1.Text + "' GROUP BY SMK,name,MobileNumber,PresentCity", con);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "history");
            dataGridView1.DataSource = DS.Tables["history"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
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
            using (FileStream stream = new FileStream(folderpath + "LedgerReport.pdf", FileMode.Create))
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

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var smk = row.Cells["SMK"].Value;
                label2.Text = Convert.ToString(smk);
                showledger sl = new showledger(label2.Text);
                sl.ShowDialog();
            }
        }}
}



