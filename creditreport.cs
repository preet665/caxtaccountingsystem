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
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        public creditreporttrial(string Username)
        {
            InitializeComponent();
            label2.BackColor = Color.FromArgb(246, 73, 0);
            label5.BackColor = Color.FromArgb(246, 73, 0);
            label1.BackColor = Color.FromArgb(37, 154, 92);
            label4.BackColor = Color.FromArgb(37, 154, 92);
            label9.BackColor = Color.FromArgb(246, 73, 0);
            label3.BackColor = Color.FromArgb(37, 154, 92);
            label6.BackColor = Color.FromArgb(37, 154, 92);
            label10.BackColor = Color.FromArgb(246, 73, 0);
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
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount, submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                label10.Text = transsum.ToString();
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
                //string transstring = "Transfer";
                string crestring = "Credit";
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount, TransAmount, submissiontime, enrtydate, enrtytime, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "') AND (status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "') AND (status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount) ) FROM newentrytable where ((loggedinuser ='" + label11.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
            }
            this.Refresh();
            usercombo();
        }
        public void usercombo()
        {

            SqlCommand cmd;
            SqlDataReader dr;
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
        void Displaydata()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Select * from newentrytable", con);
            DataTable dt = new DataTable();
            con.Open();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var deck = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                deck.Add(row.Index);
                var id = row.Cells[0].Value;
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
                var loggedinuser = row.Cells["loggedinuser"].Value;
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;
                }

                con.Open();
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Debit', DebAmount = CrAmount  where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,CrAmount,TransAmount,DebAmount) values " +
                                        "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Debit','" + cramount + "','" + transamount + "',0,'" + debamount + "')", con);

                selectCMD.ExecuteNonQuery();
                con.Close();
            }
            reportload();
            Displaydata();
        }
        private void button2_Click(object sender, EventArgs e)
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

                string To = comboBox1.SelectedItem.ToString();
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;

                }
                con.Open();

                //if(label11.Text== row.Cells["taker"].Value)
                //{
                //    SqlCommand selectCMD = new SqlCommand("insert newentrytable set status = 'Transfer' , giver = '" + label11.Text + "', taker = '" + To + "' , TransAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                //    INSERT INTO ins_duplicate VALUES(5,'Wild Dog') ON DUPLICATE KEY UPDATE animal = 'Wild Dog';
                //}
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Transfer' , giver = '" + label11.Text + "', taker = '" + To + "' , TransAmount = CrAmount ,  where ID ='" + id + "'", con);
                SqlCommand selectCMD1 = new SqlCommand("insert into newentrytable (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,giver,taker,CrAmount,TransAmount,note,flag) values ('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Credit','" + label11.Text + "','" + To + "','" + amount + "',0,,1)", con);
                //"status = 'Credit' , giver = '"+label11.Text+"', taker = '"+To+ "' , Cramount = TransAmount, TransAmount = 0 , note = '" + note + "'  where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,giver,taker,CrAmount,TransAmount,DebAmount,note) values " +
                    "                                                       ('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "', 'Transfer','" + label11.Text + "','" + To + "','" + cramount + "','" + transamount + "','" + debamount + "')", con);

                selectCMD.ExecuteNonQuery();
                if (loggedinuser == comboBox1.SelectedItem.ToString())
                {
                    selectCMD1.ExecuteNonQuery();
                }
                selectCMD1.ExecuteNonQuery();
                selectCMD2.ExecuteNonQuery();
                con.Close();
                reportload();
            }
            Displaydata();
        }

        private void dateTimePicker3_CloseUp(object sender, EventArgs e)
        {
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
        private void button5_Click(object sender, EventArgs e)
        {
            exporttoexcel2();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            reportload();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            MessageBox.Show(fromReportDate);
            MessageBox.Show(toReportDate);
            string sqlquery = "SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount, enrtydate, enrtytime, submissiontime, loggedinuser FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))";
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
            label10.Text = transsum.ToString();
            //Balance sum in label
            SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
            balquery.Connection = con;
            object balsum = balquery.ExecuteScalar();
            label6.Text = balsum.ToString();
            con.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (label11.Text == "admin")
            {
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount, submissiontime, enrtydate, enrtytime, loggedinuser FROM newentrytable where ( SMK = '"+textBox2.Text+"' AND (status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, status, CrAmount, TransAmount, submissiontime, enrtydate, enrtytime, taker, loggedinuser FROM newentrytable where ( SMK = '" + textBox2.Text + "' AND (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;
                con.Close();

            }
        }
    }
}
