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
            label1.Tag = day;
            this.Tag = day; 
            treatments_label.Tag = day;
            tablelayout.Tag = day;
        }
        public void SetTag(object  tag)
        {
            label1.Tag = tag;
            treatments_label.Tag=tag;
            tablelayout.Tag=tag;
            this.Tag= tag;

        }
        public void SetMessage(string message)
        {
            treatments_label.Text = message;
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
        public void SetAction(EventHandler handler)
        {
            treatments_label.Click += handler;
            label1.Click += handler;
            tablelayout.Click += handler;
        }


    }
}
