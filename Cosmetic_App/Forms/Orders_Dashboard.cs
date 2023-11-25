using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class Orders_Dashboard : Form
    {
        List<Income> AllOrders = Income.GrabAll(), UrjentOrders,filter_list = new List<Income>();
        Income SelectedOrder;
        Workers Worker;
        bool filter = false, urjent_filter = true;
        public Orders_Dashboard(string worker_id)
        {
            InitializeComponent();
            SortOrders();
            Load_List(UrjentOrders);
            Worker = new Workers(worker_id);
        }
        public void Reload()
        {
            AllOrders = Income.GrabAll();
            SortOrders();
           
        }
        public void SortOrders()
        {
            UrjentOrders = new List<Income>();
            foreach(Income income in AllOrders) 
            {
                if(!income.IsShopingCartScheduale())
                {
                    UrjentOrders.Add(income);
                }
            }
        }

        private void AllOrder_Radio_CheckedChanged(object sender, EventArgs e)
        {
            filter = false;
            search_id_box.Text = "";
             urjent_filter= false;
            Load_List(AllOrders);
            ClearOrderInformation();
        }

        private void UrjentOrder_Radio_CheckedChanged(object sender, EventArgs e)
        {
            filter = false;
            search_id_box.Text = "";
            urjent_filter = true;
            Load_List(UrjentOrders);
            ClearOrderInformation();
        }
        private void ClearOrderInformation()
        {
            Cart_View_Box.Items.Clear();
            Input.Clear_Textbox_Information(tableLayoutPanel7);
            Input.Clear_Textbox_Information(tableLayoutPanel8);

        }
        private void Order_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter)
                    SelectedOrder = filter_list[Order_list.SelectedIndex];
            else
            {
                if (urjent_filter)
                    SelectedOrder = UrjentOrders[Order_list.SelectedIndex];
                else
                    SelectedOrder = AllOrders[Order_list.SelectedIndex];
            }
            Load_Order_Information(SelectedOrder);
        }

        public void Load_Order_Information(Income order)
        {
            label2.Text = $"הזמנה מספר {order.Value}";
            customer_name_box.Text = order.GetClientName();
            worker_name_box.Text = order.GetWorkerName();
            date_box.Text = order.GetPurchaceDate();
            total_box.Text = $"{order.GetTotal()} ש''ח";
            Cart_View_Box.Items.Clear();
            foreach (Cart c in order.GetCart())
            {
                ListViewItem item = new ListViewItem();
                item.Tag = c;
                item.Text = c.GetProductName();
                item.SubItems.Add(c.GetAmount().ToString());
                if (c.Product.IsTreatment())
                {
                    if (order.IsTreatmentSchedule(c))
                    {
                        item.SubItems.Add("נקבע טיפול");
                    }
                    else
                    {
                        item.SubItems.Add("טרם נקבע טיפול");
                    }
                }
                else
                {
                    item.SubItems.Add("נרכש");
                }
                Cart_View_Box.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(Order_Edit order = new Order_Edit((int)SelectedOrder.Value))
            {
                this.Hide();
                order.ShowDialog();
                Reload();
                Load_List(AllOrders);
                this.Show();
                SelectOrder((int)SelectedOrder.Value);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = App_Process.NewOrder(Worker.Value.ToString());
            Reload();
            Load_List(AllOrders);
            SelectOrder(id);
        }

        private void Cart_View_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cart_View_Box.SelectedItems.Count != 1) return;
            Cart item = (Cart)Cart_View_Box.SelectedItems[0].Tag;
            if (SelectedOrder.IsTreatmentSchedule(item))
            {
                Calender_Table appoitment = SelectedOrder.GetAppoitment((int)item.Value);
                treatment_date_box.Text = appoitment.GetDate();
                worker_treatment_box.Text = appoitment.getWorkerName();
                treatment_time_box.Text = appoitment.GetTime();
            }
            else
            {
                treatment_date_box.Text = "";
                worker_treatment_box.Text = "";
                treatment_time_box.Text = "";
            }
        }

        private void Search_Order_By_Date_Click(object sender, EventArgs e)
        {
            filter_list.Clear();
            filter = true;
            foreach (Income income in AllOrders)
                if (income.GetPurchaceDate().Contains(dateTimePicker1.Value.ToShortDateString()))
                    filter_list.Add(income);
            Load_List(filter_list);
        }

        private void search_id_box_TextChanged(object sender, EventArgs e)
        {
            ClearOrderInformation();
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ClearOrderInformation();
        }

        private void Search_Oreder_By_Id_Click(object sender, EventArgs e)
        {
            filter_list.Clear();
            if (search_id_box.Text != "")
            {
                filter = true;
                foreach (Income income in AllOrders)
                    if (income.Value.ToString().Contains(search_id_box.Text))
                        filter_list.Add(income);
                Load_List(filter_list);
                if (filter_list.Count == 1)
                {
                    SelectedOrder = filter_list[0];
                    Load_Order_Information(SelectedOrder);
                }
            }
        }

        private void SelectOrder(int id)
        {
            foreach(Income order in AllOrders)
            {
                if((int)order.Value == id)
                {
                    SelectedOrder = order;
                    Load_Order_Information(SelectedOrder);
                    break;
                }
            }
        }
        public void Load_List(List<Income> list)
        {
            Order_list.Items.Clear();
            int i = 0;
            foreach(Income income in list)
            {
                Order_list.Items.Add($"הזמנה מספר {income.Value}");
            }
        }
    }
}
