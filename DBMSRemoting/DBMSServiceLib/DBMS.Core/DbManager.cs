using System.Collections.Generic;
using System.Linq;

namespace DBMS.Core
{
    public class DbManager
    {
        private Database currentDb;
        private FileLoader fileLoader;
        private readonly string path = "D:/Databases/";
        public DbManager()
        {
            fileLoader = new FileLoader();
            fileLoader.CreateDirectory(path);
        }

        public bool CreateDatabase(string databaseName)
        {
            if (databaseName.Trim().Equals(""))
            {
                return false;
            }
            currentDb = new Database(databaseName);
            return true;
        }

        public bool AddTable(string newTableName)
        {
            if (currentDb == null)
            {
                return false;
            }
            return currentDb.AddTable(newTableName);
        }

        public bool AddTable(Table newTable)
        {
            if (currentDb == null)
            {
                return false;
            }
            return currentDb.AddTable(newTable);
        }


        public Table GetTable(int index)
        {
           return currentDb.GetTable(index);
        }

        public bool AddColumn(int tableIndex, string columnName, string customTypeName)
        {
            if (currentDb == null)
            {
                return false;
            }
            return currentDb.AddColumn(tableIndex, columnName, customTypeName);
        }

        public bool AddRow(int tableIndex)
        {
            if (currentDb == null)
            {
                return false;
            }
            return currentDb.AddRowToTable(tableIndex);
        }

        public bool ChangeValue(string newValue, int tableIndex, int columnIndex, int rowIndex)
        {
            return currentDb.ChangeValue(newValue, tableIndex, columnIndex, rowIndex);
        }

        public bool DeleteRow(int tableIndex, int rowIndex)
        {
            return currentDb.DeleteRow(tableIndex, rowIndex);
        }

        public bool DeleteColumn(int tableIndex, int columnIndex)
        {
            return currentDb.DeleteColumn(tableIndex, columnIndex);
        }

        public bool DeleteTable(int tableIndex)
        {
           return currentDb.DeleteTable(tableIndex);
        }

        public bool SaveCurrentDatabase()
        {
            return fileLoader.SaveDatabaseOnDrive(path, currentDb);
        }

        public bool LoadDatabase(string databaseName)
        {
            currentDb = fileLoader.LoadDatabaseFromDrive(path, databaseName);
            return currentDb != null;
        }

        public List<string> GetTablesNameList()
        {
            return currentDb.GetTablesNamesList();
        }

        public Table CartesianProduct(Table a, Table b)
        {
            Table resTable = new Table("Cartesian");

            List<Column> columns = new List<Column>(a.columnsList);
            columns.AddRange(b.columnsList);

            resTable.columnsList.AddRange(columns);

            for (int i = 0; i < a.rowsList.Count; i++)
            {
                Row row = new Row();
                Row row1 = a.rowsList[i];
                row.valuesList.AddRange(row1.valuesList);
                for (int j = 0; j < b.rowsList.Count; ++j)
                {
                    row = new Row();
                    row.valuesList.AddRange(row1.valuesList);
                    Row row2 = b.rowsList[j];
                    row.valuesList.AddRange(row2.valuesList);
                    resTable.rowsList.Add(row);
                }
            }

            return resTable;
        }
    }
}
