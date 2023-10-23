using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Person:DB_Object
    {
        public Person() : base(Database_Names.People, Database_Names.People_Columes) { }
        public Person(object id) : base(Database_Names.People, Database_Names.People_Columes) { Grab(id); }
        public static object GetColValue(string id, string field)
        {
            return GetColValue(Database_Names.People, Database_Names.People_Columes, id, field);
        }
        public string GetFullName()
        {
            return GetColValue("firstname") + " " + GetColValue("lastname");
        }
    }
}
