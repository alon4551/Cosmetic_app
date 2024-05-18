using Cosmetic_App.Custom_View;
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

namespace Cosmetic_App.Forms
{
    public partial class SelectApoitmentTime : Form
    {
        public bool Result = false;
        public Products Product { get; set; } = new Products();
        public List<Calender_Table> Temporery_Apooitments = null;
        public List<Calender_Table> Appooitments { get; set; }= new List<Calender_Table>();
        public int SelectedAppoitment ;

        Calender_Table Apooitment;
        public static string SelectDay { get; set; } = DateTime.Now.ToShortDateString();
        public DateTime SelectTime {get;set; }
        public string Selected_Worker { get; set; } = Workers.LogedWorker.Value.ToString();
        public DateTime Selected_Date { get;set; }
        public SelectApoitmentTime()
        {//loading information for a new appoitment
            InitializeComponent();
            worker_comboBox.Items.Clear();
            foreach(Workers worker in Workers.list)
            {
                worker_comboBox.Items.Add(worker.GetFullName() + " " + worker.Value);
            }
            bool find = false;
            for (int i = 0; i < worker_comboBox.Items.Count; i++)
                if (worker_comboBox.Items[i].ToString().Contains(Workers.LogedWorker.Value.ToString()))
                {
                    worker_comboBox.SelectedIndex = i;
                    find = true;
                    break;
                }
            if (find==false)
                worker_comboBox.SelectedIndex = 0;
            Reload();
        }
        public SelectApoitmentTime(int product,string client,Calender_Table Appoitment)
        {//loading information for an exsisting appoitment 
            InitializeComponent();
            foreach (Workers worker in Workers.list)
            {
                worker_comboBox.Items.Add(worker.GetFullName() + " " + worker.Value);
            }

            bool find = false;
            for (int i = 0; i < worker_comboBox.Items.Count; i++)
                if (worker_comboBox.Items[i].ToString().Contains(Workers.LogedWorker.Value.ToString()))
                {
                    worker_comboBox.SelectedIndex = i;
                    find=true;
                    break;
                }
            if (find == false)
                worker_comboBox.SelectedIndex = 0;
            Product.Grab(product);
            month_label.Text = $"קביעת תור ל{client} עבור {Product.getName()}";
            if (Appoitment != null)
            {
                Apooitment_Picker.Value = Appoitment.getSchedualeDate();
                starting_time.Value = Appoitment.GetApooitmentStartingTime();
                SelectedAppoitment = (int)Appoitment.Value;
                Apooitment = Appoitment;
            }
            else
            {
                Apooitment_Picker.Value = DateTime.Now;
                Appoitment = new Calender_Table();
            }
           
            ReloadEndTime();
          
            Reload();
        }
        public SelectApoitmentTime(int product, string client, List<Calender_Table> appoitments)
        {//loading information for an exisiting apooitments
            InitializeComponent();
            Product.Grab(product);
            month_label.Text = $"קביעת תור ל{client} עבור {Product.getName()}";
            Temporery_Apooitments = appoitments;
            ReloadEndTime();
            Reload();
        }
        private void SelectApoitmentTime_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Display()
        {//display the mouthly calender in the and daily calender
            calender.DisplayCalender(calender_layout, null,calender.ApooitmentSize,ClickOnDay);
            calender.DisplayWorkerAppoitments(dailycalender,Appooitments,DateTime.Parse(SelectDay));

        }
        private void ClickOnDay(object sender, EventArgs arg)
        {//changeing the selected date and redisplay calenders
            DateTime time = (DateTime)Input.GetTag(sender);
            Apooitment_Picker.Value = time;
            Reload();
        }
        private void Reload()
        {//reload the information and redisplay the information
            string worker_id = Workers.LogedWorker.Value.ToString() ;
            if(worker_comboBox.SelectedIndex !=-1)
                worker_id = Workers.list[worker_comboBox.SelectedIndex].Value.ToString();
            Appooitments = Calender_Table.GetAppoitments(Apooitment_Picker.Value.ToShortDateString(),worker_id);
            SelectDay = Apooitment_Picker.Value.ToShortDateString();
            calender.SetDisplayTime(new DateTime(Apooitment_Picker.Value.Year, Apooitment_Picker.Value.Month, Apooitment_Picker.Value.Day));
            label11.Text = Apooitment_Picker.Value.ToShortDateString();
            DateTime day = Apooitment_Picker.Value;
            DateTime time = starting_time.Value;
            starting_time.Value = new DateTime(day.Year,day.Month,day.Day,time.Hour,time.Minute,0);
            Display();
        }

    
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {//redisplay the information when date is change
            Reload();
        }

        private void ReloadEndTime()
        { // showing when treatment is going to end depand on starting time
            ending_time.Text = starting_time.Value.AddMinutes(double.Parse(Product.GetDuration())).ToShortTimeString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ReloadEndTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {//selecting starting time of appoitment
            DateTime Ending = starting_time.Value.AddMinutes(double.Parse(Product.GetDuration()));
            if(starting_time.Value.Subtract(DateTime.Now).Ticks<0)
            {
                DialogResult result = MessageBox.Show("זמן זה הוא בעבר, האם אתה בטוח שאתה רוצה לקבוע את הזמן הזה","",MessageBoxButtons.YesNo);
                if(result != DialogResult.Yes) 
                    return;
            }    
            foreach (Calender_Table apooitment in Appooitments)
            {
                if (!apooitment.IsDateTimeInEdge(Ending, true) && !apooitment.IsDateTimeInEdge(starting_time.Value, false))
                    if (apooitment.IsDateTimeWithInRange(Ending) || apooitment.IsDateTimeWithInRange(starting_time.Value))
                    {
                        MessageBox.Show("שעת הטיפול שנבחרה לא מתאימה, כבר קיים טיפול בטווח הזמנים הזה");
                        return;
                    }
            }
            if(Temporery_Apooitments!=null)
                foreach(Calender_Table apooitment in Temporery_Apooitments)
                {
                    if (!apooitment.IsDateTimeInEdge(Ending, true) && !apooitment.IsDateTimeInEdge(starting_time.Value, false))
                        if (apooitment.IsDateTimeWithInRange(Ending) || apooitment.IsDateTimeWithInRange(starting_time.Value))
                        {
                            MessageBox.Show("שעת הטיפול שנבחרה לא מתאימה, כבר קיים טיפול בטווח הזמנים הזה");
                            return;
                        }
                }
            SelectTime = starting_time.Value;
            Selected_Worker = Workers.list[worker_comboBox.SelectedIndex].Value.ToString() ;
            MessageBox.Show("זמן טיפול נבחר, חלון זה יסגר");
            Result = true;
            this.Close();
        }

        private void worker_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
