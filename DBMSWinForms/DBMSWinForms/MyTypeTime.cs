using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class MyTypeTime : MyType
    {
        public override bool Validation(string value)
        {
            try
            {
                if (value.Length > 5 || value.Length < 4) return false;
                if (value[value.Length - 3] != ':') return false;
                string hh = value.Length == 4 ? value.Substring(0, 1) : value.Substring(0, 2);
                string mm = value.Substring(value.IndexOf(':') + 1);
                int h, m;
                if(!int.TryParse(hh, out h) || !int.TryParse(mm, out m)) return false;
                if(h > 23 || m > 59) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
