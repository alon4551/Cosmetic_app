﻿using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cosmetic_App.Forms
{
    public partial class Store : Form
    {
        public Income Order = new Income();
        public List<Person> People = Person.GetAllClients(), people_filter = new List<Person>();
        List<string> allNames = new List<string>();
        public List<Products> products = Products.GetAllMerchandise(),Filter=new List<Products>();
        public List<Cart> ShopingCart = new List<Cart>();
        public object signture = null;
        public bool finish = false;
        public Store()
        {
            InitializeComponent();
            foreach (Person person in People)
                allNames.Add(person.GetFullName());
        }
        public Store(int Order_id)
        {//getting order information
            InitializeComponent();
            foreach (Person person in People)
                allNames.Add(person.GetFullName());
            Order.Grab(Order_id);
            ShopingCart = Order.GetShopingCart();
        }
        private void Store_Load(object sender, EventArgs e)
        {//loading store window by order
            Income_label.Text = $"קבלה מספר {Order.Value} תאריך {Order.GetPurchaceDate()}";
            Load_Products_List(products);
            //Load_Client_list(People);
            textBox2.Text = Order.GetClientName();
            RelaodView();
            
        }
        public void RelaodView()
        {
            LoadShopingCart();
        }
        public void Load_Products_List(List<Products> list)
        {//loading product list from DB so customer can add the to cart
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
        {//loading shoping cart to window
            Cart_layout.Controls.Clear();
            int total = 0;
            int i = 0;
            foreach(Cart item in ShopingCart)
            {
                CartView view = new CartView();
                view.SetInformation(item.GetName(), item.GetAmount());
                view.SetAction(RemoveClick);
                view.Tag = item.Value;
                if (item.IsTreatment())
                {
                    view.disable_button();
                }
                Cart_layout.Controls.Add(view);
                total += item.GetTotal();
            }
            total_box.Text = total + "ש''ח";
        }
        public void RemoveClick(object sender, EventArgs e)
        {//removing item from cart
            CartView view = (CartView)((System.Windows.Forms.Button)sender).Tag;
            foreach (Cart item in ShopingCart)
            {

                if (item.Value == view.Tag)
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
        {//adding product to cart
            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;
            Products product = button.Tag as Products;
            Cart item;
            int count = 0;
            foreach (StoreProductView view in Products_Store_Layout.Controls)
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
        {//filter product list by text
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
        {//payment and creating invoce to the order
            DialogResult result= MessageBox.Show("האם אתה בטוח בהצעת המחיר הזאת?","",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (Signature window = new Signature())
                {
                    window.ShowDialog();
                    if (window.Sign)
                        using (SaveFileDialog browse = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true,FileName = $"קבלה{Order.Value}.pdf"})
                        {
                            if (browse.ShowDialog() == DialogResult.OK)
                            {
                                Order.SetCart(ShopingCart);
                                Order.SetColValue(Database_Names.Income_Columes[5], true);
                                Order.SetColValue(6, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                                if (Order.Save())
                                {
                                    Order.CreateInvoce(browse.FileName, window.signture);
                                    Order.BackUp();
                                    finish = true;
                                    Products.CheckInventory();
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("שגיאה");
                            }
                        }
                    else
                        MessageBox.Show("על מנת להמשיך בתהליך עלייך לחתום ולאשר חתימה");
                }
            }
        }

        private void Client_List_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {//signing the payment
            using (Signature window = new Signature())
            {
                window.ShowDialog();
                signture = window.GetSignatureBitmap();
            }
        }

        private void Client_List_Leave(object sender, EventArgs e)
        {
        }

        private void Client_List_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {//createing new person in 
            using(PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                People = Person.GetAllClients();
                Load_Client_list(People);
                RelaodView();
            }
        }

        public void Load_Client_list(List<Person> list)
        {//loading people list
            foreach (Person person in list)
            {
                textBox2.Text = (person.GetFullName());
            }
        }

    }
}
