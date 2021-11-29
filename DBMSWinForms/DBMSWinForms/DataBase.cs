using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class DataBase
    {
        public string dbName;
        public List<Table> dbTablesList;

        public DataBase(string dbname)
        {
            dbName = dbname;
            dbTablesList = new List<Table>();
        }
    }
}
