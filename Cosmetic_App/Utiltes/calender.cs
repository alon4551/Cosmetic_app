using Cosmetic_App.Custom_View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Utiltes
{
    public static class calender
    {
        private static DateTime DisplayTime = DateTime.Now;
        
        private static List<Row> Apooitments = new List<Row>();
        public static void DisplayDays_OnCalender(FlowLayoutPanel panel, Label mouth)
        {
            panel.Controls.Clear();
            mouth.Text = $@"תאריך: { DisplayTime.Month}/{DisplayTime.Year}";
            int i;
            DateTime startOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, 1);
            DateTime endOfTheMouth;
            int days = DateTime.DaysInMonth(DisplayTime.Year, DisplayTime.Month);
            int dayofweek = int.Parse(startOfTheMouth.DayOfWeek.ToString("d"));
            for (i = 0; i < dayofweek; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                panel.Controls.Add(blank);
            }
            for ( i = 1; i <= days; i++)
            {
                MonthCalender_Day day = new MonthCalender_Day();
                day.Day(i);
                DateTime time = new DateTime(DisplayTime.Year, DisplayTime.Month, i);
                day.SetTreatments(Calender_Table.TreatmentsInDay(time));
                day.DateColor(DateTime.Today.CompareTo(time));
                panel.Controls.Add(day);
            }
            endOfTheMouth = new DateTime(DisplayTime.Year, DisplayTime.Month, i-1 );
            i = int.Parse(endOfTheMouth.DayOfWeek.ToString("d"));
            for (; i < 6; i++)
            {
                MonthCalender_Blank blank = new MonthCalender_Blank();
                panel.Controls.Add(blank);
            }
        }
        public static void Display_Apooitments(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();

            foreach(Row r in Apooitments)
            {
                Appoitment_view appoitment = new Appoitment_view();
                appoitment.SetDate(r);
                panel.Controls.Add(appoitment);
            }
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
