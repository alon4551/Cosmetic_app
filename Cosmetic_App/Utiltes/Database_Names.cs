using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Utiltes
{
    public static class Database_Names
    {
        public static string People = "people";
        public static string Workers = "workers";
        public static string Clients = "clients";
        public static string Cart = "cart";
        public static string Calendrer = "calender";
        public static string Products = "products";
        public static string Treatments = "treatments";
        public static string Income = "income";
        public static string Outcome = "outcome";
        public static string Shifts = "shifts";
        public static List<string> People_Columes = new List<string>() { "id","firstname","lastname","birthday","phone","email" };
        public static List<string> Workers_Columes = new List<string>() { "id","password","admin" };
        public static List<string> Clients_Columes = new List<string>() { "id","balance" };
        public static List<string> Calender_Columes = new List<string>() { "id", "client_id" ,"worker_id","treatment_id", "day","time" };    
        public static List<string> Cart_Columes = new List<string>() { "id", "order_id","product_id" };
        public static List<string> Income_Columes = new List<string>() { "id", "total","client","worker","date_of_purchase","recipt" };
        public static List<string> Outcome_Columes = new List<string>() { "id","total","date_of_purchase","recipt","supplier" };
        public static List<string> Product_Columes = new List<string>() { "id","product_name","price","inventory" };
        public static List<string> Shifts_Columes = new List<string>() { "id","worker","day","time","clock_in" };
        public static List<string> Treatment_Columes = new List<string>() { "id","duration" };
    }
}
