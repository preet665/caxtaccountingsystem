
namespace thalbhet
{
    partial class crereport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            //this.newentrydbDataSet = new thalbhet.newentrydbDataSet();
            this.newentrytableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.newentrytableTableAdapter = new thalbhet.newentrydbDataSetTableAdapters.newentrytableTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presentCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nativeCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatherNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobileNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hastaksmkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hastakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submissiontimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrtydatetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.newentrydbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.sMKDataGridViewTextBoxColumn,
            this.presentCityDataGridViewTextBoxColumn,
            this.nativeCityDataGridViewTextBoxColumn,
            this.fatherNameDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.mobileNumberDataGridViewTextBoxColumn,
            this.nimitDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.crAmountDataGridViewTextBoxColumn,
            this.debAmountDataGridViewTextBoxColumn,
            this.transAmountDataGridViewTextBoxColumn,
            this.hastaksmkDataGridViewTextBoxColumn,
            this.hastakDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.submissiontimeDataGridViewTextBoxColumn,
            this.enrtydatetimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.newentrytableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // newentrydbDataSet
            // 
            //this.newentrydbDataSet.DataSetName = "newentrydbDataSet";
            //this.newentrydbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newentrytableBindingSource
            // 
            this.newentrytableBindingSource.DataMember = "newentrytable";
            //this.newentrytableBindingSource.DataSource = this.newentrydbDataSet;
            // 
            // newentrytableTableAdapter
            // 
            //this.newentrytableTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // sMKDataGridViewTextBoxColumn
            // 
            this.sMKDataGridViewTextBoxColumn.DataPropertyName = "SMK";
            this.sMKDataGridViewTextBoxColumn.HeaderText = "SMK";
            this.sMKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sMKDataGridViewTextBoxColumn.Name = "sMKDataGridViewTextBoxColumn";
            this.sMKDataGridViewTextBoxColumn.Width = 125;
            // 
            // presentCityDataGridViewTextBoxColumn
            // 
            this.presentCityDataGridViewTextBoxColumn.DataPropertyName = "PresentCity";
            this.presentCityDataGridViewTextBoxColumn.HeaderText = "PresentCity";
            this.presentCityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.presentCityDataGridViewTextBoxColumn.Name = "presentCityDataGridViewTextBoxColumn";
            this.presentCityDataGridViewTextBoxColumn.Width = 125;
            // 
            // nativeCityDataGridViewTextBoxColumn
            // 
            this.nativeCityDataGridViewTextBoxColumn.DataPropertyName = "NativeCity";
            this.nativeCityDataGridViewTextBoxColumn.HeaderText = "NativeCity";
            this.nativeCityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nativeCityDataGridViewTextBoxColumn.Name = "nativeCityDataGridViewTextBoxColumn";
            this.nativeCityDataGridViewTextBoxColumn.Width = 125;
            // 
            // fatherNameDataGridViewTextBoxColumn
            // 
            this.fatherNameDataGridViewTextBoxColumn.DataPropertyName = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.HeaderText = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fatherNameDataGridViewTextBoxColumn.Name = "fatherNameDataGridViewTextBoxColumn";
            this.fatherNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // mobileNumberDataGridViewTextBoxColumn
            // 
            this.mobileNumberDataGridViewTextBoxColumn.DataPropertyName = "MobileNumber";
            this.mobileNumberDataGridViewTextBoxColumn.HeaderText = "MobileNumber";
            this.mobileNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mobileNumberDataGridViewTextBoxColumn.Name = "mobileNumberDataGridViewTextBoxColumn";
            this.mobileNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // nimitDataGridViewTextBoxColumn
            // 
            this.nimitDataGridViewTextBoxColumn.DataPropertyName = "Nimit";
            this.nimitDataGridViewTextBoxColumn.HeaderText = "Nimit";
            this.nimitDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nimitDataGridViewTextBoxColumn.Name = "nimitDataGridViewTextBoxColumn";
            this.nimitDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // crAmountDataGridViewTextBoxColumn
            // 
            this.crAmountDataGridViewTextBoxColumn.DataPropertyName = "CrAmount";
            this.crAmountDataGridViewTextBoxColumn.HeaderText = "CrAmount";
            this.crAmountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.crAmountDataGridViewTextBoxColumn.Name = "crAmountDataGridViewTextBoxColumn";
            this.crAmountDataGridViewTextBoxColumn.Width = 125;
            // 
            // debAmountDataGridViewTextBoxColumn
            // 
            this.debAmountDataGridViewTextBoxColumn.DataPropertyName = "DebAmount";
            this.debAmountDataGridViewTextBoxColumn.HeaderText = "DebAmount";
            this.debAmountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.debAmountDataGridViewTextBoxColumn.Name = "debAmountDataGridViewTextBoxColumn";
            this.debAmountDataGridViewTextBoxColumn.Width = 125;
            // 
            // transAmountDataGridViewTextBoxColumn
            // 
            this.transAmountDataGridViewTextBoxColumn.DataPropertyName = "TransAmount";
            this.transAmountDataGridViewTextBoxColumn.HeaderText = "TransAmount";
            this.transAmountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.transAmountDataGridViewTextBoxColumn.Name = "transAmountDataGridViewTextBoxColumn";
            this.transAmountDataGridViewTextBoxColumn.Width = 125;
            // 
            // hastaksmkDataGridViewTextBoxColumn
            // 
            this.hastaksmkDataGridViewTextBoxColumn.DataPropertyName = "hastaksmk";
            this.hastaksmkDataGridViewTextBoxColumn.HeaderText = "hastaksmk";
            this.hastaksmkDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hastaksmkDataGridViewTextBoxColumn.Name = "hastaksmkDataGridViewTextBoxColumn";
            this.hastaksmkDataGridViewTextBoxColumn.Width = 125;
            // 
            // hastakDataGridViewTextBoxColumn
            // 
            this.hastakDataGridViewTextBoxColumn.DataPropertyName = "hastak";
            this.hastakDataGridViewTextBoxColumn.HeaderText = "hastak";
            this.hastakDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hastakDataGridViewTextBoxColumn.Name = "hastakDataGridViewTextBoxColumn";
            this.hastakDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "note";
            this.noteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.Width = 125;
            // 
            // submissiontimeDataGridViewTextBoxColumn
            // 
            this.submissiontimeDataGridViewTextBoxColumn.DataPropertyName = "submissiontime";
            this.submissiontimeDataGridViewTextBoxColumn.HeaderText = "submissiontime";
            this.submissiontimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.submissiontimeDataGridViewTextBoxColumn.Name = "submissiontimeDataGridViewTextBoxColumn";
            this.submissiontimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // enrtydatetimeDataGridViewTextBoxColumn
            // 
            this.enrtydatetimeDataGridViewTextBoxColumn.DataPropertyName = "enrtydatetime";
            this.enrtydatetimeDataGridViewTextBoxColumn.HeaderText = "enrtydatetime";
            this.enrtydatetimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.enrtydatetimeDataGridViewTextBoxColumn.Name = "enrtydatetimeDataGridViewTextBoxColumn";
            this.enrtydatetimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // crereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "crereport";
            this.Text = "crereport";
            this.Load += new System.EventHandler(this.crereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.newentrydbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        //private newentrydbDataSet newentrydbDataSet;
        private System.Windows.Forms.BindingSource newentrytableBindingSource;
        //private newentrydbDataSetTableAdapters.newentrytableTableAdapter newentrytableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn presentCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nativeCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatherNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hastaksmkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hastakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submissiontimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrtydatetimeDataGridViewTextBoxColumn;
    }
}