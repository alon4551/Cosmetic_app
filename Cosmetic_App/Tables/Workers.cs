using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App
{
    public class Workers:DB_Object
    {
        public static Workers LogedWorker = new Workers();
        public Person Person { get; set; } = new Person();
        public Workers():base(Database_Names.Workers,Database_Names.Workers_Columes)
        {
        }
        public Workers (string id): base(Database_Names.Workers,Database_Names.Workers_Columes) {
            Grab(id);
        }
        public bool Grab(string id)
        {
            return base.Grab(id) & Person.Grab(id);
        }
        public static bool Verify_Account(string id,string password)
        {
            Workers worker =  new Workers(id);
            return worker.GetColValue("password").ToString() == password && worker.GetColValue("id").ToString() == id;
        }
        public static bool Verify_Account_Admin(string id, string password)
        {
            Workers worker = new Workers(id);
            return worker.GetColValue("password").ToString() == password && worker.GetColValue("id").ToString() == id && worker.GetAdmin();
        }
        public static object GetColValue(string id,string field) 
        {
            return GetColValue(Database_Names.Workers, Database_Names.Workers_Columes, id, field);
        }
        public bool ClockIn(string date,string time)
        {
           return Shifts.ClockIn(Field, date, time);
        }
        public void ClockOut(string date,string time)
        {
            Shifts shift = Shifts.GetShift(date, time);
            shift.SetColValue(4, time);
            shift.Update();
        }
        

        internal bool Update()
        {
            List<Col> list = new List<Col>();
            foreach(Col col in Row.Columes)
            {
                if(col.GetField()!="id")
                    list.Add(col);
            }
            if (Value == null) Value = Row.Columes[0].GetValue();
            string query = SQL_Queries.Update(Table, list, new Condition(Field, Value));
            if (IsExist(Value))
                return Access.Execute(query);
            else
                return base.Insert();
        }
        
        internal bool GetAdmin()
        {
            return bool.Parse(GetColValue(2).ToString());
        }
        public static List<Person> GetAllWorkers()
        {
            Person person = new Person();
            Workers worker = new Workers();
            List<Person> list = new List<Person>();
            foreach (DB_Object p in person.Grab_Join(worker))
                list.Add(new Person(p));
            return list;
        }
        public static bool IsExist(string id)
        {
            Workers workers = new Workers(id);
            foreach(Col c in  workers.GetCols())
                if(c.GetValue() != null) 
                    return true;
            return false;
        }
        public List<Calender_Table> GetAppoitments(string date)
        {
            return Calender_Table.GetAppoitments(date);
        }
        public string GetFullName() { return Person.GetFullName(); }
        public static List<Workers> GrabAll()
        {
            List<Workers> list = new List<Workers>();
            List<Row> all = Access.getObjects(SQL_Queries.Select(Database_Names.Workers));
            foreach (Row obj in all)
                list.Add(new Workers(obj.GetColValue(0).ToString()));
            return list;
        }
    }
}
