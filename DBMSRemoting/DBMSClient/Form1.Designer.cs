
namespace DBMSClient
{
    partial class Form1
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.butCreateDatabase = new System.Windows.Forms.Button();
            this.butLoadDatabase = new System.Windows.Forms.Button();
            this.butSaveDatabase = new System.Windows.Forms.Button();
            this.textBoxCreateDatabase = new System.Windows.Forms.TextBox();
            this.textBoxLoadDatabase = new System.Windows.Forms.TextBox();
            this.butCreateTable = new System.Windows.Forms.Button();
            this.textBoxCreateTable = new System.Windows.Forms.TextBox();
            this.butDeleteTable = new System.Windows.Forms.Button();
            this.butAddRow = new System.Windows.Forms.Button();
            this.butDeleteRow = new System.Windows.Forms.Button();
            this.butAddColumn = new System.Windows.Forms.Button();
            this.butDeleteColumn = new System.Windows.Forms.Button();
            this.butCartesian = new System.Windows.Forms.Button();
            this.textBoxAddColumn = new System.Windows.Forms.TextBox();
            this.textBoxIntersectionFirstTableName = new System.Windows.Forms.TextBox();
            this.textBoxIntersectionSecondTableName = new System.Windows.Forms.TextBox();
            this.comboBoxColumnsTypes = new System.Windows.Forms.ComboBox();
            this.tablesControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 228);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(573, 326);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // butCreateDatabase
            // 
            this.butCreateDatabase.Location = new System.Drawing.Point(9, 96);
            this.butCreateDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.butCreateDatabase.Name = "butCreateDatabase";
            this.butCreateDatabase.Size = new System.Drawing.Size(98, 26);
            this.butCreateDatabase.TabIndex = 1;
            this.butCreateDatabase.Text = "New DB";
            this.butCreateDatabase.UseVisualStyleBackColor = true;
            this.butCreateDatabase.Click += new System.EventHandler(this.butCreateDatabase_Click);
            // 
            // butLoadDatabase
            // 
            this.butLoadDatabase.Location = new System.Drawing.Point(11, 11);
            this.butLoadDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.butLoadDatabase.Name = "butLoadDatabase";
            this.butLoadDatabase.Size = new System.Drawing.Size(98, 24);
            this.butLoadDatabase.TabIndex = 2;
            this.butLoadDatabase.Text = "Open";
            this.butLoadDatabase.UseVisualStyleBackColor = true;
            this.butLoadDatabase.Click += new System.EventHandler(this.butLoadDatabase_Click);
            // 
            // butSaveDatabase
            // 
            this.butSaveDatabase.Location = new System.Drawing.Point(11, 39);
            this.butSaveDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.butSaveDatabase.Name = "butSaveDatabase";
            this.butSaveDatabase.Size = new System.Drawing.Size(98, 27);
            this.butSaveDatabase.TabIndex = 3;
            this.butSaveDatabase.Text = "Save";
            this.butSaveDatabase.UseVisualStyleBackColor = true;
            this.butSaveDatabase.Click += new System.EventHandler(this.butSaveDatabase_Click);
            // 
            // textBoxCreateDatabase
            // 
            this.textBoxCreateDatabase.Location = new System.Drawing.Point(9, 126);
            this.textBoxCreateDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreateDatabase.Name = "textBoxCreateDatabase";
            this.textBoxCreateDatabase.Size = new System.Drawing.Size(98, 20);
            this.textBoxCreateDatabase.TabIndex = 4;
            // 
            // textBoxLoadDatabase
            // 
            this.textBoxLoadDatabase.Location = new System.Drawing.Point(111, 14);
            this.textBoxLoadDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLoadDatabase.Name = "textBoxLoadDatabase";
            this.textBoxLoadDatabase.Size = new System.Drawing.Size(104, 20);
            this.textBoxLoadDatabase.TabIndex = 5;
            // 
            // butCreateTable
            // 
            this.butCreateTable.Location = new System.Drawing.Point(244, 12);
            this.butCreateTable.Margin = new System.Windows.Forms.Padding(2);
            this.butCreateTable.Name = "butCreateTable";
            this.butCreateTable.Size = new System.Drawing.Size(107, 22);
            this.butCreateTable.TabIndex = 6;
            this.butCreateTable.Text = "Add table";
            this.butCreateTable.UseVisualStyleBackColor = true;
            this.butCreateTable.Click += new System.EventHandler(this.butCreateTable_Click);
            // 
            // textBoxCreateTable
            // 
            this.textBoxCreateTable.Location = new System.Drawing.Point(244, 41);
            this.textBoxCreateTable.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreateTable.Name = "textBoxCreateTable";
            this.textBoxCreateTable.Size = new System.Drawing.Size(104, 20);
            this.textBoxCreateTable.TabIndex = 7;
            // 
            // butDeleteTable
            // 
            this.butDeleteTable.Location = new System.Drawing.Point(244, 68);
            this.butDeleteTable.Margin = new System.Windows.Forms.Padding(2);
            this.butDeleteTable.Name = "butDeleteTable";
            this.butDeleteTable.Size = new System.Drawing.Size(107, 22);
            this.butDeleteTable.TabIndex = 8;
            this.butDeleteTable.Text = "Delete table";
            this.butDeleteTable.UseVisualStyleBackColor = true;
            this.butDeleteTable.Click += new System.EventHandler(this.butDeleteTable_Click);
            // 
            // butAddRow
            // 
            this.butAddRow.Location = new System.Drawing.Point(475, 10);
            this.butAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.butAddRow.Name = "butAddRow";
            this.butAddRow.Size = new System.Drawing.Size(107, 27);
            this.butAddRow.TabIndex = 9;
            this.butAddRow.Text = "Add row";
            this.butAddRow.UseVisualStyleBackColor = true;
            this.butAddRow.Click += new System.EventHandler(this.butAddRow_Click);
            // 
            // butDeleteRow
            // 
            this.butDeleteRow.Location = new System.Drawing.Point(475, 41);
            this.butDeleteRow.Margin = new System.Windows.Forms.Padding(2);
            this.butDeleteRow.Name = "butDeleteRow";
            this.butDeleteRow.Size = new System.Drawing.Size(107, 27);
            this.butDeleteRow.TabIndex = 11;
            this.butDeleteRow.Text = "Delete row";
            this.butDeleteRow.UseVisualStyleBackColor = true;
            this.butDeleteRow.Click += new System.EventHandler(this.butDeleteRow_Click);
            // 
            // butAddColumn
            // 
            this.butAddColumn.Location = new System.Drawing.Point(366, 12);
            this.butAddColumn.Margin = new System.Windows.Forms.Padding(2);
            this.butAddColumn.Name = "butAddColumn";
            this.butAddColumn.Size = new System.Drawing.Size(105, 22);
            this.butAddColumn.TabIndex = 12;
            this.butAddColumn.Text = "Add column";
            this.butAddColumn.UseVisualStyleBackColor = true;
            this.butAddColumn.Click += new System.EventHandler(this.button8_Click);
            // 
            // butDeleteColumn
            // 
            this.butDeleteColumn.Location = new System.Drawing.Point(366, 96);
            this.butDeleteColumn.Margin = new System.Windows.Forms.Padding(2);
            this.butDeleteColumn.Name = "butDeleteColumn";
            this.butDeleteColumn.Size = new System.Drawing.Size(105, 22);
            this.butDeleteColumn.TabIndex = 13;
            this.butDeleteColumn.Text = "Delete column";
            this.butDeleteColumn.UseVisualStyleBackColor = true;
            this.butDeleteColumn.Click += new System.EventHandler(this.butDeleteColumn_Click);
            // 
            // butCartesian
            // 
            this.butCartesian.Location = new System.Drawing.Point(246, 136);
            this.butCartesian.Margin = new System.Windows.Forms.Padding(2);
            this.butCartesian.Name = "butCartesian";
            this.butCartesian.Size = new System.Drawing.Size(105, 24);
            this.butCartesian.TabIndex = 14;
            this.butCartesian.Text = "Cartesian";
            this.butCartesian.UseVisualStyleBackColor = true;
            this.butCartesian.Click += new System.EventHandler(this.butCartesian_Click);
            // 
            // textBoxAddColumn
            // 
            this.textBoxAddColumn.Location = new System.Drawing.Point(366, 41);
            this.textBoxAddColumn.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddColumn.Name = "textBoxAddColumn";
            this.textBoxAddColumn.Size = new System.Drawing.Size(105, 20);
            this.textBoxAddColumn.TabIndex = 15;
            // 
            // textBoxIntersectionFirstTableName
            // 
            this.textBoxIntersectionFirstTableName.Location = new System.Drawing.Point(366, 139);
            this.textBoxIntersectionFirstTableName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIntersectionFirstTableName.Name = "textBoxIntersectionFirstTableName";
            this.textBoxIntersectionFirstTableName.Size = new System.Drawing.Size(99, 20);
            this.textBoxIntersectionFirstTableName.TabIndex = 16;
            // 
            // textBoxIntersectionSecondTableName
            // 
            this.textBoxIntersectionSecondTableName.Location = new System.Drawing.Point(475, 139);
            this.textBoxIntersectionSecondTableName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIntersectionSecondTableName.Name = "textBoxIntersectionSecondTableName";
            this.textBoxIntersectionSecondTableName.Size = new System.Drawing.Size(99, 20);
            this.textBoxIntersectionSecondTableName.TabIndex = 17;
            // 
            // comboBoxColumnsTypes
            // 
            this.comboBoxColumnsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumnsTypes.FormattingEnabled = true;
            this.comboBoxColumnsTypes.Items.AddRange(new object[] {
            "Integer",
            "Char",
            "String",
            "Real",
            "TimeInvl",
            "Time"});
            this.comboBoxColumnsTypes.Location = new System.Drawing.Point(366, 70);
            this.comboBoxColumnsTypes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxColumnsTypes.Name = "comboBoxColumnsTypes";
            this.comboBoxColumnsTypes.Size = new System.Drawing.Size(105, 21);
            this.comboBoxColumnsTypes.TabIndex = 18;
            // 
            // tablesControl
            // 
            this.tablesControl.Location = new System.Drawing.Point(9, 197);
            this.tablesControl.Margin = new System.Windows.Forms.Padding(2);
            this.tablesControl.Name = "tablesControl";
            this.tablesControl.SelectedIndex = 0;
            this.tablesControl.Size = new System.Drawing.Size(573, 27);
            this.tablesControl.TabIndex = 19;
            this.tablesControl.SelectedIndexChanged += new System.EventHandler(this.tablesControl_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 564);
            this.Controls.Add(this.tablesControl);
            this.Controls.Add(this.comboBoxColumnsTypes);
            this.Controls.Add(this.textBoxIntersectionSecondTableName);
            this.Controls.Add(this.textBoxIntersectionFirstTableName);
            this.Controls.Add(this.textBoxAddColumn);
            this.Controls.Add(this.butCartesian);
            this.Controls.Add(this.butDeleteColumn);
            this.Controls.Add(this.butAddColumn);
            this.Controls.Add(this.butDeleteRow);
            this.Controls.Add(this.butAddRow);
            this.Controls.Add(this.butDeleteTable);
            this.Controls.Add(this.textBoxCreateTable);
            this.Controls.Add(this.butCreateTable);
            this.Controls.Add(this.textBoxLoadDatabase);
            this.Controls.Add(this.textBoxCreateDatabase);
            this.Controls.Add(this.butSaveDatabase);
            this.Controls.Add(this.butLoadDatabase);
            this.Controls.Add(this.butCreateDatabase);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "IT Lab Dubinin";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button butCreateDatabase;
        private System.Windows.Forms.Button butLoadDatabase;
        private System.Windows.Forms.Button butSaveDatabase;
        private System.Windows.Forms.TextBox textBoxCreateDatabase;
        private System.Windows.Forms.TextBox textBoxLoadDatabase;
        private System.Windows.Forms.Button butCreateTable;
        private System.Windows.Forms.TextBox textBoxCreateTable;
        private System.Windows.Forms.Button butDeleteTable;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butAddColumn;
        private System.Windows.Forms.Button butDeleteColumn;
        private System.Windows.Forms.Button butCartesian;
        private System.Windows.Forms.TextBox textBoxAddColumn;
        private System.Windows.Forms.TextBox textBoxIntersectionFirstTableName;
        private System.Windows.Forms.TextBox textBoxIntersectionSecondTableName;
        private System.Windows.Forms.ComboBox comboBoxColumnsTypes;
        private System.Windows.Forms.TabControl tablesControl;
    }
}

