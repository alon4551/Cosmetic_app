using Cosmetic_App.Custom_View;
using Cosmetic_App.Forms;
using Cosmetic_App.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Utiltes
{
    public static class calender
    {
        public static Size CalenderSize = new Size(125, 72);
        public static Size ApooitmentSize = new Size(66, 45);
        private static DateTime DisplayTime = DateTime.Now;
        private static List<Row> Apooitments = new List<Row>();
        public static int AppoitmentHight = 100;
        public static DateTime GetSelectedDate()
        {
            return DisplayTime;
        }
        public static void DisplayShifts_OnCalender(TableLayoutPanel panel, System.Windows.Forms.Label mouth, Size SelectedSize, EventHandler action,Workers worker)
        {
            panel.Controls.Clear();
            mouth.Text = $@"חודש: {DisplayTime.Month}/{DisplayTime.Year} עובד {worker.GetFullName()} תעודת זהות {worker.GetColValue(0)}";
            int i,j;
            DateTime startOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, 1);
            DateTime endOfTheMouth;
            int days = DateTime.DaysInMonth(DisplayTime.Year, DisplayTime.Month);
            int dayofweek = int.Parse(startOfTheMouth.DayOfWeek.ToString("d"));
            List<Shifts> shifts = worker.GetShifts(DisplayTime);
            for (i = 0; i < dayofweek; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                blank.Dock = DockStyle.Fill;
                panel.Controls.Add(blank);
            }
            for (i = 1,j=0; i <= days; i++)
            {
                MonthCalender_Day day = new MonthCalender_Day();
                day.Dock = DockStyle.Fill;
                day.Day(i);
                day.SetAction(action);
                DateTime time = new DateTime(DisplayTime.Year, DisplayTime.Month, i);
                if (j < shifts.Count && i == shifts[j].GetDate().Day)
                {
                    day.SetMessage(shifts[j].getTimeSpan());
                    day.SetTag(shifts[j]);
                    j++;
                }
                else
                {
                    day.SetMessage("");
                    DateTime date = new DateTime(DisplayTime.Year,DisplayTime.Month, i);
                    day.SetTag(new Shifts(date.ToShortDateString(),worker.GetColValue(0).ToString()));
                }
                day.DateColor(DateTime.Today.CompareTo(time));
                panel.Controls.Add(day);
            }
            endOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, i - 1);
            i = int.Parse(endOfTheMouth.DayOfWeek.ToString("d"));
            for (; i < 6; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                blank.Dock = DockStyle.Fill;
                panel.Controls.Add(blank);
            }
        }
        public static void DisplayDays_OnCalender(TableLayoutPanel panel, System.Windows.Forms.Label mouth, Size SelectedSize,EventHandler action)
        {
            panel.Controls.Clear();
            mouth.Text = $@"חודש: { DisplayTime.Month}/{DisplayTime.Year}";
            int i;
            DateTime startOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, 1);
            DateTime endOfTheMouth;
            int days = DateTime.DaysInMonth(DisplayTime.Year, DisplayTime.Month);
            int dayofweek = int.Parse(startOfTheMouth.DayOfWeek.ToString("d"));
            for (i = 0; i < dayofweek; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                blank.Dock = DockStyle.Fill;
                panel.Controls.Add(blank);
            }
            for ( i = 1; i <= days; i++)
            {
                MonthCalender_Day day = new MonthCalender_Day();
                day.Dock = DockStyle.Fill;
                day.Day(i);
                day.SetAction(action);
                DateTime time = new DateTime(DisplayTime.Year, DisplayTime.Month, i);
                day.Tag = time;
                day.SetMessage(Calender_Table.TreatmentsInDay(time).ToString()+" טיפולים");
                day.DateColor(DateTime.Today.CompareTo(time));
                panel.Controls.Add(day);
            }
            endOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, i-1 );
            i = int.Parse(endOfTheMouth.DayOfWeek.ToString("d"));
            for (; i < 6; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                blank.Dock = DockStyle.Fill;
                panel.Controls.Add(blank);
            }
        }
        public static void Click(object sender, EventArgs e)
        {
            using (DayCalender day = new DayCalender())
            {
                SetDay(Input.GetTag(sender).ToString());
                day.ShowDialog();
            }
        }
        public static void Display_Apooitments(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();

            foreach(Row r in Apooitments)
            {
                Appoitment_view appoitment = new Appoitment_view((int)r.GetColValue("order_id"));
                appoitment.SetAction(ClickAppoitmnet);
                appoitment.SetDate(r);
                panel.Controls.Add(appoitment);
            }
        }
        public static void Display_Apooitments(FlowLayoutPanel panel,string id)
        {
            panel.Controls.Clear();

            foreach (Row r in Apooitments)
            {
                if (r.GetColValue(Database_Names.Calender_Columes[2]).ToString() == id)
                {
                    Appoitment_view appoitment = new Appoitment_view((int)r.GetColValue("order_id"));
                    appoitment.SetAction(ClickAppoitmnet);
                    appoitment.SetDate(r);
                    panel.Controls.Add(appoitment);
                }
            }
        }
        public static void ClickAppoitmnet(object sender, EventArgs args)
        {
            int id = (int)(sender as Button).Tag;
            Income income = new Income(id);
            if (!income.IsPaid())
            {
                using (Store store =new Store(id))
                {
                    store.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("הזמנה כבר שולמה");
            }
        }
        public static void Reset()
        {
            DisplayTime= DateTime.Now;
        }
        public static void SetDisplayTime(DateTime time)
        {
            DisplayTime = time;
        }
        public static void ChangeMouth(bool forward)
        {
            if (forward)
                DisplayTime = DisplayTime.AddMonths(1);
            else
                DisplayTime = DisplayTime.AddMonths(-1);
            
        }
        public static void SetDay(string day)
        {
           Apooitments = Calender_Table.GetApoitmentsInfomation(new DateTime(DisplayTime.Year, DisplayTime.Month, int.Parse(day)).ToShortDateString());
        }
        public static void DisplayCalender(FlowLayoutPanel panel,System.Windows.Forms.Label mouth,Size size,EventHandler action)
        {
            DayApooitment_view Day;
            panel.Controls.Clear();
            if(mouth != null)
                mouth.Text = $@"תאריך: {DisplayTime.Month}/{DisplayTime.Year}";
            int i;
            DateTime startOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, 1);
            DateTime endOfTheMouth;
            int days = DateTime.DaysInMonth(DisplayTime.Year, DisplayTime.Month);
            int dayofweek = int.Parse(startOfTheMouth.DayOfWeek.ToString("d"));
            for (i = 0; i < dayofweek; i++)
                panel.Controls.Add(new DayApooitment_view(1));
            for (i = 1; i <= days; i++)
            {
                DateTime time = new DateTime(DisplayTime.Year, DisplayTime.Month, i);
                if (DateTime.Today.CompareTo(DisplayTime) != 0)
                {
                    if (time.CompareTo(DisplayTime) == 0)
                        Day = new DayApooitment_view(time, 0);
                    else if (time.CompareTo(DateTime.Today) == 0)
                        Day = new DayApooitment_view(time, -1);
                    else
                        Day = new DayApooitment_view(time, DateTime.Today.CompareTo(time));
                }
                else
                    Day = new DayApooitment_view(time, DateTime.Today.CompareTo(time));
                Day.SetAction(action);
                Day.Tag = time;
                panel.Controls.Add(Day);
            }
            endOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, i - 1);
            i = int.Parse(endOfTheMouth.DayOfWeek.ToString("d"));
            for (; i < 6; i++)
            {
                panel.Controls.Add(new DayApooitment_view(-1));
            }
        }

        public static void ClickDay(object sender, EventArgs e)
        {
            DayApooitment_view view = (DayApooitment_view)sender;
            SelectApoitmentTime.SelectDay = view.date.ToShortDateString();
            
        }
        public static void DisplayWorkerAppoitments(FlowLayoutPanel panel,List<Calender_Table> appoitments,DateTime date)
        {
            panel.Controls.Clear();
            DateTime Time = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            string displayDay = Time.ToShortDateString(), displayTime = "" ;
            for(int span = 60; displayDay==Time.ToShortDateString(); Time = Time.AddMinutes(span))
            {
                DisplayHour hour = new DisplayHour();
                foreach (Calender_Table apooitment in appoitments)
                {
                    
                    int s = GetTimeSpan(Time, apooitment.GetApooitmentStartingTime());
                    if (s > -60 && s <= 0) {
                        span = apooitment.GetDuration();
                        hour.SetData(apooitment.GetCustomerFullName(), apooitment.getTreatmentInformation());
                        break;
                    }
                    else if (s > 0 && s < 60)
                    {
                        span = 60 - s;
                        break;
                    }
                    else
                        span = 60;

                }
                if(Time.Hour<10 && Time.Minute<10)
                    displayTime = $"0{Time.Hour}:0{Time.Minute}";
                else if(Time.Hour < 10 && Time.Minute > 10)
                    displayTime = $"0{Time.Hour}:{Time.Minute}";
                else if (Time.Minute < 10)
                    displayTime = $"{Time.Hour}:0{Time.Minute}";
                else 
                    displayTime = $"{Time.Hour}:{Time.Minute}";
                hour.SetTime(displayTime, span);
                hour.ColorView(Time);  
                panel.Controls.Add(hour);
                
            }
        }
        public static int GetTimeSpan(DateTime time,DateTime start)
        {
            TimeSpan onj = time.Subtract(start);
            int span = onj.Minutes + onj.Hours * 60;
            if (span > 60 || span < -60)
                return AppoitmentHight;
            else
            {
                    return span;
            }
        }
    }
}
