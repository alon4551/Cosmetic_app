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
    {// an object representing calender table, appoitment 
        Cart Item { get; set; } = new Cart();
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        public Products Product { get; set; } = null;

        public Calender_Table():base(Database_Names.Calendrer,Database_Names.Calender_Columes) { }
        public Calender_Table(Row row) : base(Database_Names.Calendrer, Database_Names.Calender_Columes) {
            //create new object based on the information from row
            Row = row;
            Table = Database_Names.Calendrer;
            Value = row.GetColValue(0);
            Field = row.Columes[0].GetField();
            Reload();
        }
        public Calender_Table(DB_Object obj):base(obj) 
        {//create new object and featch information from DB
            Reload();
        }
        public Calender_Table(string worker_id,string client_id,string cart_id,string order_id,string day,string time) : base(Database_Names.Calendrer, Database_Names.Calender_Columes)
        {//createing new object with infomation
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
        {//featching information from DB base on value key
            Value = id;
            Reload();
        }
        public void Reload()
        {//reloading data to the object
            Grab(Value);
            Item.Grab((int)GetColValue(3));
            Client = Person.GetPerson(GetColValue(Database_Names.Calender_Columes[1]).ToString());
            Worker = Workers.GetWorker(GetColValue(Database_Names.Calender_Columes[2]).ToString());
        }
        public static List<Row> GetApoitmentsInfomation(string date)
        {//return the order appoiments information in a list of row
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
        {//return how many Treatment in the time
           return GetApoitmentsInfomation(time.ToShortDateString()).Count;
        }
        public static List<Calender_Table> GetAppoitments(int order_id)
        {//return all appoitment in order
            Calender_Table calender = new Calender_Table();
            List<Calender_Table> list = new List<Calender_Table>();
            foreach (DB_Object obj in calender.Grab(Database_Names.Calender_Columes[4], order_id, Database_Names.Calendrer))
                list.Add(new Calender_Table(obj));
            return list;
        }
        public static List<Calender_Table> GetAppoitments(string date,string worker_id)
        {//returns all appoitments of worker in a date
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
        {//return all appoitments form date
            Calender_Table calender = new Calender_Table();
            List<Calender_Table> list=new List<Calender_Table>();
            foreach(DB_Object obj in calender.Grab(Database_Names.Calender_Columes[5], date ,Database_Names.Calendrer))
                list.Add(new Calender_Table(obj));
            return list;
        }
        public DateTime GetApooitmentStartingTime()
        {//return starting time of appoitments
            DateTime day = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
            DateTime time = DateTime.Parse(GetColValue(Database_Names.Calender_Columes[6]).ToString());
            return new DateTime(day.Year, day.Month, day.Day, time.Hour, time.Minute, 0);
        }
        public DateTime GetApooitmentEndingTime()
        {//return ending time of appoitments
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
        {//return duration of treatment
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
        {//return treatment name
            return $"{Item.Product.getName()}";
        }
        public Cart GetCart()
        {//return Cart of appoitment
            return Item;
        }
        internal string GetCustomerFullName()
        {//get customer fullname
            return Client.GetFullName();
        }
        internal string getWorkerName() {//return worker full name
        return Worker.GetFullName();
        }
        internal DateTime getSchedualeDate()
        {//return appoitment date 
            return DateTime.Parse(GetColValue(Database_Names.Calender_Columes[5]).ToString());
        }
        internal string getSchedualeTime()
        {//return appoitment date and time in a string  
            return $"בתאריך:{GetColValue(Database_Names.Calender_Columes[5])}\nבשעה:{GetColValue(Database_Names.Calender_Columes[6])}";
        }
        internal bool IsShedualeTimeExisit()
        {//return if appoitment time exist
            if (GetColValue(Database_Names.Calender_Columes[6]).ToString() == "" && GetColValue(Database_Names.Calender_Columes[5]).ToString() == "")
                return false;
            return true;
        }
        public bool IsDateTimeWithInRange(DateTime date)
        {//return if apooitment isn't collid with another appoitment
            TimeSpan start = GetApooitmentStartingTime().Subtract(date);
            TimeSpan end = GetApooitmentEndingTime().Subtract(date);
            if (start.Minutes + start.Hours * 60 <= 0 && end.Minutes + end.Hours * 60 >= 0)
                return true;
            return false;
        }
        public bool IsDateTimeInEdge(DateTime date,bool start)
        {//return if appoitment isnt collid with another appoitment
            TimeSpan span;
            if (start)
                span = GetApooitmentStartingTime().Subtract(date);
            else
                span = GetApooitmentEndingTime().Subtract(date);
            return span.Minutes + span.Hours * 60 == 0;
        }

        internal void SetSchedualeTime(DateTime selectTime)
        {//setting date into the object cols
            SetColValue(Database_Names.Calender_Columes[5],selectTime.ToShortDateString());
            SetColValue(Database_Names.Calender_Columes[6],selectTime.ToShortTimeString());
            SetColValue(Database_Names.Calender_Columes[7], selectTime.Date);
        }
        internal Products GetProduct()
        {//return appoitment product information
            return Item.Product;
        }
        public Cart GetItem() { return Item; }//return appoitment cart infomation
        internal void SetCartItem(int cart_id)//connect cart to appoitment
        {
            Item = new Cart(cart_id);
            SetColValue(Database_Names.Calender_Columes[3], cart_id);
        }

        internal void setWorker(string worker_id)//connect worker to appoitment
        {
            Worker = Workers.GetWorker(worker_id);
            SetColValue(Database_Names.Calender_Columes[2], worker_id);
        }

        internal void setClient(Person person)//connect client to appoitment
        {
            Client = person;
            SetColValue(Database_Names.Calender_Columes[1], person.Value);
        }


        internal void setOrder(object value)//connect order to appoitment
        {
            SetColValue(Database_Names.Calender_Columes[4], value);
        }

        internal string GetTime()//return starting time appoitment
        {
            return GetColValue(6).ToString();
        }

        internal string GetDate()//return date appoitment
        {
            return GetColValue(5).ToString();
        }

        internal void Fetch()
        {

        }
        public bool Update()//updateing appoitment in database
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
        internal DateTime getSchedualeTreatment()//return appoitment date and starting time 
        {

            DateTime Date = DateTime.Parse(GetColValue(5).ToString()),time =DateTime.Parse(GetColValue(6).ToString());
            return new DateTime(Date.Year,Date.Month,Date.Day,time.Hour,time.Minute,time.Second);
        }
        public static List<Calender_Table> GetApooitments(DateTime start, DateTime end)//getting appoitment filter by starting and ending dates 
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
