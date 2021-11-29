using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DBMS.Core
{
    [DataContract]
    public class Row
    {
        [DataMember]
        public List<string> valuesList { get; set; }

        public Row()
        {
            valuesList = new List<string>();
        }

        public override bool Equals(object obj)
        {
            var otherRow = obj as Row;
            if (otherRow == null)
            {
                return false;
            }
            return Enumerable.SequenceEqual(valuesList, otherRow.valuesList);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ (valuesList.Count) + 1;
        }

        public List<string> GetValuesList()
        {
            return valuesList;
        }
    }
}
