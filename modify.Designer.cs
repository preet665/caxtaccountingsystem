namespace thalbhet
{
    partial class modify
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
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
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
            this.giverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.takerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loggedinuserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newentrytableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new thalbhet.DataSet2();
            this.newentrytableTableAdapter = new thalbhet.DataSet2TableAdapters.newentrytableTableAdapter();
            this.newentrydbDataSet1 = new thalbhet.newentrydbDataSet1();
            this.newentrytable1390627997BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.newentrytable__1390627997_TableAdapter = new thalbhet.newentrydbDataSet1TableAdapters.newentrytable__1390627997_TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrydbDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytable1390627997BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToOrderColumns = true;
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.giverDataGridViewTextBoxColumn,
            this.takerDataGridViewTextBoxColumn,
            this.loggedinuserDataGridViewTextBoxColumn,
            this.flagDataGridViewTextBoxColumn});
            this.advancedDataGridView1.DataSource = this.newentrytableBindingSource;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 12);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.Size = new System.Drawing.Size(1630, 616);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.AdvancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.AdvancedDataGridView1_FilterStringChanged);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // sMKDataGridViewTextBoxColumn
            // 
            this.sMKDataGridViewTextBoxColumn.DataPropertyName = "SMK";
            this.sMKDataGridViewTextBoxColumn.HeaderText = "SMK";
            this.sMKDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.sMKDataGridViewTextBoxColumn.Name = "sMKDataGridViewTextBoxColumn";
            this.sMKDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // presentCityDataGridViewTextBoxColumn
            // 
            this.presentCityDataGridViewTextBoxColumn.DataPropertyName = "PresentCity";
            this.presentCityDataGridViewTextBoxColumn.HeaderText = "PresentCity";
            this.presentCityDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.presentCityDataGridViewTextBoxColumn.Name = "presentCityDataGridViewTextBoxColumn";
            this.presentCityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nativeCityDataGridViewTextBoxColumn
            // 
            this.nativeCityDataGridViewTextBoxColumn.DataPropertyName = "NativeCity";
            this.nativeCityDataGridViewTextBoxColumn.HeaderText = "NativeCity";
            this.nativeCityDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nativeCityDataGridViewTextBoxColumn.Name = "nativeCityDataGridViewTextBoxColumn";
            this.nativeCityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // fatherNameDataGridViewTextBoxColumn
            // 
            this.fatherNameDataGridViewTextBoxColumn.DataPropertyName = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.HeaderText = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.fatherNameDataGridViewTextBoxColumn.Name = "fatherNameDataGridViewTextBoxColumn";
            this.fatherNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            this.surnameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobileNumberDataGridViewTextBoxColumn
            // 
            this.mobileNumberDataGridViewTextBoxColumn.DataPropertyName = "MobileNumber";
            this.mobileNumberDataGridViewTextBoxColumn.HeaderText = "MobileNumber";
            this.mobileNumberDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.mobileNumberDataGridViewTextBoxColumn.Name = "mobileNumberDataGridViewTextBoxColumn";
            this.mobileNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nimitDataGridViewTextBoxColumn
            // 
            this.nimitDataGridViewTextBoxColumn.DataPropertyName = "Nimit";
            this.nimitDataGridViewTextBoxColumn.HeaderText = "Nimit";
            this.nimitDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nimitDataGridViewTextBoxColumn.Name = "nimitDataGridViewTextBoxColumn";
            this.nimitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // crAmountDataGridViewTextBoxColumn
            // 
            this.crAmountDataGridViewTextBoxColumn.DataPropertyName = "CrAmount";
            this.crAmountDataGridViewTextBoxColumn.HeaderText = "CrAmount";
            this.crAmountDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.crAmountDataGridViewTextBoxColumn.Name = "crAmountDataGridViewTextBoxColumn";
            this.crAmountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // debAmountDataGridViewTextBoxColumn
            // 
            this.debAmountDataGridViewTextBoxColumn.DataPropertyName = "DebAmount";
            this.debAmountDataGridViewTextBoxColumn.HeaderText = "DebAmount";
            this.debAmountDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.debAmountDataGridViewTextBoxColumn.Name = "debAmountDataGridViewTextBoxColumn";
            this.debAmountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // transAmountDataGridViewTextBoxColumn
            // 
            this.transAmountDataGridViewTextBoxColumn.DataPropertyName = "TransAmount";
            this.transAmountDataGridViewTextBoxColumn.HeaderText = "TransAmount";
            this.transAmountDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.transAmountDataGridViewTextBoxColumn.Name = "transAmountDataGridViewTextBoxColumn";
            this.transAmountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // hastaksmkDataGridViewTextBoxColumn
            // 
            this.hastaksmkDataGridViewTextBoxColumn.DataPropertyName = "hastaksmk";
            this.hastaksmkDataGridViewTextBoxColumn.HeaderText = "hastaksmk";
            this.hastaksmkDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.hastaksmkDataGridViewTextBoxColumn.Name = "hastaksmkDataGridViewTextBoxColumn";
            this.hastaksmkDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // hastakDataGridViewTextBoxColumn
            // 
            this.hastakDataGridViewTextBoxColumn.DataPropertyName = "hastak";
            this.hastakDataGridViewTextBoxColumn.HeaderText = "hastak";
            this.hastakDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.hastakDataGridViewTextBoxColumn.Name = "hastakDataGridViewTextBoxColumn";
            this.hastakDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "note";
            this.noteDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // submissiontimeDataGridViewTextBoxColumn
            // 
            this.submissiontimeDataGridViewTextBoxColumn.DataPropertyName = "submissiontime";
            this.submissiontimeDataGridViewTextBoxColumn.HeaderText = "submissiontime";
            this.submissiontimeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.submissiontimeDataGridViewTextBoxColumn.Name = "submissiontimeDataGridViewTextBoxColumn";
            this.submissiontimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // giverDataGridViewTextBoxColumn
            // 
            this.giverDataGridViewTextBoxColumn.DataPropertyName = "giver";
            this.giverDataGridViewTextBoxColumn.HeaderText = "giver";
            this.giverDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.giverDataGridViewTextBoxColumn.Name = "giverDataGridViewTextBoxColumn";
            this.giverDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // takerDataGridViewTextBoxColumn
            // 
            this.takerDataGridViewTextBoxColumn.DataPropertyName = "taker";
            this.takerDataGridViewTextBoxColumn.HeaderText = "taker";
            this.takerDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.takerDataGridViewTextBoxColumn.Name = "takerDataGridViewTextBoxColumn";
            this.takerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // loggedinuserDataGridViewTextBoxColumn
            // 
            this.loggedinuserDataGridViewTextBoxColumn.DataPropertyName = "loggedinuser";
            this.loggedinuserDataGridViewTextBoxColumn.HeaderText = "loggedinuser";
            this.loggedinuserDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.loggedinuserDataGridViewTextBoxColumn.Name = "loggedinuserDataGridViewTextBoxColumn";
            this.loggedinuserDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // flagDataGridViewTextBoxColumn
            // 
            this.flagDataGridViewTextBoxColumn.DataPropertyName = "flag";
            this.flagDataGridViewTextBoxColumn.HeaderText = "flag";
            this.flagDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.flagDataGridViewTextBoxColumn.Name = "flagDataGridViewTextBoxColumn";
            this.flagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // newentrytableBindingSource
            // 
            this.newentrytableBindingSource.DataMember = "newentrytable";
            this.newentrytableBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newentrytableTableAdapter
            // 
            this.newentrytableTableAdapter.ClearBeforeFill = true;
            // 
            // newentrydbDataSet1
            // 
            this.newentrydbDataSet1.DataSetName = "newentrydbDataSet1";
            this.newentrydbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newentrytable1390627997BindingSource
            // 
            this.newentrytable1390627997BindingSource.DataMember = "newentrytable (1390627997)";
            this.newentrytable1390627997BindingSource.DataSource = this.newentrydbDataSet1;
            // 
            // newentrytable__1390627997_TableAdapter
            // 
            this.newentrytable__1390627997_TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1639, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1715, 640);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.advancedDataGridView1);
            this.Name = "modify";
            this.Text = "modify";
            this.Load += new System.EventHandler(this.Modify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrydbDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newentrytable1390627997BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource newentrytableBindingSource;
        private DataSet2TableAdapters.newentrytableTableAdapter newentrytableTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn giverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn takerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loggedinuserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagDataGridViewTextBoxColumn;
        private newentrydbDataSet1 newentrydbDataSet1;
        private System.Windows.Forms.BindingSource newentrytable1390627997BindingSource;
        private newentrydbDataSet1TableAdapters.newentrytable__1390627997_TableAdapter newentrytable__1390627997_TableAdapter;
        private System.Windows.Forms.Button button1;
    }
}