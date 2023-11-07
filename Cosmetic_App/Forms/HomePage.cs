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
            calender.DisplayDays_OnCalender(flowLayoutPanel1, label8, calender.CalenderSize);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(true);
            calender.DisplayDays_OnCalender(flowLayoutPanel1, label8,calender.CalenderSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(false);
            calender.DisplayDays_OnCalender(flowLayoutPanel1, label8, calender.CalenderSize);
        }
    }
}
