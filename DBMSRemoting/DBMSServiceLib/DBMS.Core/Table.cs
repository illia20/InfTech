using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DBMS.Core
{
    [DataContract]
    public class Table
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public List<Column> columnsList { get; set; }
        
        [DataMember]
        public List<Row> rowsList { get; set; }

        public override bool Equals(object obj)
        {
            var otherTable = obj as Table;
            if (otherTable == null)
            {
                return false;
            }
            return Enumerable.SequenceEqual(columnsList, otherTable.columnsList) 
                    && Enumerable.SequenceEqual(rowsList, otherTable.rowsList)
                    && name == otherTable.name;
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ (columnsList.Count + rowsList.Count);
        }

        public Table()
        {
            name = "";
            columnsList = new List<Column>();
            rowsList = new List<Row>();
        }

        public Table(string _name)
        {
            name = _name;
            columnsList = new List<Column>();
            rowsList = new List<Row>();
        }

        public Table(string _name, 
                        List<Column> _columnsList,
                        List<Row> _rowsList)
        {
            name = _name;
            columnsList = _columnsList;
            rowsList = _rowsList;
        }

        public bool ChangeValue(string newValue, int columnIndex, int rowIndex)
        {
            if (!columnsList[columnIndex].EvaluateType(newValue))
            {
                return false;
            }
            rowsList[rowIndex].GetValuesList()[columnIndex] = newValue;
            return true;
        }

        public bool AddColumn(string columnName, string customTypeName)
        {
            foreach (Column column in columnsList)
            {
                if (column.GetName() == columnName)
                {
                    return false;
                }
            }
            columnsList.Add(new Column(columnName, customTypeName));
            foreach (Row row in rowsList)
            {
                row.GetValuesList().Add("");
            }
            return true;
        }

        public bool AddRow()
        {
            if (columnsList.Count <= 0)
            {
                return false;
            }

            if (rowsList.Count < 0)
            {
                return false;
            }

            rowsList.Add(new Row());
            var columnsCount = columnsList.Count;
            for (int columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
            {
                rowsList[rowsList.Count - 1].GetValuesList().Add("");
            }
            return true;
        }

        public bool DeleteRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= rowsList.Count)
            {
                return false;
            }
            rowsList.RemoveAt(rowIndex);
            return true;
        }

        public bool DeleteColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= columnsList.Count)
            {
                return false;
            }
            columnsList.RemoveAt(columnIndex);
            foreach (Row row in rowsList)
            {
                row.GetValuesList().RemoveAt(columnIndex);
            }
            return false;
        }

        public List<Column> Columns()
        {
            return columnsList;
        }

        public List<Row> Rows()
        {
            return rowsList;
        }

        public string GetName()
        {
            return name;
        }
    }
}
