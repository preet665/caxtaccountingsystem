using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thalbhet
{
    public partial class Reportoption : Form
    {
        public Reportoption(string UserName)
        {
            InitializeComponent();
            label1.Text = UserName;
        }

        private void Reportoption_Load(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(246, 73, 0);
            button1.BackColor = Color.FromArgb(37, 154, 92);
            if(label1.Text != "admin")
            {
                button5.Visible = false;
                button4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creditreporttrial crereport = new creditreporttrial(label1.Text);
            crereport.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            debitreport debreport = new debitreport(label1.Text);
            debreport.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transferreport transreport = new transferreport(label1.Text);
            transreport.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ledger ledge = new ledger();
            ledge.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminpanel adp = new adminpanel(label1.Text);
            adp.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            modify md = new modify();
            md.ShowDialog();
        }
    }
}
