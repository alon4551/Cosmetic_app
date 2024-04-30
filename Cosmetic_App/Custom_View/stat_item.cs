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
    public partial class stat_item : UserControl
    {
        public stat_item()
        {
            InitializeComponent();
        }
        public void SetInformation(string ProductName, int price,int amount)
        {
            namebox.Text = ProductName;
            pricebox.Text = price + "ש''ח";
            amountbox.Text = amount.ToString();
            sumbox.Text = amount * price + "ש''ח";
        }
    }
}
