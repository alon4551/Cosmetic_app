using Cosmetic_App.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Custom_View
{
    public partial class Cart_Schedule_View : UserControl
    {//custom view for a adding teartment to cart in scheduale window

        List<string> Names = new List<string>();
        public Cart_Schedule_View()
        {
            InitializeComponent();
            Fetch();

        }
        
        public Cart_Schedule_View(Cart cart, EventHandler SetDate, EventHandler Cancel,EventHandler setWorker)
        {//setting all the information into the view
            InitializeComponent();
            Fetch();
            this.Tag = cart;
            Cancel_btn.Tag = cart;
            SetDate_btn.Tag = cart;
            treatment_box.Text = cart.GetName();
            if (cart.GetColValue("time") != null)
                time_box.Text = cart.GetColValue("time").ToString();
            SetAction(SetDate, Cancel); 
        }
        public async void Fetch()
        {
           
        }
        public void SetWorkerName(string name)
        {
            worker_namebox.Text = name;
        }

        public void SetAction(EventHandler SetDate,EventHandler Cancel)
        {
            SetDate_btn.Click += SetDate;
            Cancel_btn.Click += Cancel;
        }

        private void time_box_TextChanged(object sender, EventArgs e)
        {
            time_box.BackColor = Color.Gray;
        }

        internal string Day()
        {
            return time_box.Text;
        }

        internal string getTime()
        {
            return time_box.Text;
        }

        internal void SetTime(DateTime dateTime)
        {
            time_box.Text = dateTime.ToString();
        }
    }
}
