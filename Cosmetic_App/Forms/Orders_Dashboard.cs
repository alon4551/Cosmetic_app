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
        List<Income> UnPaid = Income.getIncomes(false),Paid=Income.getIncomes(true),filter_list = new List<Income>();
        Income SelectedOrder;
        Workers Worker;
        bool filter = false, paid = true;
        public Orders_Dashboard(string worker_id)
        {
            InitializeComponent();
            Load_List();
            if (worker_id == "")
                worker_id = "0";
            Worker = new Workers(worker_id);
                
        }
        public void Reload()
        {
            UnPaid = Income.getIncomes(false);
            Paid = Income.getIncomes(true);
            Load_List();
            if(Order_list.Items.Count > 0)
                Order_list.SelectedIndex = 0;
            else
                ClearOrderInformation();
           
        }


        private void ClearOrderInformation()
        {
            
            Cart_View_Box.Items.Clear();
            Input.Clear_Textbox_Information(tableLayoutPanel7);

        }
        private void Order_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter)
                    SelectedOrder = filter_list[Order_list.SelectedIndex];
            else
            {
                if (paid)
                    SelectedOrder = Paid[Order_list.SelectedIndex];
                else
                    SelectedOrder = UnPaid[Order_list.SelectedIndex];
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
            checkBox1.Checked = order.IsPaid();
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
            bool tempPaid = paid,tempfilter=filter;
            int tempIndex = Order_list.SelectedIndex,tempClient=comboBox1.SelectedIndex;
            using(Order_Edit order = new Order_Edit((int)SelectedOrder.Value))
            {
                this.Hide();
                order.ShowDialog();
                this.Show();
               
                if(tempPaid)
                    paid_radio_btn.Checked = true;
                else
                    unpoaid_radio_btn.Checked = true;
                if (filter)
                    comboBox1.SelectedIndex = tempClient;
                Order_list.SelectedIndex = tempIndex;
            }
            Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = App_Process.NewOrder(Worker.Value.ToString(),this);
            Reload();
            SelectOrder(id);
        }

        private void Cart_View_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cart_View_Box.SelectedItems.Count != 1) return;
            Cart item = (Cart)Cart_View_Box.SelectedItems[0].Tag;
            if (SelectedOrder.IsTreatmentSchedule(item))
            {
                Calender_Table appoitment = SelectedOrder.GetAppoitment((int)item.Value);

            }
            else
            {
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("האם בטוח שאתה רוצה למחוק את ההזמנה?");
            if (SelectedOrder.Delete())
                MessageBox.Show("הזמנה נמחקה");
            filter = false;
            unpoaid_radio_btn.Checked = true;
            Reload();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(Store store =new Store((int)SelectedOrder.Value))
            {
                store.ShowDialog();
                Reload();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                string id = Person.Clients[comboBox1.SelectedIndex-1].GetColValue(0).ToString();
                filter_list = Income.getIncomes(id, paid);
                filter = true;
                Load_List();
            }
            else
            {
                filter = false;
                Load_List();
            }

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (paid_radio_btn.Checked)
            {
                paid = true;

            }
            Load_List();
        }

        private void upoaid_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (unpoaid_radio_btn.Checked)
            {
                paid = false;
                
            }
            Load_List();
        }

        private void Orders_Dashboard_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("אף לקוח");
            foreach(Person person in Person.Clients)
                comboBox1.Items.Add(person.GetFullName() + "," + person.GetColValue(0));

        }


        private void SelectOrder(int id)
        {
            List<Income> list;
            if (filter)
                list = filter_list;
            else
            {
                if (paid)
                    list = Paid;
                else
                    list = UnPaid;
            }
            for(int i = 0;i<list.Count;i++)
            {
                if ((int)list[i].Value == id)
                {
                    if(Order_list.Items.Count>i)
                    Order_list.SelectedIndex = i;
                    /*SelectedOrder = AllOrders[i];
                    Load_Order_Information(SelectedOrder);*/
                    break;
                }
            }
            
        }
        public void Load_List()
        {

            List<Income> list=new List<Income>();
            if (filter)
            {
                string id = Person.Clients[comboBox1.SelectedIndex - 1].GetColValue(0).ToString();
                filter_list = Income.getIncomes(id, paid);
                list = filter_list;
            }
            else
            {
                if (paid)
                    list = Paid;
                else
                    list = UnPaid;
            }
            Order_list.Items.Clear();
            int i = 0;
            foreach(Income income in list)
            {
                Order_list.Items.Add($"הזמנה מספר {income.Value}");
            }
        }
    }
}
