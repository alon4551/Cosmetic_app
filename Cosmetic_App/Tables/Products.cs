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
    {// product class representing Product table, Connected to Treatment Table as well,the object can be merchadise or treatment.
        public Treatments Treatment { get; set; } = new Treatments();
        public static List<Products> AllProducts = GetAllProducts();
        public static List<Products> AllTreatments = GetAllTreatments();
        public static List<Products> AllMerchndice = GetAllMerchandise();
        public static void Reload()
        {//featching all information from DB
            AllProducts = GetAllProducts();
            AllTreatments = GetAllTreatments();
            AllMerchndice = GetAllMerchandise();
        }
        public static string GetDuration(int id)
        {//return duration of treatment
            foreach (Products product in AllProducts)
                if (product.Value.ToString() == id.ToString())
                    return product.GetDuration();
            return "";
        }
        public Products():base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Value = base.GetNewIndex();
            Treatment.Value = Value;
        }
        public Products(int id):base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Grab(id);
        }
        public static Products GetProduct(int id)
        {//return product from DB
            foreach(Products product in AllProducts)
                if((int)product.Value==id)
                    return product;
            return null;
        }
        public Products(Row row) : base(Database_Names.Products, Database_Names.Product_Columes)
        {
            Value = row.GetColValue(0);
            SetColValue(0, row.GetColValue(0));
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
        {//featching product information from DB
            bool result = base.Grab(id);
            if (IsTreatment())
            {
                Treatment = Treatments.GetTreatment((int)id);
                result &= Treatment.IsEmpty();
            }
            return result;
        }
        internal bool Update()
        {//update product inforamtion in DB
            if (IsTreatment())
                return base.Update() && Treatment.Update();
            else
                return base.Update();
        }
        public bool IsTreatment()
        {//return if product is treatment or merchendise
            return bool.Parse(GetColValue("istreatment").ToString());
        }
        public void SetIsTreatment(bool state)
        {//setting product if is treatment or merchendise
            SetColValue("istreatment", state);
        }
        public static List<Products> GrabAll()
        {//getting all products from DB
            List<Products> products = new List<Products>();
            foreach (DB_Object obj in DB_Object.GrabAll(Database_Names.Products))
                products.Add(new Products((int)obj.Value));
            return products;
        }
        public string getName()
        {//getting full name of product
            return GetColValue("product_name").ToString();
        }
        public int getInventory()
        {//returning how much in merchendise are in the store
            return (int)GetColValue("inventory");
        }
        public string GetDuration()
        {//returning how much time treatment cost in min
            if (IsTreatment())
                return Treatment.GetColValue("duration").ToString();
            else return "";
        }
       
        internal void SetInvetory(int v)
        {//setting inventory of product
            SetColValue("inventory", v);
        }
        public static bool IsTreatment(int id)
        {//return if product is treatment or merchendise
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Products, new Condition(Database_Names.Product_Columes[0], id)));
            if (rows.Count == 0) return false;
            else
                return (bool)rows[0].GetColValue(Database_Names.Product_Columes[4]);
        }
            public static List<Products> GetAllProducts()
        {//return all products from DB
            List<Products> products = new List<Products>();
            foreach(Row r in Access.getObjects(SQL_Queries.LeftOuterJoin(Database_Names.Products, Database_Names.Treatments, Database_Names.Product_Columes[0])))
            {
                Products product = new Products(r);
                products.Add(product);
            }
            return products;
        }
        public static List<Products> GetAllMerchandise()
        {//returning all merchendise from DB
            List<Products> list =new List<Products>();
            foreach (Products r in AllProducts)
                if (r.IsTreatment() == false)
                list.Add(r);
            return list;
        }
        internal object GetPrice()
        {//returning the price of product
            return GetColValue(Database_Names.Product_Columes[2]);
        }

        internal static List<Products> GetAllTreatments()
        {//returning all treatment from DB
            List<Products> list = new List<Products>();
            foreach (Products r in AllProducts)
                if (r.IsTreatment() == true)
                    list.Add(r);
            return list;
        }

        internal void RealoadList()
        {//featching information form DB
            AllProducts = GetAllProducts();
            AllTreatments = GetAllTreatments();
            AllMerchndice = GetAllMerchandise();
        }
        public static void CheckInventory()
        {//checking if merchendise inventory has depleted
            string list = "";
            foreach (Products product in AllMerchndice)
            {
                if (product.getInventory() < 5)
                {
                    list += $"מוצר {product.getName()} יש כמות קטנה מ5 פריטים, נא להוסיף למחסן \n";
                }
            }
            if (list != "")
                MessageBox.Show(list);
        }
        internal void ReduceInventory(int quantity)
        {//Reduceing Inventory of product
            SetColValue(3,getInventory()-quantity);
        }

        internal void returnInventory(int amount)
        {//return merchendise to the store and DB
            SetColValue(3, getInventory() + amount);
        }
    }
}
