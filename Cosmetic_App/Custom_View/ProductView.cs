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
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void ProductView_Load(object sender, EventArgs e)
        {

        }
        public void SetData(Products product)
        {
            textBox1.Text = product.GetColValue("product_name").ToString();
            textBox2.Text = product.GetColValue("price").ToString() + " ש''ח ";
            textBox1.Tag = product.Value;
            textBox2.Tag = product.Value;
            tableLayoutPanel1.Tag= product.Value;
            product_name.Tag = product.Value;
            product_price.Tag = product.Value;
            this.Tag = product.Value;
        }
        public void SetAction(EventHandler action)
        {
            product_name.Click+= action;
            product_price.Click+= action;
            textBox1.Click+= action;
            textBox2.Click+= action;
            this.Click += action;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
