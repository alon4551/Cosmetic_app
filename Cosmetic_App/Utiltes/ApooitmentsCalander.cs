using Cosmetic_App.Custom_View;
using Cosmetic_App.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Utiltes
{
    public static class ApooitmentsCalander
    {
        private static DateTime DisplayTime = DateTime.Now;
        private static List<Row> Apooitments = new List<Row>();
        public static int AppoitmentHight = 100;
        public static void DisplayCalender(FlowLayoutPanel panel, Label mouth)
        {
            DayApooitment_view Day;
            panel.Controls.Clear();
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
                Day = new DayApooitment_view(time, DateTime.Today.CompareTo(time));
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
        public static void DisplayWorkerAppoitments(FlowLayoutPanel panel, List<Calender_Table> appoitments, DateTime date)
        {
            panel.Controls.Clear();
            DateTime Time = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            string displayDay = Time.ToShortDateString();
            for (int span = 60; displayDay == Time.ToShortDateString(); Time = Time.AddMinutes(span))
            {
                DisplayHour hour = new DisplayHour();
                foreach (Calender_Table apooitment in appoitments)
                {

                    int s = GetTimeSpan(Time, apooitment.GetApooitmentStartingTime());
                    if (s > -60 && s <= 0)
                    {
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

                hour.SetTime(Time.ToShortTimeString(), span);
                hour.ColorView(Time);
                panel.Controls.Add(hour);
            }
        }
        public static int GetTimeSpan(DateTime time, DateTime start)
        {
            TimeSpan onj = time.Subtract(start);
            int span = onj.Minutes + onj.Hours * 60;
            if (span > 60 || span < -60)
                return 100;
            else
            {
                return span;
            }
        }
        public static void Reset()
        {
            DisplayTime = DateTime.Now;
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
    }
}
