using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class Store : Form
    {
        public Income Order = new Income();
        public List<Person> People = Person.GetAllClients(), people_filter = new List<Person>();
        public List<Products> products = Products.GetAllProducts(),Filter=new List<Products>();
        public List<Cart> ShopingCart = new List<Cart>();
        public object signture = null;
        public Store()
        {
            InitializeComponent();
        }
        public Store(string worker)
        {
            InitializeComponent();
            Order.SetWorker(worker);
        }
        private void Store_Load(object sender, EventArgs e)
        {
            Income_label.Text = $"קבלה מספר {Order.Value} תאריך {DateTime.Now.ToString()}";
            Load_Products_List(products);
            RelaodView();
            
        }
        public void RelaodView()
        {
            Load_Client_list();
           
            LoadShopingCart();

        }
        public void Load_Products_List(List<Products> list)
        {
            Products_Store_Layout.Controls.Clear();
            foreach(Products p in list)
            {
                StoreProductView view = new StoreProductView();
                view.SetInformation(p);
                view.SetAction(AddButtonClick);
                Products_Store_Layout.Controls.Add(view);
            }
        }
        public void LoadShopingCart()
        {
            Cart_layout.Controls.Clear();
            int total = 0;
            foreach(Cart item in ShopingCart)
            {
                CartView view = new CartView();
                view.SetInformation(item.GetName(), item.GetAmount());
                view.SetAction(RemoveClick);
                view.Tag = item.Value;
                Cart_layout.Controls.Add(view);
                total += item.GetTotal();
            }
            total_box.Text = total + "ש''ח";
        }
        public void RemoveClick(object sender, EventArgs e)
        {
            CartView view = (CartView)((Button)sender).Tag;
            foreach(Cart item in ShopingCart)
            {
                if(item.Value == view.Tag)
                {
                    item.Reduce();
                    if (item.GetAmount() <= 0)
                    {
                        ShopingCart.Remove(item);
                        break;
                    }
                }
            }
            RelaodView();
        }
        public void AddButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Products product = button.Tag as Products;
            Cart item;
            int count=0;
            foreach(StoreProductView view in Products_Store_Layout.Controls)
            {
                if (view.Tag == product.Value)
                {
                    count = view.GetAmount();
                    foreach (Cart c in ShopingCart)
                    {
                        if (c.GetProductId() == (int)product.Value)
                        {
                            c.Incrase(count);
                            RelaodView();
                            return;
                        }
                    }
                    item = new Cart((int)Order.Value, product);
                    item.SetAmount(count);
                    ShopingCart.Add(item);
                    break;
                }
            }
            RelaodView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filter = new List<Products>();
            if (textBox1.Text != "")
            {
                foreach (Products p in products)
                {
                    if (p.getName().Contains(textBox1.Text))
                        Filter.Add(p);
                }
                Load_Products_List(Filter);
            }
            else
                Load_Products_List(products);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog browse = new SaveFileDialog() { Filter = "PDF file|*.pdf",ValidateNames = true})
            {
                if (browse.ShowDialog() == DialogResult.OK)
                {
                    Order.SetCart(ShopingCart);
                    Order.CreateInvoce(browse.FileName,signture);


                }    
            }
        }

        private void Client_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.SetClient(People[Client_List.SelectedIndex]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Signature window = new Signature())
            {
                window.ShowDialog();
                signture = window.GetSignatureBitmap();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                People = Person.GetAllClients();
                RelaodView();
            }
        }

        public void Load_Client_list()
        {
            Client_List.Items.Clear();
            foreach(Person person in People)
                Client_List.Items.Add(person.GetFullName());
        }

    }
}
