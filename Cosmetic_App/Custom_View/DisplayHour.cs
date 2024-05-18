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

namespace Cosmetic_App.Custom_View
{
    public partial class DisplayHour : UserControl
    {
        public DisplayHour()
        {
            InitializeComponent();
            SetView(false);
        }
        public DisplayHour(Calender_Table Appoitment)
        {
            InitializeComponent();
            SetView(true);
        }
        public void SetView(bool state)
        {
            richTextBox1.Visible = state;
            ending.Visible = state;
        }
        public void SetTime(string time,int span)
        {
            start.Text = time;
            ending.Text = DateTime.Parse(time).AddMinutes(span).ToShortTimeString();
        }
        public void ColorView(DateTime time) //gold means now, wheat means future, gray means past
        {//changing a backgroud color by realtine
            double span = time.Subtract(DateTime.Now).TotalMinutes;
            if (span > -60 && span < 0)
            {
                this.BackColor= Color.Gold;
            }
            else if(span >=0 )
            {
                this.BackColor = Color.Wheat;
            }
            else if(span <=-60)
            {
                BackColor= Color.Gray;
            }
        }
        public void SetData(string cusotmer,string treatment)
        {
            SetView(true);
            richTextBox1.Text = cusotmer + " " +treatment;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {

        }
    }
}
