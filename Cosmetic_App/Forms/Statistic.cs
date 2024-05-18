using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class Statistic : Form
    {
        List<Income> orders=new List<Income>();
        List<Person> list=new List<Person>();   
        List<Calender_Table> apooitments=new List<Calender_Table>();
        List<Products> SortedProducts = new List<Products>(),filter=new List<Products>();
        List<Cart> Items=new List<Cart>();
        public Statistic()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadStatLayout()
        {//calulateing sum of product and treatments
            order_box.Text=orders.Count.ToString();
            treatments_box.Text = apooitments.Count.ToString();
            int sum= 0;
            foreach (Income order in orders)
            {
                sum += (int)order.GetColValue("total");

            }
            sum_box.Text=sum.ToString() + "ש''ח";
            LoadOrderProductsList(filter_name_box.Text);

        }
        private void LoadOrderProductsList(string name)
        {//createing custom view of statistic information of products in selected dates 
            flowLayoutPanel1.Controls.Clear();
            SortedProducts.Clear();

            foreach (Cart cart in Items)
            {
                bool found = false;
                foreach (Products product in SortedProducts)
                {
                    if (cart.GetProductId() == (int)product.Value)
                    {
                        product.SetColValue("amount", (int)product.GetColValue("amount") + cart.GetAmount());
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    Products n = Products.GetProduct(cart.GetProductId());
                    n.AddCol("amount", cart.GetAmount());
                    if (name != "")
                    {
                        if (n.getName().Contains(name))
                            SortedProducts.Add(n);
                    }
                    else
                        SortedProducts.Add(n);
                }

            }
            stat_item view;
            int product_count = 0;
            foreach (Products product in SortedProducts)
            {
                view = new stat_item();
                view.SetInformation(product.getName(), (int)product.GetPrice(), (int)product.GetColValue("amount"));
                if(product.IsTreatment() ==false)
                {
                    product_count += (int)product.GetColValue("amount") ; 
                }
                flowLayoutPanel1.Controls.Add(view);

            }
            products_box.Text = product_count.ToString();
        }
        public void ExtractCartItems()
        {
           
        }
        private  void FeatchLists()
        {//getting statistic infomation from filter dates and disply them
            DateTime start =new DateTime(start_date.Value.Day+2000, start_date.Value.Month, start_date.Value.Year-2000);
            DateTime end = new DateTime(start_date.Value.Day+2000, start_date.Value.Month, start_date.Value.Year-2000);
            orders = Income.GetIncomes(start, end);
            Items.Clear();
            list.Clear();
            foreach (Income order in orders)
            {
                bool found = false ;  
                foreach(Person person in list)
                {
                    if(person.Value.ToString() == order.GetColValue(Database_Names.Income_Columes[2]).ToString())
                    {
                        found = true;
                        break;
                    }

                }
                if (found == false)
                {
                    list.Add(Person.GetPerson(order.GetColValue(Database_Names.Income_Columes[2]).ToString()));
                }
                found = false;
                foreach(Cart cart in order.GetShopingCart())
                {
                    found = false;
                    foreach (Cart item in Items)
                    {
                        if ((int)item.GetProductId() == cart.GetProductId())
                        {
                            item.AddAmount(cart.GetAmount());
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                        Items.Add(new Cart(cart));
                }
            }
            apooitments = Calender_Table.GetApooitments(start_date.Value.Date, end_date.Value.Date);
            clients_box.Text = list.Count.ToString();   
        }

        private void end_date_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {//search statistic from spesific dates
            FeatchLists();
            LoadStatLayout();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {//filter product form rest of list
            LoadOrderProductsList(filter_name_box.Text);
        }
    }
}
