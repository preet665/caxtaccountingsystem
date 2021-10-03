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
    public partial class export : Form
    {
        public export()
        {
            InitializeComponent();
        }

        private void export_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.newentrytable' table. You can move, or remove it, as needed.
            this.newentrytableTableAdapter.Fill(this.DataSet1.newentrytable);

            this.reportViewer1.RefreshReport();
        }
    }
}
