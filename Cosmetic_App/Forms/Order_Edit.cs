using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Cosmetic_App.Forms
{
    public partial class Order_Edit : Form
    {
        public Income order = new Income();
        public Cart Item = new Cart();
        public List<Workers> workers = Workers.GrabAll();
        public Calender_Table Apooitment = new Calender_Table();
        public Order_Edit(string id)
        {
            InitializeComponent();
        }
        public Order_Edit(int id)
        {
            order = new Income(id);
            InitializeComponent();
        }
        public void Reload()
        {
            order.Relaod();
            Load_Information();
        }
        private void Order_Dashbord_Load(object sender, EventArgs e)
        {
            Load_Worker_List();
            Load_Information();
        }
        public void Load_Worker_List()
        {
            worker_list.Items.Clear();
            foreach(Workers worker in workers)
                worker_list.Items.Add(worker.GetFullName());
        }
       
        public void Load_Information()
        {
            order_id_box.Text = order.Value.ToString();
            Client_box.Text = order.GetClientName();
            Cart_list.Items.Clear();
            foreach (Cart cart in order.GetCart())
            {
                ListViewItem item = new ListViewItem(cart.Product.getName());
                item.Tag = cart.Value;
                if (cart.Product.IsTreatment())
                {
                    if (order.IsTreatmentSchedule(cart))
                        item.SubItems.Add("טיפול נקבע");
                    else
                        item.SubItems.Add("טיפול טרם נקבע במערכת");
                }
                else
                {
                    item.SubItems.Add("נרכש");
                }
                 Cart_list.Items.Add(item);
            }
        }
        private void Cart_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cart_list.SelectedItems.Count !=1) return;
            int id = (int)Cart_list.SelectedItems[0].Tag;
            if (order.IsTreatmentSchedule(id))
            {
                Apooitment = order.GetAppoitment(id);
            }
            else
            {
                Apooitment = new Calender_Table();
                Apooitment.SetCartItem(id);
            }
            worker_list.ResetText();
            Load_Product_Information();


        }
        public void Load_Product_Information()
        {
            Item = Apooitment.GetItem();
            if (!Item.Product.IsTreatment())
            {
                Treatment_layout_info.Visible = false;
                label4.Text = "מוצר זה נרכש";
                
            }
            else
            {
                worker_list.Text = Apooitment.getWorkerName();
                Treatment_layout_info.Visible = true;
                label4.Text = "פרטים על הטיפול";
                treatment_name.Text = Item.GetProductName();
                treatment_duration.Text = Item.Product.GetDuration() + " דקות";
                if (order.IsTreatmentSchedule((int)Item.Value))
                {
                    worker_list.SelectedItem = Apooitment.getWorkerName();
                    
                }
                scheduale_box.Text = Apooitment.getSchedualeTime();
                

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Calender_Table appoitmentId = order.GetAppoitment((int)Item.Value);
            using (SelectApoitmentTime Select = new SelectApoitmentTime((int)Item.Product.Value, order.GetClientName(),appoitmentId))
            {
                Select.ShowDialog();
                if (Select.Result)
                { 
                    Apooitment.SetSchedualeTime(Select.SelectTime);
                    Load_Product_Information();
                }
            }
        }

        private void worker_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apooitment.setWorker(workers[worker_list.SelectedIndex].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = Apooitment.IsShedualeTimeExisit();
            if(result && worker_list.SelectedItem == "")
            {
                MessageBox.Show("עלייך לקבוע זמן טיפול ולבחור עובד-");
                return;
            }
            if (!result)
            {
                MessageBox.Show("עלייך לקבוע זמן לטיפול");
                return;
            }
            if(worker_list.SelectedItem == "")
            {
                MessageBox.Show(" עלייך לבחור עובד ");
                return;
            }
            Apooitment.setOrder(order.Value);
            Apooitment.setClient(order.GetClient());
            if (Apooitment.Update())
            {
                MessageBox.Show("טיפול נקבע");
                Reload();
            }
            else
                MessageBox.Show("error");
        }
    }
}
