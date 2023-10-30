using Cosmetic_App.Tables;
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
    public partial class ClockShifts : Form
    {
        Timer timer =new Timer();
        Shifts Shift;
        public ClockShifts()
        {
            InitializeComponent();
        }

        private void ManageShifts_Load(object sender, EventArgs e)
        {
            date_label.Text = DateTime.Now.ToShortDateString();
            Clock_Label.Text = DateTime.Now.ToLongTimeString();
            Load_Information();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.t_Tick);
            timer.Start();

        }
        private void Load_Information()
        {
            inform_user_label.Text = "אנא הכנס תעודת זהות ולחץ חיפוש כדי להמשיך בתהליך";
            interaction_layout.Enabled = false;
            clockin_button.Enabled = true; 
            clockout_button.Enabled=true;
        }
        private void t_Tick (object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
                time += "0" + hh;
            else
                time += hh;
            time += ":";
            if (mm < 10)
                time += "0" + mm;
            else
                time += mm;
            time += ":";

            if (ss < 10)
                time += "0" + ss;
            else
                time += ss;
            //update label
            Clock_Label.Text = time;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Input.Verify(id, inform_user_label))
            {
                interaction_layout.Enabled = true;
                Shift = Shifts.GetShift(DateTime.Now.ToShortDateString(), id.Text);
                if (Shift == null)
                    SetButtons(true);
                else if(Shift.IsShiftOver())
                    SetButtons(false);
                else
                {
                    MessageBox.Show("אתה כבר עבדת במשמרת היום, אם יש בעיה אנא גש למנהל שישנה את פרטי המערכת ");
                }
            }


        }
        private void SetButtons(bool Shift_State)
        {
            clockin_button.Enabled=Shift_State; 
            clockout_button.Enabled=!Shift_State;
        }

        private void clockin_button_Click(object sender, EventArgs e)
        {
            if (Shifts.ClockIn(id.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()))
                MessageBox.Show("ok");
            else
                MessageBox.Show("ohh no");
            Load_Information();
        }

        private void clockout_button_Click(object sender, EventArgs e)
        {
            if (Shifts.ClockOut(id.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()))
                MessageBox.Show("ok");
            else
                MessageBox.Show("ohh no");
            Load_Information();
        }

        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button3_Click(null, null);
        }
    }
}
