using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            int i = 0;
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
            Products.CheckInventory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(true);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8,calender.CalenderSize,calender.Click);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(false);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calender.Reset();
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
        }

        private void הזמנהחדשהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewOrder(Workers.LogedWorker.Value.ToString(),this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
        }

        private void לקוחחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewPerson(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
        }

        private void עובדחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewWorker(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);
        }

        private void מוצרטיפולחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewProduct(this,false);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void clients_tool_item_Click(object sender, EventArgs e)
        {
            App_Process.Clients(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void טיפולחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewProduct(this, true);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void Workers_tool_item_Click(object sender, EventArgs e)
        {
            App_Process.Workers(this);
        }

        private void Product_tool_item_Click(object sender, EventArgs e)
        {
            App_Process.Products(this,false);
        }

        private void treatment_tool_item_Click(object sender, EventArgs e)
        {
            App_Process.Products(this,true);
        }

        private void משמרותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.ClockInOrOut(this);
        }

        private void שעוןנוכחותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.ClockInOrOut(this);
        }

        private void כלהמשמרותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.Shifts(this);
        }

        private void הזמנותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.Order_Dashborad(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void הוצאותToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void הוצאהחדשהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.NewExpance(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void כלההוצאותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.Expance_Dashboard(this);
        }

        private void סטטיסטיקהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Process.Statisteics(this);
            calender.DisplayDays_OnCalender(tableLayoutPanel6, label8, calender.CalenderSize, calender.Click);

        }

        private void חדשToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
