using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Tables
{
    public class Shifts:DB_Object
    {
        public Shifts(): base(Database_Names.Shifts, Database_Names.Shifts_Columes) { }
        public Shifts(DB_Object obj):base(obj){ Table = Database_Names.Shifts; }
        public Shifts(Row obj):base(obj) { Table = Database_Names.Shifts; }
        public Shifts(string date,string worker) : base(Database_Names.Shifts, Database_Names.Shifts_Columes)
        {
            SetColValue(3, "00:00");
            SetColValue(4, "00:00");
            SetColValue(1, worker);
            SetColValue(2, date);
        }
        public Shifts(List<object> values): base(Database_Names.Shifts, Database_Names.Shifts_Columes) 
        {
            for(int i = 0; i < this.Row.Columes.Count(); i++)
                SetColValue(i, values[i]);
        }
        public Shifts(List<string> values) : base(Database_Names.Shifts, Database_Names.Shifts_Columes) 
        {
            SetColValue(0, GetNewIndex());
            for(int i=1;i<this.Row.Columes.Count();i++)
                SetColValue(i, values[i-1]);
        }
        public bool IsShiftOver()
        {
            if (GetColValue(4).ToString() != "none")
                return false;
            else
                return true;
        }
        public static Shifts GetShift(string date,string worker_id)
        {
            List<Col> values= new List<Col>();
            values.Add(new Col(Database_Names.Shifts_Columes[2], date));
            values.Add(new Col(Database_Names.Shifts_Columes[1], worker_id));
            Shifts shifts = new Shifts();
            List<DB_Object> objects = shifts.Grab(values, Database_Names.Shifts);
            if (objects.Count != 0)
                return new Shifts(objects[0]);
            else
                return null;
        }
        public static List<Shifts> GetShifts(string worker_id)
        {
            Shifts shift=new Shifts();
            List<Shifts> shifts=new List<Shifts>();
            foreach (Row obj in Access.getObjects(SQL_Queries.Select(Database_Names.Shifts,new Condition(Database_Names.Shifts_Columes[1],worker_id)))) 
                shifts.Add(new Shifts(obj));
            return shifts;
        }
        
        public static List<Shifts> GetShifts(string worker_id,int mouth,int year)
        {
            Shifts shift=new Shifts();  
            List<Shifts> shifts = new List<Shifts>();
            DateTime time;
            foreach (DB_Object obj in shift.Grab(Database_Names.Shifts_Columes[1], worker_id, Database_Names.Shifts))
            {
                time = DateTime.Parse(obj.GetColValue(Database_Names.Shifts_Columes[2]).ToString());
                if (time.Month==mouth&&time.Year==year)
                    shifts.Add(new Shifts(obj));
            }
            return shifts;
        }
        public static bool ClockIn(string worker_id,string date,string time)
        {
            Shifts shift =  new Shifts(new List<string>()
            {
                worker_id,date,time,"none"
            });
            return shift.Insert();

        }
        public static List<Shifts> GetUnFinishShifts()
        {
            Shifts shift = new Shifts();
            List<Shifts> shifts = new List<Shifts>();
            foreach (DB_Object obj in shift.Grab(Database_Names.Shifts_Columes[4], "null", Database_Names.Shifts))
                shifts.Add(new Shifts(obj));
            return shifts;
        }
        public static bool IsShiftOver(string worker_id,string date)
        {
            Shifts shift = Shifts.GetShift(date, worker_id);
            return shift.GetColValue(4).ToString() != "none";  
        }
        public static bool ClockOut(string worker_id,string date,string time)
        {
            Shifts shift = Shifts.GetShift(date, worker_id);
            shift.SetColValue(4, time);
            return shift.Update();
        }
        internal DateTime getStartTime()
        {
            try
            {
                return DateTime.Parse(GetColValue(Database_Names.Shifts_Columes[3]).ToString());
            }
            catch
            {
                return new DateTime();
            }
        }
        internal DateTime getEndTime()
        {
            try
            {
                return DateTime.Parse(GetColValue(Database_Names.Shifts_Columes[4]).ToString());
            }
            catch
            {
                return new DateTime();
            }
        }
        internal DateTime GetDate()
        {
            try
            {
                return DateTime.Parse(GetColValue(Database_Names.Shifts_Columes[2]).ToString());
            }
            catch
            {
                return new DateTime();
            }
        }
        public void Set_Date(string date) { SetColValue(2, date); }
        public void Set_Start_Time(string start) { SetColValue(3, start); }
        public void Set_End_Time(string end) { SetColValue(4, end); }
        public void Set_Worker(string worker) { SetColValue(1, worker); }
        internal string getTimeSpan()
        {
            TimeSpan Span;
            if (GetColValue(Database_Names.Shifts_Columes[4]).ToString() == "none")
                return "none";
            else
                Span = getEndTime().Subtract(getStartTime());
            return Span.ToString();
            return $"{(int)Span.TotalMinutes/60}:{(int)Span.TotalMinutes%60}";
                
        }
    }
}
