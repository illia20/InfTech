using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMSClient.ServiceReference1;


namespace DBMSClient
{
    public partial class Form1 : Form
    {
        private DBMSServiceClient client = new DBMSServiceClient();
        string currentFilePath = "";
        string cellOldValue = "";
        string cellNewValue = "";

        public Form1()
        {     
            InitializeComponent();
            comboBoxColumnsTypes.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (client.AddColumn(tablesControl.SelectedIndex, textBoxAddColumn.Text, comboBoxColumnsTypes.Text))
            {
                int tableIndex = tablesControl.SelectedIndex;
                if (tableIndex != -1)
                {
                    ShowTable(client.GetTable(tableIndex));
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void butCreateDatabase_Click(object sender, EventArgs e)
        {
            if (currentFilePath != String.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Save changings?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    client.SaveCurrentDatabase();
                }
            }
            if (client.CreateDatabase(textBoxCreateDatabase.Text))
            {
                currentFilePath = "";
                tablesControl.TabPages.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
        }

        private void butLoadDatabase_Click(object sender, EventArgs e)
        {
            if (currentFilePath != String.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Save changings?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    client.SaveCurrentDatabase();
                }
            }
            var databaseName = textBoxLoadDatabase.Text;
            if (!client.LoadDatabase(databaseName))
            {
                return;
            }
            currentFilePath = databaseName;
            tablesControl.TabPages.Clear();
            List<string> tablesNames = new List<string>(client.GetTablesNameList());
            foreach (string tableName in tablesNames)
            {
                tablesControl.TabPages.Add(tableName);
            }
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex != -1)
            {
                ShowTable(client.GetTable(selectedTableIndex));
            }
        }

        private void ShowTable(Table table)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                foreach (Column column in table.columnsList)
                {
                    DataGridViewColumn dataGridColumn;
                        dataGridColumn = new DataGridViewTextBoxColumn();
                    dataGridColumn.Name = column.name;
                    dataGridColumn.HeaderText = column.name;
                    dataGridView.Columns.Add(dataGridColumn);
                }

                foreach (Row row in table.rowsList)
                {
                    DataGridViewRow dataGridRow = new DataGridViewRow();
                    for (int i = 0; i < row.valuesList.Length; ++i)
                    {
                        DataGridViewCell cell;
                        var stringCellValue = row.valuesList[i];
                            cell = new DataGridViewTextBoxCell();
                            cell.Value = stringCellValue;
                        dataGridRow.Cells.Add(cell);
                    }
                    try
                    {
                        dataGridView.Rows.Add(dataGridRow);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void butSaveDatabase_Click(object sender, EventArgs e)
        {
            client.SaveCurrentDatabase();
        }

        private void butCreateTable_Click(object sender, EventArgs e)
        {
            if (client.AddEmptyTableWithName(textBoxCreateTable.Text))
            {
                tablesControl.TabPages.Add(textBoxCreateTable.Text);
            }
        }

        private void butDeleteTable_Click(object sender, EventArgs e)
        {
            if (tablesControl.TabCount == 0)
            {
                return;
            }
            try
            {
                client.DeleteTable(tablesControl.SelectedIndex);
                tablesControl.TabPages.RemoveAt(tablesControl.SelectedIndex);
            }
            catch { }
            if (tablesControl.TabCount == 0)
            {
                return;
            }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
                ShowTable(client.GetTable(tableIndex));
            }
        }

        private void butAddRow_Click(object sender, EventArgs e)
        {
            if (client.AddRow(tablesControl.SelectedIndex))
            {
                int tableIndex = tablesControl.SelectedIndex;
                if (tableIndex != -1)
                {
                    ShowTable(client.GetTable(tableIndex));
                }
            }
        }

        private void butDeleteRow_Click(object sender, EventArgs e)
        {

            if (dataGridView.Rows.Count == 0)
            {
                return;
            }
            try
            {
                client.DeleteRow(tablesControl.SelectedIndex, dataGridView.CurrentCell.RowIndex);
            }
            catch { }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
                ShowTable(client.GetTable(tableIndex));
            }
        }

        private void butDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count == 0) return;
            try
            {
                client.DeleteColumn(tablesControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex);
            }
            catch { }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
                ShowTable(client.GetTable(tableIndex));
            }
        }

        private void butCartesian_Click(object sender, EventArgs e)
        {
            int firstTableIndex = -1, secondTableIndex = -1;
            string firstTableName = textBoxIntersectionFirstTableName.Text;
            string secondTableName = textBoxIntersectionSecondTableName.Text;

            foreach (TabPage page in tablesControl.TabPages)
            {
                if (page.Text == firstTableName)
                {
                    firstTableIndex = tablesControl.TabPages.IndexOf(page);
                }
                if (page.Text == secondTableName)
                {
                    secondTableIndex = tablesControl.TabPages.IndexOf(page);
                }
            }
            if (firstTableIndex != -1 && secondTableIndex != -1)
            {
                Table first = client.GetTable(firstTableIndex);
                Table second = client.GetTable(secondTableIndex);
                var resultTable = client.CartesianProduct(first, second);
                if (resultTable == null)
                {
                    return;
                }
                if (client.AddTable(resultTable))
                {
                    tablesControl.TabPages.Add(resultTable.name);
                    tablesControl.SelectedTab = tablesControl.TabPages[tablesControl.TabPages.Count - 1];
                }
                ShowTable(resultTable);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            return;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex == -1)
            {
                return;
            }
            var table = client.GetTable(selectedTableIndex);
            if (true)
            {
                var currentCellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                cellOldValue = currentCellValue == null ? String.Empty : currentCellValue.ToString();
                return;
            }
            var cell = new DataGridViewTextBoxCell();
            cellOldValue = table.rowsList[e.RowIndex].valuesList[e.ColumnIndex];
            cell.Value = cellOldValue;
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue == null)
            {
                return;
            }
            cellNewValue = cellValue.ToString();
            if (!client.ChangeValue(cellNewValue, tablesControl.SelectedIndex, e.ColumnIndex, e.RowIndex))
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellOldValue;
                return;
            }
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex == -1)
            {
                return;
            }
            var table = client.GetTable(selectedTableIndex);
            ShowTable(client.GetTable(selectedTableIndex));
        }

        private void tablesControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tablesIndex = tablesControl.SelectedIndex;
            if (tablesIndex != -1)
            {
                ShowTable(client.GetTable(tablesIndex));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
