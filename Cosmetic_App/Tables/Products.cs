using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Tables
{
    public class Products : DB_Object
    {
        public Treatments Treatment { get; set; } = new Treatments();
        public Products():base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Value = base.GetNewIndex();
            Treatment.Value = Value;
        }
        public Products(int id):base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Grab(id);
        }
        public Products(Row row) : base(Database_Names.Products, Database_Names.Product_Columes)
        {
            foreach(Col c in row.Columes)
            {
                if (c.GetField() == Database_Names.Product_Columes[0])
                {
                    Treatment.SetColValue(0, c.GetValue());
                    SetColValue(0,c.GetValue());
                }
                if (c.GetField() == Database_Names.Treatment_Columes[1])
                    Treatment.SetColValue(1, c.GetValue());
                else
                    SetColValue(c.GetField(), c.GetValue());
            }
        }
        internal bool Grab(object id)
        {
            bool result = base.Grab(id);
            if (IsTreatment())
            {
                Treatment = new Treatments((int)id);
             result &= Treatment.IsEmpty();
            }
            return result;
        }
        internal bool Update()
        {
            if (IsTreatment())
                return base.Update() && Treatment.Update();
            else
                return base.Update();
        }
        public bool IsTreatment()
        {
            return bool.Parse(GetColValue("istreatment").ToString());
        }
        public void SetIsTreatment(bool state)
        {
            SetColValue("istreatment", state);
        }
        public static List<Products> GrabAll()
        {
            List<Products> products = new List<Products>();
            foreach (DB_Object obj in DB_Object.GrabAll(Database_Names.Products))
                products.Add(new Products((int)obj.Value));
            return products;
        }
        public string getName()
        {
            return GetColValue("product_name").ToString();
        }
        public int getInventory()
        {
            return (int)GetColValue("inventory");
        }
        public string GetDuration()
        {
            if (IsTreatment())
                return Treatment.GetColValue("duration").ToString();
            else return "";
        }
       
        internal void SetInvetory(int v)
        {
            SetColValue("inventory", v);
        }
        public static List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();
            foreach(Row r in Access.getObjects(SQL_Queries.SelfJoin(Database_Names.Products, Database_Names.Treatments, Database_Names.Product_Columes[0])))
            {
                products.Add(new Products(r));
            }
            return products;
        }

        internal object GetPrice()
        {
            return GetColValue(Database_Names.Product_Columes[2]);
        }
    }
}
