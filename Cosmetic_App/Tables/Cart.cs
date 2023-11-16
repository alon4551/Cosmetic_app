using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App
{
    public class Cart:DB_Object
    {
        public Products Product {  get; set; }
        public Cart() : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Value = GetNewIndex();
        }
        public Cart(int order,int product ) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Value = GetNewIndex();
            SetProduct(product);
            SetOrder_Id(order);
            Product.Grab(product);
        }
        public Cart(int order, Products product) : base(Database_Names.Cart, Database_Names.Cart_Columes)
        {
            Value = GetNewIndex();
            SetProduct((int)product.Value);
            SetOrder_Id(order);
            Product = product;
        }
        public int GetProductId() { return (int)Product.Value; }
        public void SetProduct(int product_id){ SetColValue(Database_Names.Cart_Columes[2], product_id); }
        public void SetOrder_Id(int order_id){ SetColValue(Database_Names.Cart_Columes[1], order_id); }
        public void SetAmount(int amount_id){ SetColValue(Database_Names.Cart_Columes[3], amount_id); }
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

        internal void Incrase(int count)
        {
            SetAmount(GetAmount()+ count);
        }

        public int GetPrice()
        {
            return (int)Product.GetPrice();
        }
    }
}
