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
    public partial class DayApooitment_view : UserControl
    {
        public DateTime date{ get; set; }
        public DayApooitment_view()
        {
            
            InitializeComponent();
            
        }
        public DayApooitment_view( int state)
        {
            InitializeComponent();
            Setstate(state);
            Day.Text = "";
        }
        public DayApooitment_view(DateTime day, int state,int displaytime)
        {
            InitializeComponent();
            if (day.Year != date.Year)
            {
                Day.Text = day.Day.ToString();
                Day.Tag = day;
                this.Tag = day;
            }
                Setstate(state);
        }
        public DayApooitment_view(DateTime day,int state)
        {
            InitializeComponent();
            if (day.Year != date.Year)
            {
                Day.Text = day.Day.ToString();
                Day.Tag = day;
                this.Tag = day;
            }
            Setstate(state);
        }
        public void SetAction(EventHandler action)
        {
            this.Click += action;
            Day.Click += action;
        }
        public void SetDay(string day)
        {
            Day.Text= day;
        }
        public void Setstate(int state)//future:1  pressent:0 past:-1
        {
            switch (state)
            {
                case -1:
                    this.BackColor = SystemColors.Window;
                    break;
                case 0:
                    this.BackColor = SystemColors.Info;
                    break;
                case 1:
                    this.BackColor = SystemColors.GrayText;
                    break;
            }
        }
    }
}
