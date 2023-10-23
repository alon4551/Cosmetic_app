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
    public partial class DayCalender : Form
    {

        public DayCalender()
        {
            InitializeComponent();
        }

        private void DayCalender_Load(object sender, EventArgs e)
        {
            calender.Display_Apooitments(flowLayoutPanel1);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
