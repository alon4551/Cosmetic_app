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
        public Person(DB_Object dB_) : base(dB_) { }
        public static object GetColValue(string id, string field)
        {
            return GetColValue(Database_Names.People, Database_Names.People_Columes, id, field);
        }
        public string GetFullName()
        {
            return GetColValue("firstname") + " " + GetColValue("lastname");
        }
        public static List<Person> GetAllPeople()
        {
            Person person = new Person() ;
            List<Person> list = new List<Person>();
            foreach (DB_Object p in person.GrabAll())
                list.Add(new Person(p));
            return list;
        }
        public bool Delete()
        {
            bool result = Access.Execute(SQL_Queries.Delete(Database_Names.Workers, new Condition(Id, Value)));
            return result & base.Delete();
        }
    }
}
