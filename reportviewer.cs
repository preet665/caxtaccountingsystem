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
using System.Runtime.InteropServices;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace thalbhet
{
    public partial class reportviewer : Form
    {
        
        public reportviewer(string smk,string bal)
        {
            InitializeComponent();
            label1.Text = smk;
            label2.Text = bal;
        }


        public void reportviewer_Load(object sender, EventArgs e)
        {
            reportload();
        }

        public void reportload()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("select * from (SELECT TOP 4 * FROM newentrytable where SMK = '" + label1.Text + "' ORDER BY submissiontime DESC)AS TEMP where SMK LIKE '" + label1.Text + "'  order by submissiontime ASC; ", con);
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("Select FullNameGuj,[Mobile 1] From [dbo].[Page1$] where SMKId LIKE '" + label1.Text + "'", con2);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            con2.Open();
            DataSet2 DS = new DataSet2();

            DA.Fill(DS, "newentrytable");
            DA.SelectCommand = cmd2;
            DA.Fill(DS, "Page1$");
            //dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

            CrystalReport1 crypt = new CrystalReport1();
            crypt.Database.Tables["newentrytable"].SetDataSource(DS);
            crypt.Database.Tables["Page1_"].SetDataSource(DS);
            crypt.SetParameterValue("balance", label2.Text);
            //crypt.SetParameterValue("balance", Newentry.balance);
            //Text
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = crypt;
            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "E:\\bmsreceipt.pdf";
                CrExportOptions = crypt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                crypt.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void oreportload()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\newentrydb.mdf;Integrated Security=True");
            SqlCommand selectCMD = new SqlCommand("select * from (SELECT TOP 4 * FROM newentrytable where SMK = '" + label1.Text + "' ORDER BY submissiontime DESC)AS TEMP where SMK LIKE '" + label1.Text + "'  order by submissiontime ASC; ", con);
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\bank management system\thalbhet\smk.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("Select FullNameGuj,[Mobile 1] From [dbo].[Page1$] where SMKId LIKE '" + label1.Text + "'", con2);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = selectCMD;
            con.Open();
            con2.Open();
            DataSet2 DS = new DataSet2();

            DA.Fill(DS, "newentrytable");
            DA.SelectCommand = cmd2;
            DA.Fill(DS, "Page1$");
            //dataGridView1.DataSource = DS.Tables["newentrytable"].DefaultView;

            CrystalReport1 crypt = new CrystalReport1();
            crypt.Database.Tables["newentrytable"].SetDataSource(DS);
            crypt.Database.Tables["Page1_"].SetDataSource(DS);

            //crypt.SetParameterValue("balance", Newentry.balance);
            //Text
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = crypt;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
            PrintDialog printDialog = new PrintDialog();
            
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(crypt.ToString());
            reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
            reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
        }

    }
}
