using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App
{
    public class Calender_Table:DB_Object
    {
        public Calender_Table():base(Database_Names.Calendrer,Database_Names.Calender_Columes) { }
        public Calender_Table(DB_Object obj):base(obj) { }
        public static List<Row> GetApoitmentsInfomation(string date)
        {
            List<Row> rows = new List<Row>();
            Person client;
            Workers worker;
            Treatments treatment;
            Products product;
            Row r;
            Calender_Table table = new Calender_Table();
            List<DB_Object> list = table.Grab("day",date,Database_Names.Calendrer);
            foreach (DB_Object obj in list)
            {
                r = new Row(obj.Row.Columes);
                worker = new Workers(obj.GetColValue("worker_id").ToString());
                client = new Person(obj.GetColValue("client_id").ToString());
                treatment = new Treatments(int.Parse(obj.GetColValue("treatment_id").ToString()));
                product = new Products(int.Parse(obj.GetColValue("treatment_id").ToString()));
                r.AddColume(new Col("client_name", client.GetFullName()));
                r.AddColume(new Col("worker_name", worker.Person.GetFullName()));
                DateTime time = DateTime.Parse(r.GetColValue("time").ToString());
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
    }
}
