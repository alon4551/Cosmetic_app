using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
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
    public partial class Product_Dashbord : Form
    {
        List<Products> products = new List<Products>(),filter=new List<Products>();
        public Product_Dashbord()
        {
            InitializeComponent();
        }

        private void Product_Dashbord_Load(object sender, EventArgs e)
        {
            products = Products.GrabAll();
            Load_List(products);
        }
        private void Load_List(List<Products> list) 
        {
            s.Controls.Clear();
            foreach(Products p in list) 
            {
                ProductView view = new ProductView();
                view.SetData(p);
                view.SetAction(Click_Product_View);
                s.Controls.Add(view);
            }
        }
        private void Load_Information(int id)
        {
            foreach (Products p in products)
                if ((int)p.Value == id)
                {
                    Input.Load_TextBox_Information(product_table_layout, p);
                    if (p.IsTreatment())
                    {
                        label1.Text = "פרטים על הטיפול";
                        p_info_label.Text = "אורך הטיפול";
                        p_info.Text = p.Treatment.GetColValue("duration").ToString() + " דקות"; 
                    }
                    else
                    {
                        label1.Text = "פרטים על המוצר";
                        p_info_label.Text = "כמות";
                        p_info.Text = p.getInventory().ToString();
                    }
                }
        }
        private void Click_Product_View(object sender, EventArgs e)
        {
           Load_Information((int) Input.GetTag(sender));
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                Load_List(products);
            else
            {
                filter.Clear();
                foreach(Products p in products)
                {
                    if(p.getName().Contains(textBox1.Text))
                    { filter.Add(p); }
                }
                Load_List(filter);
            }
               
        }
    }
}
