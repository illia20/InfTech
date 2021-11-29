using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMSWinForms
{
    public class MyTypeString : MyType
    {
        public override bool Validation(string value)
        {
            return true;
        }
    }
}
