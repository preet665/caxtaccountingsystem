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
    public partial class Ledger : Form
    {
        public Ledger()
        {
            InitializeComponent();
        }

        private void Ledger_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newentrydbDataSet.newentrytable' table. You can move, or remove it, as needed.
            this.newentrytableTableAdapter.Fill(this.newentrydbDataSet.newentrytable);

        }

        private void advancedDataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = advancedDataGridView2.FilterString;
        }

        private void advancedDataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = advancedDataGridView2.SortString;
        }
    }
}
