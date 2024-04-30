using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App
{
    public class Cart : DB_Object
    {
        public Products Product { get; set; }
        public Cart() : base(Database_Names.Cart, Database_Names.Cart_Columes) 
        {
            Value = GetNewIndex();
            SetColValue(0, Value);
        }
        public Cart(Row row) : base(row) 
        {
            Table = row.Table;
            Value = row.GetColValue(0);
            Product = new Products((int)row.GetColValue(Database_Names.Cart_Columes[2]));
        }
        public Cart(int id) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Grab(id);
            Product = Products.GetProduct((int)GetColValue(2));
            Table = Database_Names.Cart;
            Value = GetColValue(0);
        }
        public void Grab(object id)
        {
            base.Grab(id);
            Product = new Products((int)(GetColValue(2)));
            
        }
            public Cart(DB_Object obj) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Table = Database_Names.Cart;
            Value = obj.Value;
            SetColValue(0, Value);
            Row = obj.Row;
            Product =  Products.GetProduct((int)GetColValue(2));
        }
        public Cart(int order,int product ) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Value = GetNewIndex();
            SetColValue(0, Value);
            SetProduct(product);
            SetOrder_Id(order);
            Product = Products.GetProduct(product);
        }
        public Cart(int order, Products product) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Value = GetNewIndex();
            SetColValue(0, Value);
            SetProduct((int)product.Value);
            SetOrder_Id(order);
            Product = product;
        }
        public int GetProductId() { return (int)Product.Value; }
        public string GetProductName() { return Product.getName(); }
        public void SetProduct(int product_id){ SetColValue(Database_Names.Cart_Columes[2], product_id); }
        public void SetOrder_Id(int order_id){ SetColValue(Database_Names.Cart_Columes[1], order_id); }
        public void SetAmount(int amount){ SetColValue(Database_Names.Cart_Columes[3], amount); }
        public int GetAmount() { return (int)GetColValue(Database_Names.Cart_Columes[3]); }
        public int GetTotal() 
        {
            return GetAmount() * (int)Product.GetPrice();
        }

        internal string GetName()
        {
            return Product.getName();
        }

        internal void Reduce()
        {
            int amount = GetAmount();
            SetAmount(amount - 1);
        }
        public void Reduce(int amount)
        {
            SetAmount(GetAmount() - amount);
        }

        internal void Incrase(int count)
        {
            SetAmount(GetAmount()+ count);
        }

        public int GetPrice()
        {
            return (int)Product.GetPrice();
        }

        internal bool IsTreatment()
        {
            return Product.IsTreatment();
        }

        internal static List<Cart> GetItems(int order_id)
        {
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Cart,new Condition(Database_Names.Cart_Columes[1],order_id)));
            List<Cart> list=new List<Cart>();
            foreach(Row row in rows)
                list.Add(new Cart(row));
            return list;
        }

        internal void AddAmount(int v)
        {
            SetColValue(Database_Names.Cart_Columes[3],GetAmount()+ v);
        }
    }
}
