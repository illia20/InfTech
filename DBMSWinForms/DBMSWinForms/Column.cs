using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class Column
    {
        public string Name;
        public MyType Type;
        public string typeName;

        public Column(string cname, string ctype)
        {
            Name = cname;
            typeName = ctype;

            switch (ctype)
            {
                case "Integer":
                    Type = new MyTypeInteger();
                    break;
                case "Real":
                    Type = new MyTypesReal();
                    break;
                case "Char":
                    Type = new MyTypeChar();
                    break;
                case "String":
                    Type = new MyTypeString();
                    break;
                case "Time":
                    Type = new MyTypeTime();
                    break;
                case "TimeInvl":
                    Type = new MyTypeTimeInvl();
                    break;
                default:
                    Type = new MyTypeString();
                    break;
            }
        }
    }
}
