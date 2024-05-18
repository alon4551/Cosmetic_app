using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public partial class DayCalender : Form
    {//display appoitments in a day filter by worker

        public DayCalender()
        {
            InitializeComponent();
        }

        private void DayCalender_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Clear();
            foreach (Workers worker in Workers.list)
                comboBox1.Items.Add(worker.GetFullName() + "," + worker.Value);
            comboBox1.SelectedIndex = 0;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//redisplay appoitment in a worker
            if (comboBox1.SelectedIndex != -1)
            calender.Display_Apooitments(flowLayoutPanel1, Workers.list[comboBox1.SelectedIndex].Value.ToString());
            else
            calender.Display_Apooitments(flowLayoutPanel1, Workers.LogedWorker.Value.ToString());
        }
    }
}
