using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using iText.Commons.Utils;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Workers:DB_Object
    {   //Class represting Worker Table Connected to People Table and Shift Table
        //An worker class is a continuation class of a person class, meaning there cannot be an worker who is not a person
        public static List<Workers> list = Workers.GrabAll();
        public static Workers LogedWorker = new Workers();
        public List<Shifts> all_shifts;//representing all shifts of worker
        public Person Person { get; set; } = new Person();//Representing Worker Personal information
        public Workers():base(Database_Names.Workers,Database_Names.Workers_Columes)
        {
        }
        public Workers (string id): base(Database_Names.Workers,Database_Names.Workers_Columes) {//featching worker information from DB
            Grab(id);
            all_shifts = GrabAllShifts();   
        }
        public Workers (Row r): base(Database_Names.Workers, Database_Names.Workers_Columes)
        {//coping worker infomation 
            Value=r.GetColValue(0);
            SetColValue(0, Value);
            Person.SetColValue(0, Value);
            Person.Value= Value;
            bool people_colume;
            foreach(Col c in r.Columes)
            {
                people_colume = false;
                foreach(string colume in Database_Names.People_Columes)
                {
                    if (colume == c.GetField())
                    {
                        Person.SetColValue(colume, c.GetValue());
                        people_colume = true;
                        break;
                    }
                }
                if (people_colume)
                    continue;
                else
                    SetColValue(c.GetField(), c.GetValue());
            }
            all_shifts = GrabAllShifts();

        }
        public static Workers GetWorker(string id)
        {//return worker infomation
            foreach(Workers worker in list)
                if(worker.Value.ToString() == id) 
                    return worker;
            return null;
        }
        public bool Grab(string id)
        {//feacthing worker infomation from DB
            Person = Person.GetPerson(id);
            return base.Grab(id);
        }
        public static bool Verify_Account(string id,string password)
        {//verify if user had put the right id and password to login
            Workers worker =  Workers.GetWorker(id);
            return worker.GetColValue("password").ToString() == password && worker.GetColValue("id").ToString() == id;
        }
        public static bool Verify_Account_Admin(string id, string password)
        {//verify if user had put the right id and password to login and if its a manager
            Workers worker = GetWorker(id);
            return worker.GetColValue("password").ToString() == password && worker.GetColValue("id").ToString() == id && worker.GetAdmin();
        }
        public static object GetColValue(string id,string field) 
        {//returning infomation abput worker values
            return GetColValue(Database_Names.Workers, Database_Names.Workers_Columes, id, field);
        }
        public bool ClockIn(string date,string time)
        {//worker clock in to work
           return Shifts.ClockIn(Field, date, time);
        }
        public void ClockOut(string date,string time)
        {//worker clock out from work
            Shifts shift = Shifts.GetShift(date, time);
            shift.SetColValue(4, time);
            shift.Update();
        }
        

        public bool Update()
        {//update worker information to DB
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
                return Insert();
        }
        internal bool Insert()
        {//insert new worker infomation to DB
            Value = GetColValue(0);
            return Access.Execute(SQL_Queries.Insert(Table, Row.Columes));
        }
        internal bool GetAdmin()
        {//check if worker is manager
            return bool.Parse(GetColValue(2).ToString());
        }
        public static List<Workers> GetWorkers()
        {//return all workers infomation from DB
            List<Workers> list = new List<Workers>();
            foreach (Row r in Access.getObjects(SQL_Queries.LeftOuterJoin(Database_Names.Workers, Database_Names.People, Database_Names.People_Columes[0])))
            {
                list.Add(new Workers(r));
            }
            return list;  
        }
        public static List<Person> GetAllWorkers()
        {//return all workers infomation from DB
            Person person = new Person();
            Workers worker = new Workers();
            List<Person> list = new List<Person>();
            foreach (DB_Object p in person.Grab_Join(worker))
                list.Add(new Person(p));
            return list;
        }
        public static bool IsExist(string id)
        {//checks if values are not null in worker object
            Workers workers = new Workers(id);
            foreach(Col c in  workers.GetCols())
                if(c.GetValue() != null) 
                    return true;
            return false;
        }
        public List<Calender_Table> GetAppoitments(string date)
        {//return worker appoitment in a date
            return Calender_Table.GetAppoitments(date);
        }
        public string GetFullName() { return Person.GetFullName(); }
        public static List<Workers> GrabAll()
        {//return all workers from DB
            List<Workers> list = new List<Workers>();
            List<Row> all = Access.getObjects(SQL_Queries.Select(Database_Names.Workers));
            foreach (Row obj in all)
                list.Add(new Workers(obj.GetColValue(0).ToString()));
            return list;
        }
        public List<Shifts> GrabAllShifts()
        {//return all shifts of worker
            return Shifts.GetShifts(Value.ToString());
        }

        public List<Shifts> GetShifts(DateTime SelectedDate)
        {//return a worker shift in a selected Date
            List<Shifts> filter = new List<Shifts>();
            foreach(Shifts shift in all_shifts)
            {
                if(shift.GetDate().Month == SelectedDate.Month && shift.GetDate().Year == SelectedDate.Year)
                    filter.Add(shift);
            }

            return filter.OrderBy(shifts => shifts.GetDate()).ToList<Shifts>();
        }
        public bool UpdatePassword()
        {//update worker password in DB
            string query = SQL_Queries.Update(Database_Names.Workers, new List<Col>()
            {
                new Col(Database_Names.Workers_Columes[1],GetColValue(Database_Names.Workers_Columes[1]))
            }, new Condition(Field, Value));
            return Access.Execute(query);
        }
        internal void Reload()
        {//feacthing all worker infomation from DB
            all_shifts = GrabAllShifts();
            base.Reload();
        }
        public static void ReloadList()
        {//reload all workers inforamtion from DB
            list = GrabAll();
        }
    }
}
