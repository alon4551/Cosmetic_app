using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Access_Helper
{
    internal class SQL_TableName
    {
        public string Table { get; set; }
        public string Name{get;set;}
        public SQL_TableName(string table,string name) 
        {
            Table= table;
            Name= name;
        }
    }
}
