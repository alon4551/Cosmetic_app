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
        public Person Person { get; set; } = new Person();
        public Workers():base(Database_Names.Workers,Database_Names.Workers_Columes)
        {
            SetColValue("admin", false);
        }
        public Workers (string id): base(Database_Names.Workers,Database_Names.Workers_Columes) {
            Grab(id);
        }
        public void Grab(string id)
        {
            base.Grab(id);
            Person.Grab(id);
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
        public void Clock(string date,string time,bool state)
        {
            Shifts shift = new Shifts();
            shift.SetColValue("id", shift.GetNewIndex());
            shift.SetColValue("worker", GetColValue("id"));
            shift.SetColValue("clock_in", state);
            shift.SetColValue("time", time);
            shift.SetColValue("day", date);
            shift.Insert();
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
            string query = SQL_Queries.Update(Table, list, new Condition(Id, Value));
            if (IsExist(Value))
                return Access.Execute(query);
            else
                return base.Insert();
        }
        internal bool GetAdmin()
        {
            return bool.Parse(GetColValue(2).ToString());
        }
    }
}
