using System.Collections.Generic;
using System.ServiceModel;
using DBMS.Core;

namespace DBMSServiceLib
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class DBMSService : IDBMSService
    {
        private readonly DbManager dbManager;

        public DBMSService()
        {
            dbManager = new DbManager();
        }
        public bool CreateDatabase(string databaseName)
        {
            return dbManager.CreateDatabase(databaseName);
        }

        public bool AddEmptyTableWithName(string newTableName)
        {
            return dbManager.AddTable(newTableName);
        }

        public bool AddTable(Table newTable)
        {
            return dbManager.AddTable(newTable);
        }

        public Table GetTable(int index)
        {
           return dbManager.GetTable(index);
        }

        public bool AddColumn(int tableIndex, string columnName, string customTypeName)
        {
            return dbManager.AddColumn(tableIndex, columnName, customTypeName);
        }

        public bool AddRow(int tableIndex)
        {
            return dbManager.AddRow(tableIndex);
        }

        public bool ChangeValue(string newValue, int tableIndex, int columnIndex, int rowIndex)
        {
            return dbManager.ChangeValue(newValue, tableIndex, columnIndex, rowIndex);
        }

        public bool DeleteRow(int tableIndex, int rowIndex)
        {
            return dbManager.DeleteRow(tableIndex, rowIndex);
        }

        public bool DeleteColumn(int tableIndex, int columnIndex)
        {
            return dbManager.DeleteColumn(tableIndex, columnIndex);
        }

        public bool DeleteTable(int tableIndex)
        {
            return dbManager.DeleteTable(tableIndex);
        }

        public bool SaveCurrentDatabase()
        {
            return dbManager.SaveCurrentDatabase();
        }

        public bool LoadDatabase(string databaseName)
        {
            return dbManager.LoadDatabase(databaseName);
        }

        public List<string> GetTablesNameList()
        {
            return dbManager.GetTablesNameList();
        }

        public Table CartesianProduct(Table firstTable, Table secondTable)
        {
            return dbManager.CartesianProduct(firstTable, secondTable);
        }
    }
}
