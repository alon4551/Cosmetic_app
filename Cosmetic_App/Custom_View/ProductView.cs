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

namespace Cosmetic_App.Custom_View
{
    public partial class ProductView : UserControl
    {// a custom view for product  in a list
        public ProductView()
        {
            InitializeComponent();
        }

        private void ProductView_Load(object sender, EventArgs e)
        {

        }
        public void SetData(Products product)
        {
            label1.Text = product.GetColValue("product_name").ToString();
            label2.Text = product.GetColValue("price").ToString() + " ש''ח ";
            label1.Tag = product;
            label2.Tag = product;
            table_product_layout.Tag= product;
            product_name.Tag = product;
            product_price.Tag = product;
            this.Tag = product;   
        }
        public void SetAction(EventHandler action,KeyEventHandler keyEvent)
        {
            this.KeyDown += keyEvent;
            label1.KeyDown += keyEvent;
            label2.KeyDown += keyEvent;
            table_product_layout.KeyDown += keyEvent;
            table_product_layout.Click += action;
            product_name.Click+= action;
            product_price.Click+= action;
            label1.Click+= action;
            label2.Click+= action;
            this.Click += action;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
