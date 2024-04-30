using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public class Calender_Table:DB_Object
    {
        Cart Item { get; set; } = new Cart();
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        public Products Product { get; set; } = null;

        public Calender_Table():base(Database_Names.Calendrer,Database_Names.Calender_Columes) { }
        public Calender_Table(Row row) : base(Database_Names.Calendrer, Database_Names.Calender_Columes) {
            Row = row;
            Table = Database_Names.Calendrer;
            Value = row.GetColValue(0);
            Field = row.Columes[0].GetField();
            Reload();
        }
        public Calender_Table(DB_Object obj):base(obj) 
        {
            Reload();
        }
        public Calender_Table(string worker_id,string client_id,string cart_id,string order_id,string day,string time) : base(Database_Names.Calendrer, Database_Names.Calender_Columes)
        {
            Table = Database_Names.Calendrer;
            SetColValue(1, client_id);
            SetColValue(2, worker_id);
            SetColValue(3, cart_id);
            SetColValue(4, order_id);
            SetColValue(5, day);
            SetColValue(6, time);
            SetColValue(7, DateTime.Parse(day).Date);
        }
        public Calender_Table(int id) : base(Database_Names.Calendrer, Database_Names.Calender_Columes)
        {
            Value = id;
            Reload();
        }
        public void Reload()
        {
            Grab(Value);
            Item.Grab((int)GetColValue(3));
            Client = Person.GetPerson(GetColValue(Database_Names.Calender_Columes[1]).ToString());
            Worker = Workers.GetWorker(GetColValue(Database_Names.Calender_Columes[2]).ToString());
        }
        public static List<Row> GetApoitmentsInfomation(string date)
        {
            List<Row> rows = new List<Row>();
            Person client;
            Workers worker;
            Cart cart;
            Products product;
            Row r;
            Calender_Table table = new Calender_Table();
            List<DB_Object> list = table.Grab(Database_Names.Calender_Columes[5],date,Database_Names.Calendrer);
            foreach (DB_Object obj in list)
            {
                r = new Row(obj.Row.Columes);
                worker = Workers.GetWorker(obj.GetColValue(Database_Names.Calender_Columes[2]).ToString());
                client = Person.GetPerson(obj.GetColValue(Database_Names.Calender_Columes[1]).ToString());
                cart = new Cart(int.Parse(obj.GetColValue(Database_Names.Calender_Columes[3]).ToString()));
                product = Products.GetProduct(int.Parse(cart.GetColValue(Database_Names.Cart_Columes[2]).ToString()));
                r.AddColume(new Col("client_name", client.GetFullName()));
                r.AddColume(new Col("worker_name", worker.Person.GetFullName()));
                DateTime time = DateTime.Parse(r.GetColValue(Database_Names.Calender_Columes[6]).ToString());
                time = time.AddMinutes(double.Parse(cart.Product.GetDuration()));
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
        public static List<Calender_Table> GetAppoitments(int order_id)
        {
            Calender_Table calender = new Calender_Table();
            List<Calender_Table> list = new List<Calender_Table>();
            foreach (DB_Object obj in calender.Grab(Database_Names.Calender_Columes[4], order_id, Database_Names.Calendrer))
                list.Add(new Calender_Table(obj));
            return list;
        }
        public static List<Calender_Table> GetAppoitments(string date,string worker_id)
        {
            Calender_Table calender = new Calender_Table();
            List<Calender_Table> list = new List<Calender_Table>();
            List<Condition> conditions =new List<Condition>()
            {
                new Condition(Database_Names.Calender_Columes[2],worker_id),
                new Condition(Database_Names.Calender_Columes[5],date)
                
            };
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Calendrer, conditions, "AND"));
            foreach (Row row in rows)
                list.Add(new Calender_Table(row));
            return list;
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
            DateTime day, time, selected;
            day = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
            time = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[6]).ToString());
            selected = new DateTime(day.Year, day.Month, day.Day, time.Hour, time.Minute, 0);
            if(Item.Product != null)
            return selected.AddMinutes(double.Parse(Item.Product.GetDuration()));
            else
                return selected.AddMinutes(double.Parse(Product.GetDuration()));
        }
        internal int GetDuration()
        {
            try
            {
            return int.Parse(Item.Product.GetDuration());

            }
            catch
            {
                Cart item = new Cart((int)GetColValue(Database_Names.Calender_Columes[3]));
                return int.Parse(Products.GetDuration(item.GetProductId()));
            }
        }

        internal string getTreatmentInformation()
        {
            return $"{Item.Product.getName()}";
        }
        public Cart GetCart()
        {
            return Item;
        }
        internal string GetCustomerFullName()
        {
            return Client.GetFullName();
        }
        internal string getWorkerName() {
        return Worker.GetFullName();
        }
        internal DateTime getSchedualeDate()
        {
            return DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
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
            SetColValue(Database_Names.Calender_Columes[7], selectTime.Date);
        }
        internal Products GetProduct()
        {
            return Item.Product;
        }
        public Cart GetItem() { return Item; }
        internal void SetCartItem(int cart_id)
        {
            Item = new Cart(cart_id);
            SetColValue(Database_Names.Calender_Columes[3], cart_id);
        }

        internal void setWorker(string worker_id)
        {
            Worker = Workers.GetWorker(worker_id);
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

        internal string GetTime()
        {
            return GetColValue(6).ToString();
        }

        internal string GetDate()
        {
            return GetColValue(5).ToString();
        }

        internal void Fetch()
        {

        }
        public bool Update()
        {
            if (base.Update())
            {
                return true;
            }
            else
            {
                Delete();
                return Insert();
            }
        }
        internal DateTime getSchedualeTreatment()
        {

            DateTime Date = DateTime.Parse(GetColValue(5).ToString()),time =DateTime.Parse(GetColValue(6).ToString());
            return new DateTime(Date.Year,Date.Month,Date.Day,time.Hour,time.Minute,time.Second);
        }
        public static List<Calender_Table> GetApooitments(DateTime start, DateTime end)
        {
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Calendrer, Database_Names.Calender_Columes[7], start, end));
            List<Calender_Table> list=new List<Calender_Table>();
            foreach(Row row in rows)
            {
                list.Add(new Calender_Table(row));
            }
            return list;
        }
    }
}
