﻿namespace DBMSWinForms
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.butOpen = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.butAddColumn = new System.Windows.Forms.Button();
            this.butAddRow = new System.Windows.Forms.Button();
            this.tbCreateDBName = new System.Windows.Forms.TextBox();
            this.butAddTable = new System.Windows.Forms.Button();
            this.tbAddTableName = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.tbAddColumnName = new System.Windows.Forms.TextBox();
            this.ofdChooseFilePath = new System.Windows.Forms.OpenFileDialog();
            this.butDeleteColumn = new System.Windows.Forms.Button();
            this.butDeleteRow = new System.Windows.Forms.Button();
            this.butDeleteTable = new System.Windows.Forms.Button();
            this.sfdSaveDB = new System.Windows.Forms.SaveFileDialog();
            this.butSaveDB = new System.Windows.Forms.Button();
            this.ofdOpenDB = new System.Windows.Forms.OpenFileDialog();
            this.butCartesian = new System.Windows.Forms.Button();
            this.t1Name = new System.Windows.Forms.TextBox();
            this.t2Name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(14, 180);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(617, 28);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(14, 14);
            this.butOpen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(141, 27);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(13, 92);
            this.butCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(141, 27);
            this.butCreate.TabIndex = 2;
            this.butCreate.Text = "New DB";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // butAddColumn
            // 
            this.butAddColumn.Location = new System.Drawing.Point(347, 14);
            this.butAddColumn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butAddColumn.Name = "butAddColumn";
            this.butAddColumn.Size = new System.Drawing.Size(141, 27);
            this.butAddColumn.TabIndex = 3;
            this.butAddColumn.Text = "Add Column";
            this.butAddColumn.UseVisualStyleBackColor = true;
            this.butAddColumn.Click += new System.EventHandler(this.butAddColumn_Click);
            // 
            // butAddRow
            // 
            this.butAddRow.Location = new System.Drawing.Point(496, 14);
            this.butAddRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butAddRow.Name = "butAddRow";
            this.butAddRow.Size = new System.Drawing.Size(141, 27);
            this.butAddRow.TabIndex = 4;
            this.butAddRow.Text = "Add Row";
            this.butAddRow.UseVisualStyleBackColor = true;
            this.butAddRow.Click += new System.EventHandler(this.butAddRow_Click);
            // 
            // tbCreateDBName
            // 
            this.tbCreateDBName.Location = new System.Drawing.Point(13, 125);
            this.tbCreateDBName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbCreateDBName.Name = "tbCreateDBName";
            this.tbCreateDBName.Size = new System.Drawing.Size(140, 23);
            this.tbCreateDBName.TabIndex = 5;
            // 
            // butAddTable
            // 
            this.butAddTable.Location = new System.Drawing.Point(191, 14);
            this.butAddTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butAddTable.Name = "butAddTable";
            this.butAddTable.Size = new System.Drawing.Size(141, 27);
            this.butAddTable.TabIndex = 6;
            this.butAddTable.Text = "Add Table";
            this.butAddTable.UseVisualStyleBackColor = true;
            this.butAddTable.Click += new System.EventHandler(this.butAddTable_Click);
            // 
            // tbAddTableName
            // 
            this.tbAddTableName.Location = new System.Drawing.Point(191, 47);
            this.tbAddTableName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAddTableName.Name = "tbAddTableName";
            this.tbAddTableName.Size = new System.Drawing.Size(140, 23);
            this.tbAddTableName.TabIndex = 7;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 215);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(616, 365);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // cbTypes
            // 
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Items.AddRange(new object[] {
            "Integer",
            "Real",
            "Char",
            "String",
            "Time",
            "TimeInvl"});
            this.cbTypes.Location = new System.Drawing.Point(347, 77);
            this.cbTypes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(140, 23);
            this.cbTypes.TabIndex = 10;
            // 
            // tbAddColumnName
            // 
            this.tbAddColumnName.Location = new System.Drawing.Point(347, 47);
            this.tbAddColumnName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAddColumnName.Name = "tbAddColumnName";
            this.tbAddColumnName.Size = new System.Drawing.Size(140, 23);
            this.tbAddColumnName.TabIndex = 11;
            // 
            // butDeleteColumn
            // 
            this.butDeleteColumn.Location = new System.Drawing.Point(347, 108);
            this.butDeleteColumn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butDeleteColumn.Name = "butDeleteColumn";
            this.butDeleteColumn.Size = new System.Drawing.Size(141, 27);
            this.butDeleteColumn.TabIndex = 14;
            this.butDeleteColumn.Text = "Delete Column";
            this.butDeleteColumn.UseVisualStyleBackColor = true;
            this.butDeleteColumn.Click += new System.EventHandler(this.butDeleteColumn_Click);
            // 
            // butDeleteRow
            // 
            this.butDeleteRow.Location = new System.Drawing.Point(496, 47);
            this.butDeleteRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butDeleteRow.Name = "butDeleteRow";
            this.butDeleteRow.Size = new System.Drawing.Size(141, 27);
            this.butDeleteRow.TabIndex = 15;
            this.butDeleteRow.Text = "Delete Row";
            this.butDeleteRow.UseVisualStyleBackColor = true;
            this.butDeleteRow.Click += new System.EventHandler(this.butDeleteRow_Click);
            // 
            // butDeleteTable
            // 
            this.butDeleteTable.Location = new System.Drawing.Point(191, 77);
            this.butDeleteTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butDeleteTable.Name = "butDeleteTable";
            this.butDeleteTable.Size = new System.Drawing.Size(141, 27);
            this.butDeleteTable.TabIndex = 16;
            this.butDeleteTable.Text = "Delete Table";
            this.butDeleteTable.UseVisualStyleBackColor = true;
            this.butDeleteTable.Click += new System.EventHandler(this.butDeleteTable_Click);
            // 
            // butSaveDB
            // 
            this.butSaveDB.Location = new System.Drawing.Point(14, 47);
            this.butSaveDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butSaveDB.Name = "butSaveDB";
            this.butSaveDB.Size = new System.Drawing.Size(141, 27);
            this.butSaveDB.TabIndex = 17;
            this.butSaveDB.Text = "Save";
            this.butSaveDB.UseVisualStyleBackColor = true;
            this.butSaveDB.Click += new System.EventHandler(this.butSaveDB_Click);
            // 
            // butCartesian
            // 
            this.butCartesian.Location = new System.Drawing.Point(191, 147);
            this.butCartesian.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butCartesian.Name = "butCartesian";
            this.butCartesian.Size = new System.Drawing.Size(141, 27);
            this.butCartesian.TabIndex = 18;
            this.butCartesian.Text = "Cartesian";
            this.butCartesian.UseVisualStyleBackColor = true;
            this.butCartesian.Click += new System.EventHandler(this.butCartesian_Click);
            // 
            // t1Name
            // 
            this.t1Name.Location = new System.Drawing.Point(340, 150);
            this.t1Name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.t1Name.Name = "t1Name";
            this.t1Name.Size = new System.Drawing.Size(98, 23);
            this.t1Name.TabIndex = 19;
            // 
            // t2Name
            // 
            this.t2Name.Location = new System.Drawing.Point(446, 150);
            this.t2Name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.t2Name.Name = "t2Name";
            this.t2Name.Size = new System.Drawing.Size(98, 23);
            this.t2Name.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 593);
            this.Controls.Add(this.t2Name);
            this.Controls.Add(this.t1Name);
            this.Controls.Add(this.butCartesian);
            this.Controls.Add(this.butSaveDB);
            this.Controls.Add(this.butDeleteTable);
            this.Controls.Add(this.butDeleteRow);
            this.Controls.Add(this.butDeleteColumn);
            this.Controls.Add(this.tbAddColumnName);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tbAddTableName);
            this.Controls.Add(this.butAddTable);
            this.Controls.Add(this.tbCreateDBName);
            this.Controls.Add(this.butAddRow);
            this.Controls.Add(this.butAddColumn);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "IT Lab Dubinin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.Button butAddColumn;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.TextBox tbCreateDBName;
        private System.Windows.Forms.Button butAddTable;
        private System.Windows.Forms.TextBox tbAddTableName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.TextBox tbAddColumnName;
        private System.Windows.Forms.OpenFileDialog ofdChooseFilePath;
        private System.Windows.Forms.Button butDeleteColumn;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butDeleteTable;
        private System.Windows.Forms.SaveFileDialog sfdSaveDB;
        private System.Windows.Forms.Button butSaveDB;
        private System.Windows.Forms.OpenFileDialog ofdOpenDB;
        private System.Windows.Forms.Button butCartesian;
        private System.Windows.Forms.TextBox t1Name;
        private System.Windows.Forms.TextBox t2Name;
    }
}

