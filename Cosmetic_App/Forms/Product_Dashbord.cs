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
        List<Products> Selected_List ,filter_list=new List<Products>();
        bool filter = false;
        int select_catagory = -1;
        Products Selected_Object;
        public Product_Dashbord()
        {
            InitializeComponent();
            Selected_List = Products.GrabAll();
        }
        public Product_Dashbord(bool treatment_list)
        {
            InitializeComponent();
            if (treatment_list)
            {
                Selected_List = Products.GetAllTreatments();
            }
            else
            {
                Selected_List = Products.GetAllMerchandise();
            }
            select_catagory = treatment_list ? 1 : 0;
        }
        private void Product_Dashbord_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Load_List(List<Products> list) 
        {
            s.Controls.Clear();
            foreach(Products p in list) 
            {
                ProductView view = new ProductView();
                view.SetData(p);

                view.SetAction(Click_Product_View,keybored_click);
                s.Controls.Add(view);
            }
        }
        private void Load_Information()
        {
            Input.Load_TextBox_Information(product_table_layout, Selected_Object); ;
            if (Selected_Object.IsTreatment())
            {
                label1.Text = "פרטים על הטיפול";
                p_info_label.Text = "אורך הטיפול";
                p_info.Text = Selected_Object.GetDuration() + " דקות";
                this.Text = "רשימת טיפולים";
            }
            else
            {
                label1.Text = "פרטים על המוצר";
                p_info_label.Text = "כמות";
                p_info.Text = Selected_Object.getInventory().ToString();
                this.Text = "רשימת מוצרים";
            }

        }
        private void Click_Product_View(object sender, EventArgs e)
        {
            if (Input.GetTag(sender) == null) return;
            Selected_Object =(Products)Input.GetTag(sender);
           Load_Information();
        }
        private void keybored_click(object sender, KeyEventArgs key)
        {
            
            if(key.KeyData == Keys.Down)
            {
                ChangeIndex(true);
            }
            else if(key.KeyData == Keys.Up)
            {
                ChangeIndex(false);
            }
        }
        private void ChangeIndex(bool forward)
        {
            int index = Selected_List.IndexOf(Selected_Object);
          
            if(forward)
            {
                if (filter)
                {
                    if (filter_list.Count-1 == index) return;
                }
                else
                {
                    if (Selected_List.Count-1 == index) return;
                }
                Selected_Object = Selected_List[index+1];
            }
            else
            {

                    if (index == 0 ) return;
                Selected_Object = Selected_List[index - 1];
            }
            Load_Information();
        }
        private void NewProduct_Click(object sender, EventArgs e)
        {
            bool state = select_catagory == 1 ? true : false;
            using (Product_Profile profile = new Product_Profile(state))
            {
                profile.ShowDialog();
                Reload();
            }
        }
        public void Reload()
        {
            if (select_catagory == -1)
                Selected_List = Products.GetAllProducts();
            else if (select_catagory == -0)
                Selected_List = Products.GetAllMerchandise();
            else if (select_catagory == 1)
                Selected_List = Products.GetAllTreatments();
            filter = false;
            Load_List(Selected_List);
            Input.Clear_Textbox_Information(product_table_layout);
            Selected_Object = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Selected_Object == null) return;
            using (Product_Profile profile = new Product_Profile((int)Selected_Object.Value))
            {
                profile.ShowDialog();
                Reload();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                filter = false;
                Load_List(Selected_List);
            }
            else
            {
                filter = true;
                filter_list.Clear();
                foreach (Products p in Selected_List)
                {
                    if (p.getName().Contains(textBox1.Text))
                    { filter_list.Add(p); }
                }
                Load_List(filter_list);
            }
               
        }
    }
}
