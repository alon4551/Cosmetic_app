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
        public Person(string id) : base(Database_Names.People, Database_Names.People_Columes) { Grab(id); }
        public Person(Row row) : base(row) { }
        public Person(DB_Object dB_) : base(dB_) { }
        public static object GetColValue(string id, string field)
        {
            return GetColValue(Database_Names.People, Database_Names.People_Columes, id, field);
        }
        public string GetFullName()
        {
            return GetColValue("firstname") + " " + GetColValue("lastname");
        }
        public static List<Person> GetAllClients()
        {
            List<Person> clients = new List<Person>();
            foreach (Row row in Access.getObjects(SQL_Queries.Seperate(Database_Names.People, Database_Names.Workers, Database_Names.People_Columes[0])))
                clients.Add(new Person(row));
            return clients;
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
            if(Value.ToString()=="0")
                return false;
            bool result = Access.Execute(SQL_Queries.Delete(Database_Names.Workers, new Condition(Field, Value)));
            return result & base.Delete();
        }

        internal Person Search(string text)
        {
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.People, new Condition(Database_Names.People_Columes[0], text)));
            if (rows.Count == 0) return null;
            rows[0].Table = Database_Names.People;
            return new Person(rows[0]);
        }
    }
}
