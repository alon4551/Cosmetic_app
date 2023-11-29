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
    public partial class MonthCalender_Day:UserControl
    {
        public MonthCalender_Day()
        {
            InitializeComponent();
        }

        private void UserControl_Day_Load(object sender, EventArgs e)
        {

        }
        public void Day(int day)
        {
            label1.Text = day.ToString();
        }
        public void SetTreatments(int treatments)
        {
            treatments_label.Text = $"{treatments} טיפולים";
        }
        public void DateColor(int state)//-1 passed 0 today 1 mean future
        {
            switch (state)
            {
                case 1:
                    this.BackColor = SystemColors.Control;
                    break;
                case 0:
                    this.BackColor = SystemColors.ActiveCaption;
                    break;
                case -1:
                    this.BackColor = SystemColors.Window;
                    break;
            }
        }

        private void MonthCalender_Day_Click(object sender, EventArgs e)
        {
            using (DayCalender day = new DayCalender()) {
                calender.SetDay(label1.Text);
                day.ShowDialog();
            }
        }

        private void treatments_label_Click(object sender, EventArgs e)
        {
            MonthCalender_Day_Click(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MonthCalender_Day_Click(null, null);
        }

    }
}
