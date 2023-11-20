using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App
{
    public class Calender_Table:DB_Object
    {
        Cart Item {  get; set; }
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        public Calender_Table():base(Database_Names.Calendrer,Database_Names.Calender_Columes) { }
        public Calender_Table(DB_Object obj):base(obj) 
        {
            Reload();
        }
        public Calender_Table(int id) : base(Database_Names.Calendrer, Database_Names.Calender_Columes)
        {
            Value = id;
            Reload();
        }
        public void Reload()
        {
            Grab(Value);
            Item.Grab(GetColValue("treatment_id"));
            Client.Grab(GetColValue("client_id"));
            Worker.Grab(GetColValue("worker_id").ToString());
        }
        public static List<Row> GetApoitmentsInfomation(string date)
        {
            List<Row> rows = new List<Row>();
            Person client;
            Workers worker;
            Treatments treatment;
            Cart product;
            Row r;
            Calender_Table table = new Calender_Table();
            List<DB_Object> list = table.Grab(Database_Names.Calender_Columes[5],date,Database_Names.Calendrer);
            foreach (DB_Object obj in list)
            {
                r = new Row(obj.Row.Columes);
                worker = new Workers(obj.GetColValue(Database_Names.Calender_Columes[2]).ToString());
                client = new Person(obj.GetColValue(Database_Names.Calender_Columes[1]).ToString());
                treatment = new Treatments(int.Parse(obj.GetColValue(Database_Names.Calender_Columes[3]).ToString()));
                product = new Cart(int.Parse(obj.GetColValue(Database_Names.Calender_Columes[3]).ToString()));
                r.AddColume(new Col("client_name", client.GetFullName()));
                r.AddColume(new Col("worker_name", worker.Person.GetFullName()));
                DateTime time = DateTime.Parse(r.GetColValue(Database_Names.Calender_Columes[5]).ToString());
                time = time.AddMinutes(double.Parse(treatment.GetColValue("duration").ToString()));
                r.AddColume("ending", time.ToShortTimeString());
                r.AddColume("treatment_name",product.GetColValue("product_name"));
                rows.Add(r);
            }
            return rows;
        }
        public static int TreatmentsInDay(DateTime time)
        {
           return GetApoitmentsInfomation(time.ToShortDateString()).Count;
        }
        public static List<Calender_Table> GetAppoitments(string date)
        {
            Calender_Table calender = new Calender_Table();
            List<Calender_Table> list=new List<Calender_Table>();
            foreach(DB_Object obj in calender.Grab(Database_Names.Calender_Columes[5], date ,Database_Names.Calendrer))
                list.Add(new Calender_Table(obj));
            return list;
        }
        public DateTime GetApooitmentStartingTime()
        {
            DateTime day = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
            DateTime time = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[6]).ToString());
            return new DateTime(day.Year, day.Month, day.Day, time.Hour, time.Minute, 0);
        }
        public DateTime GetApooitmentEndingTime()
        {
            DateTime day = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
            DateTime time = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[6]).ToString());
            DateTime selected = new DateTime(day.Year, day.Month, day.Day, time.Hour, time.Minute, 0);
            return selected.AddMinutes(double.Parse(Item.Product.GetDuration())) ;
        }
        internal int GetDuration()
        {
            return int.Parse(Item.Product.GetDuration());
        }

        internal string getTreatmentInformation()
        {
            return $"{Item.Product.getName()}";
        }

        internal string GetCustomerFullName()
        {
            return Client.GetFullName();
        }
        internal string getWorkerName() {
        return Worker.GetFullName();
        }
        internal string getSchedualeTime()
        {
            return $"בתאריך:{GetColValue(Database_Names.Calender_Columes[5])}\nבשעה:{GetColValue(Database_Names.Calender_Columes[6])}";
        }
        internal bool IsShedualeTimeExisit()
        {
            if (GetColValue(Database_Names.Calender_Columes[6]).ToString() == "" && GetColValue(Database_Names.Calender_Columes[5]).ToString() == "")
                return false;
            return true;
        }
        public bool IsDateTimeWithInRange(DateTime date)
        {
            TimeSpan start = GetApooitmentStartingTime().Subtract(date);
            TimeSpan end = GetApooitmentEndingTime().Subtract(date);
            if (start.Minutes + start.Hours * 60 <= 0 && end.Minutes + end.Hours * 60 >= 0)
                return true;
            return false;
        }
        public bool IsDateTimeInEdge(DateTime date,bool start)
        {
            TimeSpan span;
            if (start)
                span = GetApooitmentStartingTime().Subtract(date);
            else
                span = GetApooitmentEndingTime().Subtract(date);
            return span.Minutes + span.Hours * 60 == 0;
        }

        internal void SetSchedualeTime(DateTime selectTime)
        {
            SetColValue(Database_Names.Calender_Columes[5],selectTime.ToShortDateString());
            SetColValue(Database_Names.Calender_Columes[6],selectTime.ToShortTimeString());
        }
        internal Products GetProduct()
        {
            return Item.Product;
        }

        internal void SetProduct(int product_id)
        {
            Item.Product = new Products(product_id);
            SetColValue(Database_Names.Calender_Columes[3], product_id);
        }

        internal void setWorker(string worker_id)
        {
            Worker = new Workers(worker_id);
            SetColValue(Database_Names.Calender_Columes[2], worker_id);
        }

        internal void setClient(Person person)
        {
            Client = person;
            SetColValue(Database_Names.Calender_Columes[1], person.Value);
        }


        internal void setOrder(object value)
        {
            SetColValue(Database_Names.Calender_Columes[4], value);
        }
    }
}
