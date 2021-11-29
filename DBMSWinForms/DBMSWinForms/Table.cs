using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class Table
    {
        public string Name;
        public List<Column> ColumnsList;
        public List<Row> RowsList;

        public Table(string tname)
        {
            Name = tname;
            ColumnsList = new List<Column>();
            RowsList = new List<Row>();
        }
    }
}
