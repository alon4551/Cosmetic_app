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
    public partial class StoreProductView : UserControl
    {
        public StoreProductView()
        {
            InitializeComponent();
        }
        public StoreProductView(Products p)
        {
            InitializeComponent();
            SetInformation(p);
        }
        public void SetInformation(Products product)
        {
            name_box.Text = product.getName();
            price_box.Text = $"{product.GetPrice()} ש''ח";
            button1.Tag = product;
            this.Tag = product.Value;
        }
        public int GetAmount()
        {
            return int.Parse(count_box.Text);
        }
        public void SetAction(EventHandler handler)
        {
            button1.Click += handler;
        }

        internal void disable_cancel()
        {
            button1.Enabled = false;
        }
    }
}
