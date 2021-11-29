using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class DbManager
    {
        public DataBase db;

        public bool CreateDB(string dbname)
        {
            if (dbname.Trim().Equals("")) return false;

            db = new DataBase(dbname);
            return true;
        }

        public bool AddTable(string tname)
        {
            if (tname.Trim().Equals("")) return false;
            if (db == null) return false;

            db.dbTablesList.Add(new Table(tname));
            return true;
        }

        public Table GetTable(int index)
        {
            if (index == -1) index = 0;
            return db.dbTablesList[index];
        }

        public bool AddColumn(int tIndex, string cname, string ctype)
        {
            if (db == null) return false;
            if (db.dbTablesList.Count <= 0) return false;
            if (cname.Trim().Equals("")) return false;

            db.dbTablesList[tIndex].ColumnsList.Add(new Column(cname, ctype));
            for(int i = 0; i < db.dbTablesList[tIndex].RowsList.Count; ++i)
            {
                db.dbTablesList[tIndex].RowsList[i].ValuesList.Add("");
            }
            return true;
        }

        public bool AddRow(int tIndex)
        {
            if (db == null) return false;
            if (db.dbTablesList.Count <= 0) return false;
            if (db.dbTablesList[tIndex].ColumnsList.Count <= 0) return false;

            db.dbTablesList[tIndex].RowsList.Add(new Row());
            for (int i = 0; i < db.dbTablesList[tIndex].ColumnsList.Count; ++i)
            {
                db.dbTablesList[tIndex].RowsList.Last().ValuesList.Add("");
            }
            return true;
        }

        public bool ChangeValue(string newValue, int tind, int cind, int rind)
        {
            if (db.dbTablesList[tind].ColumnsList[cind].Type.Validation(newValue))
            {
                db.dbTablesList[tind].RowsList[rind].ValuesList[cind] = newValue;
                return true;
            }

            return false;
        }

        public void DeleteRow(int tind, int rind)
        {
            db.dbTablesList[tind].RowsList.RemoveAt(rind);
        }

        public void DeleteColumn(int tind, int cind)
        {
            db.dbTablesList[tind].ColumnsList.RemoveAt(cind);
            for (int i = 0; i < db.dbTablesList[tind].RowsList.Count; ++i)
            {
                db.dbTablesList[tind].RowsList[i].ValuesList.RemoveAt(cind);
            }
        }

        public void DeleteTable(int tind)
        {
            db.dbTablesList.RemoveAt(tind);
        }

        char sep = '$';
        char space = '#';
        public void SaveDB(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine(db.dbName);
            foreach(Table t in db.dbTablesList)
            {
                sw.WriteLine(sep);
                sw.WriteLine(t.Name);
                foreach(Column c in t.ColumnsList)
                {
                    sw.Write(c.Name + space);
                }
                sw.WriteLine();
                foreach (Column c in t.ColumnsList)
                {
                    sw.Write(c.typeName + space);
                }
                sw.WriteLine();
                foreach (Row r in t.RowsList)
                {
                    foreach (string s in r.ValuesList)
                    {
                        sw.Write(s + space);
                    }
                    sw.WriteLine();
                }
            }

            sw.Close();
        }

        public bool OpenDB(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string file = sr.ReadToEnd();
                string[] parts = file.Split(sep);

                db = new DataBase(parts[0]);

                for (int i = 1; i < parts.Length; ++i)
                {
                    parts[i] = parts[i].Replace("\r\n", "\r");
                    List<string> buf = parts[i].Split('\r').ToList();
                    buf.RemoveAt(0);
                    buf.RemoveAt(buf.Count - 1);

                    if (buf.Count > 0)
                    {
                        db.dbTablesList.Add(new Table(buf[0]));
                    }
                    if (buf.Count > 2)
                    {
                        string[] cname = buf[1].Split(space);
                        string[] ctype = buf[2].Split(space);
                        int length = cname.Length - 1;
                        for (int j = 0; j < length; ++j)
                        {
                            db.dbTablesList[i - 1].ColumnsList.Add(new Column(cname[j], ctype[j]));
                        }

                        for (int j = 3; j < buf.Count; ++j)
                        {
                            db.dbTablesList[i - 1].RowsList.Add(new Row());
                            List<string> values = buf[j].Split(space).ToList();
                            values.RemoveAt(values.Count - 1);
                            db.dbTablesList[i - 1].RowsList.Last().ValuesList.AddRange(values);
                        }
                    }
                }

                sr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> GetTableNameList()
        {
            List<string> res = new List<string>();
            foreach (Table t in db.dbTablesList)
                res.Add(t.Name);
            return res;
        }

        public Table CartesianProduct(Table a, Table b)
        {
            Table resTable = db.dbTablesList.FirstOrDefault(t => t.Name.Equals("Cartesian"));

            List<Column> columns = new List<Column>(a.ColumnsList);
            columns.AddRange(b.ColumnsList);

            resTable.ColumnsList.AddRange(columns);

            for(int i = 0; i < a.RowsList.Count; i++)
            {
                Row row = new Row();
                Row row1 = a.RowsList[i];
                row.ValuesList.AddRange(row1.ValuesList);
                for (int j = 0; j < b.RowsList.Count; ++j)
                {
                    row = new Row();
                    row.ValuesList.AddRange(row1.ValuesList);
                    Row row2 = b.RowsList[j];
                    row.ValuesList.AddRange(row2.ValuesList);
                    resTable.RowsList.Add(row);
                }
            }

            return resTable;
        }

    }
}
