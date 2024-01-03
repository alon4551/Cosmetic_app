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
        Shifts Selected_Shift;
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
            Load_Shifts();  
        }
        private void click(object sender, EventArgs e)
        {
            Selected_Shift = (Shifts)Input.GetTag(sender);
           Load_Shift(Selected_Shift);
        }
        private void Load_Shift(Shifts shift)
        {
            tableLayoutPanel10.Enabled = true;
            starting_time.Value = shift.getStartTime();
            ending_time.Value= shift.getEndTime();
            date_shift.Text = shift.GetDate().ToShortDateString();
        }
        private void Load_Shifts()
        {
            calender.DisplayShifts_OnCalender(tableLayoutPanel7,label1,calender.CalenderSize, click,Worker);   
        }
        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selected_Shift.Set_Start_Time(starting_time.Value.ToShortTimeString());
            Selected_Shift.Set_End_Time(ending_time.Value.ToShortTimeString());
            if (Selected_Shift.Update())
                MessageBox.Show("good");
            else
                MessageBox.Show("bad");

            Worker.Relaod();
            Load_Shifts();
        }

        private void Reload()
        {
            tableLayoutPanel10.Enabled = false;
            Load_Shifts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(false);
            dateTimePicker1.Value = calender.GetSelectedDate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calender.ChangeMouth(true);
            dateTimePicker1.Value = calender.GetSelectedDate();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calender.SetDisplayTime(dateTimePicker1.Value);
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את המשמרת?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (Selected_Shift.Delete())
                {
                    MessageBox.Show("משמרת נמחקה");
                    Worker.Reload();
                    Reload();
                }
        }
    }
}
