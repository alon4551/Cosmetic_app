using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Income:DB_Object
    {
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        List<Products> Cart {  get; set; } = new List<Products>();
        List<Calender_Table> Apooitments { get; set; } = new List<Calender_Table>();
        public Income() : base(Database_Names.Income,Database_Names.Income_Columes)
        {

        }
        public Income(DB_Object obj) : base(obj)
        {

        }
        public Income (int id):base(Database_Names.Income, Database_Names.Income_Columes)
        {
            Grab(id);
        }
        public bool Grab(int id)
        {
            bool result =base.Grab(id);
            result &= Client.Grab(GetColValue(Database_Names.Income_Columes[2]));
            result &= Worker.Grab(GetColValue(Database_Names.Income_Columes[3]));            
            Cart = GrabOrderCart(id);
            Apooitments = GrabApooitments(id);
            return result;
        }
        public void ReloadApooitments()
        {
            Apooitments = GrabApooitments((int)Value);
        }
        private List<Calender_Table> GrabApooitments(int id)
        {
            List<Calender_Table> apooitments = new List<Calender_Table>();
            foreach (DB_Object obj in Grab(Database_Names.Calender_Columes[4], id, Database_Names.Calendrer))
                apooitments.Add(new Calender_Table((int)obj.Value));
            return apooitments;
        }
        private List<Products> GrabOrderCart(int id)
        {
            List<Products> products = new List<Products>();
            foreach(DB_Object obj in Grab(Database_Names.Cart_Columes[1], id, Database_Names.Cart))
                products.Add(new Products((int)obj.GetColValue(Database_Names.Cart_Columes[2])));
            return products;
        }
        public List<Products> GetCart()
        {
            return Cart;
        }
        public void SetClient(string id){Client.Grab(id);}
        public void SetWorker(string id) { Worker.Grab(id); }
        public void SetCart(int id) { Cart = GrabOrderCart(id); }
        public int GetOrderId() { return (int)GetColValue(0); }
        public string GetClientName() { return Client.GetFullName(); }
        public string GetWorkerName() { return Worker.GetFullName(); }
        public Products GetProduct(int id)
        {
            foreach (Products Product in Cart)
                if ((int)Product.Value == id)
                    return Product;
            return null;
        }
        public Calender_Table GetAppoitment(int product_id)
        {
            foreach(Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3])==product_id)
                    return appoitment;
            return null;
        }
        public int GetAppoitmentId(int product_id)
        {
            foreach (Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3]) == product_id)
                    return (int)appoitment.Value;
            return -1;
        }
        public bool IsTreatmentSchedule(int id)
        {
            foreach(Calender_Table appoitment in Apooitments)
            {
                if((int)appoitment.GetProduct().Value == id)
                    return true;
            }
            return false;
            List<Condition> conditions = new List<Condition>()
            {
                new Condition(Database_Names.Calender_Columes[4],Value),//order_id
                new Condition(Database_Names.Calender_Columes[3],id)//treatment_id

            };
            List<Row> list = Access.getObjects(SQL_Queries.Select(Table, conditions, "And"));
            
            if (list!=null && list.Count > 0)
                return true;
            else 
                return false;
        }

        internal Person GetClient()
        {
            return Client;
        }

        internal void Relaod()
        {
            Grab((int)Value);
        }
    }
}
