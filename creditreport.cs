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
<<<<<<< Updated upstream
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser, flag FROM newentrytable", con);
=======
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') AND(giver = '"+label11.Text+ "' or taker = '" + label11.Text + "' or loggedinuser = '" + label11.Text + "'))", con);
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
                label10.Text = transsum.ToString();
                //Balance sum in label
<<<<<<< Updated upstream
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)-SUM(TransAmount)) FROM newentrytable");
=======
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)    ) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
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
                string transstring = "Transfer";
                string crestring = "Credit";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + transstring + "' OR status ='" + crestring + "' OR flag='1')", con);
=======
                string crestring = "Credit";
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
>>>>>>> Stashed changes
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = selectCMD;
                con.Open();
                DataSet DS = new DataSet();
                DA.Fill(DS, "newentrytable");
                dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

<<<<<<< Updated upstream
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
=======
                SqlCommand crquery = new SqlCommand("SELECT SUM(CrAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "' or taker = '" + label11.Text + "') AND (status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                crquery.Connection = con;
                object crsum = crquery.ExecuteScalar();
                label4.Text = crsum.ToString();
                SqlCommand debquery = new SqlCommand("SELECT SUM(DebAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "' or taker = '" + label11.Text + "') AND (status='Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                debquery.Connection = con;
                object debsum = debquery.ExecuteScalar();
                label5.Text = debsum.ToString();
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where ((loggedinuser ='" + label11.Text + "' or taker = '" + label11.Text + "') AND (status != 'Credit' AND status != 'Debit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)    ) FROM newentrytable where ((loggedinuser ='" + label11.Text + "' or taker = '" + label11.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
>>>>>>> Stashed changes
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
                var hastaksmk = row.Cells["hastaksmk"].Value;
                var hastak = row.Cells["hastak"].Value;
                var loggedinuser = row.Cells["loggedinuser"].Value;
                string note = textBox1.Text;
                if (id != null) { }
                else
                {
                    id = row.Cells[1].Value;
                }

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True;");
                con.Open();
<<<<<<< Updated upstream
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Debit', DebAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                //SqlCommand selectCMD1 = new SqlCommand("update newentrytable set DebAmount = CrAmount where ID ='" + id + "'", con);
                //SqlCommand selectCMD2 = new SqlCommand("update newentrytable set note = '" + note + "' where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,CrAmount,TransAmount,DebAmount,note) values " +
                                        "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','" + hastaksmk + "',N'" + hastak + "','Debit','"+cramount+"','"+transamount+"',0,'" + debamount + "','" + note + "')", con);
=======
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Debit', DebAmount = CrAmount, CrAmount= 0  where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,CrAmount,TransAmount,DebAmount) values " +
                                        "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Debit','" + cramount + "','" + transamount + "',0,'" + debamount + "')", con);
>>>>>>> Stashed changes

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
                var hastaksmk = row.Cells["hastaksmk"].Value;
                var hastak = row.Cells["hastak"].Value;
                var loggedinuser = row.Cells["loggedinuser"].Value;
                MessageBox.Show(amount.ToString());
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
<<<<<<< Updated upstream

                //if(label11.Text== row.Cells["taker"].Value)
                //{
                //    SqlCommand selectCMD = new SqlCommand("insert newentrytable set status = 'Transfer' , giver = '" + label11.Text + "', taker = '" + To + "' , TransAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                //    INSERT INTO ins_duplicate VALUES(5,'Wild Dog') ON DUPLICATE KEY UPDATE animal = 'Wild Dog';
                //}
                SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Transfer' , giver = '"+label11.Text+"', taker = '"+To+"' , TransAmount = CrAmount , note = '" + note + "'  where ID ='" + id + "'", con);
                SqlCommand selectCMD1 = new SqlCommand("insert into newentrytable (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,giver,taker,CrAmount,TransAmount,note,flag) values ('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','" + hastaksmk + "',N'" + hastak + "','Credit','" + label11.Text + "','" + To + "','"+amount + "',0,'" + note + "',1)", con );
                //"status = 'Credit' , giver = '"+label11.Text+"', taker = '"+To+ "' , Cramount = TransAmount, TransAmount = 0 , note = '" + note + "'  where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,hastaksmk,hastak,status,giver,taker,CrAmount,TransAmount,DebAmount,note) values " +
                    "                                                       ('"+smk+ "',N'" + PresentCity + "',N'" + NativeCity + "',N'" +FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','" + hastaksmk + "',N'" + hastak+ "','Transfer','" + label11.Text + "','" + To + "','" + cramount + "','" + transamount + "','" + debamount + "','" + note + "')", con);

                selectCMD.ExecuteNonQuery();
                if (loggedinuser == comboBox1.Text)
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
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            string sqlquery = "SELECT * from newentrytable where submissiontime between '" + dateTimePicker2.Text + "' and '" + dateTimePicker3.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();

=======
                //SqlCommand selectCMD = new SqlCommand("update newentrytable set status = 'Transfer' , giver = '" + label11.Text + "', taker = '" + To + "' , TransAmount = CrAmount, CrAmount= 0    where ID ='" + id + "'", con);
                SqlCommand selectCMD = new SqlCommand("insert into newentrytable (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,giver,taker,DebAmount,CrAmount,loggedinuser) " +
                    "values " +
                    "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Debit','" + label11.Text + "','" + To + "','" + amount + "',0,'" + loggedinuser + "')", con);
                SqlCommand selectCMD1 = new SqlCommand("insert into newentrytable (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,giver,taker,CrAmount,DebAmount,loggedinuser) " +
                    "values " +
                    "('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "','Transfer','" + label11.Text + "','" + To + "','" + amount + "',0,'" + To + "')", con);
                //"status = 'Credit' , giver = '"+label11.Text+"', taker = '"+To+ "' , Cramount = TransAmount, TransAmount = 0 , note = '" + note + "'  where ID ='" + id + "'", con);
                SqlCommand selectCMD2 = new SqlCommand("insert into history (SMK,PresentCity,NativeCity,FatherName,Surname,MobileNumber,Nimit,name,status,taker,CrAmount,TransAmount,DebAmount) values " +
                    "                                                       ('" + smk + "',N'" + PresentCity + "',N'" + NativeCity + "',N'" + FatherName + "',N'" + Surname + "','" + MobileNumber + "',N'" + Nimit + "',N'" + name + "', 'Transfer','" + label11.Text + "','" + cramount + "','" + transamount + "','" + debamount + "')", con);

                selectCMD.ExecuteNonQuery();
                selectCMD1.ExecuteNonQuery();
                selectCMD2.ExecuteNonQuery();
                con.Close();
                
            }
            Displaydata();
            reportload();
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
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
=======
        private void Button7_Click(object sender, EventArgs e)
        {

            if (label11.Text == "admin")
            {
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                //MessageBox.Show(fromReportDate);
                //MessageBox.Show(toReportDate);
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "') AND(giver = '" + label11.Text + "' or taker = '" + label11.Text + "' or loggedinuser = '" + label11.Text + "'))", con);
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
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)    ) FROM newentrytable where (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "')");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();

            }
            else
            {
                string crestring = "Credit";
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                SqlCommand balquery = new SqlCommand("SELECT (SUM(CrAmount)-SUM(DebAmount)) FROM newentrytable where ((loggedinuser ='" + label11.Text + "') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))");
                balquery.Connection = con;
                object balsum = balquery.ExecuteScalar();
                label6.Text = balsum.ToString();
                con.Close();
>>>>>>> Stashed changes
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (label11.Text == "admin")
            {
<<<<<<< Updated upstream
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where SMK like '"+textBox2.Text+"' ", con);
=======
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ( SMK = '"+textBox2.Text+"' AND (status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
<<<<<<< Updated upstream
                /*DataView dv = DS.Tables[0].DefaultView;
                dv.RowFilter = string.Format("loggedinuser LIKE '%{0}%' OR giver LIKE '%{0}%' OR taker LIKE '%{0}%'", label11.Text);
                dataGridView1.DataSource = dv;*/


                /*label4.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[9].FormattedValue.ToString() != string.Empty
                               select Convert.ToInt32(row.Cells[9].FormattedValue)).Sum().ToString();*/
                string transstring = "Transfer";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\thal bhet new\thalbhet\newentrydb.mdf;Integrated Security=True");
                SqlCommand selectCMD = new SqlCommand("SELECT ID, SMK, name, FatherName, Surname, PresentCity, NativeCity,MobileNumber, Nimit, CrAmount, TransAmount, hastaksmk, hastak, submissiontime, enrtydatetime, status, note, giver, taker, loggedinuser FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND (status IS NULL OR status ='" + transstring + "') AND SMK like '" + textBox2.Text + "'", con);
=======
                string fromReportDate = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string toReportDate = dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM newentrytable where ( SMK = '" + textBox2.Text + "' AND (loggedinuser ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) AND ((status='Credit') AND (enrtydate BETWEEN '" + fromReportDate + "' AND '" + toReportDate + "'))", con);
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
                SqlCommand transquery = new SqlCommand("SELECT SUM(TransAmount) FROM newentrytable where (loggedinuser ='" + label11.Text + "' OR giver ='" + label11.Text + "' OR taker ='" + label11.Text + "' ) ");
                transquery.Connection = con;
                object transsum = transquery.ExecuteScalar();
                label10.Text = transsum.ToString();
            }
        }
    }
}
