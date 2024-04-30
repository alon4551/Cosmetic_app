using Cosmetic_App.Utiltes;
using iText.Commons.Utils;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Person: DB_Object
    {
        public static List<Person> All = GetAllPeople(), Clients = GetClients();
        public Person() : base(Database_Names.People, Database_Names.People_Columes) { }
        public Person(string id) : base(Database_Names.People, Database_Names.People_Columes) { Grab(id); }
        public Person(Row row) : base(row) { }
        public Person(DB_Object dB_) : base(dB_) { }
        public static Person GetPerson(string id)
        {
            foreach (Person person in All)
                if(person.Value.ToString() == id)   
                    return person;
            return null;
        }
        public static string GetName(string id)
        {
            foreach (Person person in All)
                if (person.GetColValue(0).ToString() == id)
                    return person.GetFullName();
            return "";
        }
        public static object GetColValue(string id, string field)
        {
            return GetColValue(Database_Names.People, Database_Names.People_Columes, id, field);
        }
        public string GetFullName()
        {
            return GetColValue("firstname") + " " + GetColValue("lastname");
        }
        public static List<Person> GetClients()
        {
            List<Person> list = new List<Person>();
            List<Row> rows = Access.getObjects(SQL_Queries.Seperate(Database_Names.People, Database_Names.Workers, Database_Names.Workers_Columes[0]));
            foreach (Row row in rows)
                list.Add(new Person(row));
            return list;
        }
        public static List<Person> GetAllClients()
        {
            List<Person> allClients = new List<Person>();

            bool found;
            foreach (Person person in All) {
                found = false;
                foreach (Workers worker in Workers.list)
                {
                    if(worker.Value.ToString()==person.Value.ToString())
                    { found = true; break; }
                }
                if (found)
                    continue;
                allClients.Add(person);
            }
            return allClients;
        }
        public static  List<Person>GetAllPeople()
        {
            Person person = new Person() ;
            List<Person> list = new List<Person>();
            foreach (DB_Object p in person.GrabAll())
                list.Add(new Person(p));
            return list;
        }
        public static  List<Person> GetAllPeopleAndOrderByName()
        {
            Person person = new Person();
            List<Person> list = new List<Person>();
            foreach (Row p in Access.getObjects(SQL_Queries.SelectAndOrderBy(Database_Names.People, Database_Names.People_Columes[2])))
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
            foreach(Person person in All)
                if(person.Value.ToString()==text)
                    return person;
            return null;
        }
        public bool Save()
        {
            if (IsExist(Row.GetColValue(0)))
                return  Update();
            else
            {
                return Access.Execute(SQL_Queries.Insert(Database_Names.People, Row.GetColumes()));
            }
        }
        internal static async void ReloadList()
        {
            All =  GetAllPeople();
        }
    }
}
