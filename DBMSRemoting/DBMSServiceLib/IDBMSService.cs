using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections.Generic;
using DBMS.Core;

namespace DBMSServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDBMSService
    {
        [OperationContract]
        bool CreateDatabase(string databaseName);

        [OperationContract]
        bool AddEmptyTableWithName(string newTableName);

       [OperationContract]
       bool AddTable(Table newTable);

        [OperationContract]
        Table GetTable(int index);

        [OperationContract]
        bool AddColumn(int tableIndex, string columnName, string customTypeName);

        [OperationContract]
        bool AddRow(int tableIndex);

        [OperationContract]
        bool ChangeValue(string newValue, int tableIndex, int columnIndex, int rowIndex);

        [OperationContract]
        bool DeleteRow(int tableIndex, int rowIndex);

        [OperationContract]
        bool DeleteColumn(int tableIndex, int columnIndex);

        [OperationContract]
        bool DeleteTable(int tableIndex);

        [OperationContract]
        bool SaveCurrentDatabase();

        [OperationContract]
        bool LoadDatabase(string databaseName);

        [OperationContract]
        List<string> GetTablesNameList();

        [OperationContract]
        Table CartesianProduct(Table firstTable, Table secondTable);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DBMSServiceLib.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
