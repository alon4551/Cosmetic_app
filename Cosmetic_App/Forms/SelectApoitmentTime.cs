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
        public List<Calender_Table> Appooitments { get; set; }= new List<Calender_Table>();
        public int SelectedAppoitment ;
        public static string SelectDay { get; set; } = DateTime.Now.ToShortDateString();
        public DateTime SelectTime {get;set; }
        public SelectApoitmentTime()
        {
            InitializeComponent();
            Reload();
        }
        public SelectApoitmentTime(int product,string client,int Appoitment)
        {
            InitializeComponent();
            Product.Grab(product);
            month_label.Text = $"קביעת תור ל{client} עבור {Product.getName()}";
            starting_time.Value = DateTime.Now;
            SelectedAppoitment = Appoitment;
            ReloadEndTime();
            Reload();
        }
        private void SelectApoitmentTime_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Display()
        {
            calender.DisplayCalender(calender_layout, null);
            calender.DisplayWorkerAppoitments(dailycalender,Appooitments,DateTime.Parse(SelectDay));
        }
        private void Reload()
        {
            Appooitments = Calender_Table.GetAppoitments(Apooitment_Picker.Value.ToShortDateString());
            SelectDay = Apooitment_Picker.Value.ToShortDateString();
            calender.SetDisplayTime(Apooitment_Picker.Value);
            label11.Text = Apooitment_Picker.Value.ToShortDateString();
            DateTime day = Apooitment_Picker.Value;
            DateTime time = starting_time.Value;
            starting_time.Value = new DateTime(day.Year,day.Month,day.Day,time.Hour,time.Minute,0);
            Display();
        }

       
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void ReloadEndTime()
        {
            ending_time.Text = starting_time.Value.AddMinutes(double.Parse(Product.GetDuration())).ToShortTimeString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ReloadEndTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            SelectTime = starting_time.Value;
            MessageBox.Show("זמן טיפול נבחר, חלון זה יסגר");
            Result = true;
            this.Close();
        }
    }
}
