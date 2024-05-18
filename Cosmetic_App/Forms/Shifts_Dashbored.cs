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
        { // loading shift information 
            Selected_Shift = (Shifts)Input.GetTag(sender);
           Load_Shift(Selected_Shift);
        }
        private void Load_Shift(Shifts shift)
        {//loading shift information
            try
            {
                tableLayoutPanel10.Enabled = true;
                starting_time.Value = shift.getStartTime();
                ending_time.Value = shift.getEndTime();
                date_shift.Text = shift.GetDate().ToShortDateString();
            }
            catch (Exception ex) { }
        }
        private void Load_Shifts()
        {//load all shifts information in calender and calualte all hour of works (including overtime)
            calender.DisplayShifts_OnCalender(tableLayoutPanel7,label1,calender.CalenderSize, click,Worker);
            double shift_count =0,regular=0,extra =0,extra_plus = 0,time;
            foreach (Shifts shift in Worker.GetShifts(calender.GetSelectedDate())){
                time = shift.GetTimeWork();
                shift_count += time;
                if (time <= 8)
                    regular += time;
                else if(time <=10 && time > 8)
                {
                    regular += 8;
                    extra += time - 8 ;
                }
                else if( time > 10 )
                {
                    regular += 8;
                    extra += 2;
                    extra_plus += time - 10;
                }
            }
            textBox1.Text = shift_count.ToString();
            textBox2.Text = regular.ToString();
            textBox3.Text = extra.ToString();
            textBox4.Text = extra_plus.ToString();
           
        }
        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //changing shift information (only allowd to managers)
            if (ending_time.Value.Subtract(starting_time.Value).Ticks < 0)
            {
                MessageBox.Show("אין אפשרות לבצע פעולת שמירה עקב מידע לא תקין");
                return;
            }
            using (Manager_Verification verification = new Manager_Verification())
            {
                verification.ShowDialog();
                if (!verification.result)
                    return;
            }
            Selected_Shift.Set_Start_Time(starting_time.Value.ToShortTimeString());
            Selected_Shift.Set_End_Time(ending_time.Value.ToShortTimeString());
            if (Selected_Shift.Update())
                MessageBox.Show("משמרת עודכנה בהצלחה");
            else
                MessageBox.Show("שגיאה");

            Worker.Reload();
            Load_Shifts();
        }

        private void Reload()
        {//reloading inforamtion and display
            tableLayoutPanel10.Enabled = false;
            Worker.Reload();
            Load_Shifts();
        }

        private void button4_Click(object sender, EventArgs e)
        {// cahnge calender 1 mounth backwords
            calender.ChangeMouth(false);
            dateTimePicker1.Value = calender.GetSelectedDate();
        }

        private void button3_Click(object sender, EventArgs e)
        {// cahnge calender 1 mounth forwords
            calender.ChangeMouth(true);
            dateTimePicker1.Value = calender.GetSelectedDate();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // changeing calender depand on datetime picker
            calender.SetDisplayTime(dateTimePicker1.Value);
            Reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {//deleting shift
            using(Manager_Verification verification = new Manager_Verification()) {
                verification.ShowDialog();
                if (!verification.result)
                    return;
            }
            if(MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את המשמרת?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (Selected_Shift.Delete())
                {
                    MessageBox.Show("משמרת נמחקה");
                    Reload();
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {// reset calender to present day
            calender.Reset();
            Reload();
        }
    }
}
