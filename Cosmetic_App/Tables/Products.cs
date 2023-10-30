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
        public Treatments Treatment { get; set; } = null;
        public Products():base(Database_Names.Products, Database_Names.Product_Columes) { }
        public Products(int id):base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Grab(id);
            if (IsTreatment())
                Treatment = new Treatments(id);
        }
        public bool IsTreatment()
        {
            return bool.Parse(GetColValue("istreatment").ToString());
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
    }
}
