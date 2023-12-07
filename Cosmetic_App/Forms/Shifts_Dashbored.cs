using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
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

namespace Cosmetic_App.Forms
{
    public partial class Shifts_Dashbored : Form
    {
        Workers Worker;
        public Shifts_Dashbored(string worker)
        {
            InitializeComponent();
            Worker = new Workers(worker);
        }
        public Shifts_Dashbored(Workers worker)
        {
            InitializeComponent();
            Worker = worker;
        }

        private void Shifts_Dashbored_Load(object sender, EventArgs e)
        {
            calender.DisplayShifts_OnCalender(tableLayoutPanel7, label1, calender.CalenderSize, click);
        }
        private void click(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }

    }
}
