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
    public partial class CartView : UserControl
    {
        public CartView()
        {
            InitializeComponent();
            button1.Tag = this;
        }
        public void SetInformation(string name,int amount)
        {
            name_box.Text = name;
            amount_box.Text = amount.ToString();
        }
        public void SetAction(EventHandler action)
        {
            button1.Click += action;
        }
        public void disable_button()
        {
            button1.Enabled = false;
        }
    }
}
