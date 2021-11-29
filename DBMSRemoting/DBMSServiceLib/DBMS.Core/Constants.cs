using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DBMS.Core
{
    [DataContract]
    public class Constants
    {
        [DataMember]
        public readonly string integerTypeName = "Integer";
        
        [DataMember]
        public static readonly string stringTypeName = "String";
        
        [DataMember]
        public static readonly string charTypeName = "Char";
        
        [DataMember]
        public static readonly string realTypeName = "Real";
        
        [DataMember]
        public static readonly string realIntervalTypeName = "TimeInvl";
        
        [DataMember]
        public static readonly string timeTypeName = "Time";
    }
}
