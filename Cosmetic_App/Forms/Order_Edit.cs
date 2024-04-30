using Cosmetic_App.Custom_View;
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
using System.Threading;
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
        List<Products> Treatments_list = Products.GetAllTreatments(), Filter = new List<Products>();

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

     
        public void AddButton(object sender, EventArgs e)
        {
            Products item =(Products)Input.GetTag(sender);
            order.AddItem(item);
            Load_Information();
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
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                Treatment_layout_info.Visible = false;
                label4.Text = "מוצר זה נרכש";
                textBox1.Text = Item.GetAmount().ToString();
                refundBtn.Enabled = true;
                schdualeBtn.Enabled = false;
                tableLayoutPanel4.Enabled = true ;
                tableLayoutPanel3.Enabled = false;

            }
            else
            {

                tabControl1.SelectedTab = tabControl1.TabPages[0];
                refundBtn.Enabled = false;
                schdualeBtn.Enabled = true;
                tableLayoutPanel3.Enabled = true;
                tableLayoutPanel4.Enabled = false;
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
                    for(int i=0;i< Workers.list.Count;i++)
                    {
                        if (Workers.list[i].Value.ToString() == Select.Selected_Worker)
                        {
                            worker_list.SelectedIndex = i;
                        }
                    }
                    SechdualeApoitment();
                    Load_Product_Information();
                }
            }
        }

        private void worker_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apooitment.setWorker(workers[worker_list.SelectedIndex].Value.ToString());
        }
        private void SechdualeApoitment()
        {
            bool result = Apooitment.IsShedualeTimeExisit();
            if (result && worker_list.SelectedItem == "")
            {
                MessageBox.Show("עלייך לקבוע זמן טיפול ולבחור עובד-");
                return;
            }
            if (!result)
            {
                MessageBox.Show("עלייך לקבוע זמן לטיפול");
                return;
            }
            if (worker_list.SelectedItem == "")
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
        private void button1_Click(object sender, EventArgs e)
        {
            int amount=int.Parse(textBox1.Text);
            try
            {
                amount = int.Parse(textBox2.Text);
            }
            catch {
                MessageBox.Show("אנא תכתוב בשדה הרצוי מספר שלם");
                return;
            }
            if (amount > int.Parse(textBox1.Text)||amount<0)
            {
                MessageBox.Show($"אנא תכתוב מספר בין 0 ל{textBox1.Text}");
                return;
            }
            using (Manager_Verification verification = new Manager_Verification())
            {
                verification.ShowDialog();
                if (!verification.result)
                    return;
            }
            Products p = Products.GetProduct((int)Item.GetColValue("product_id"));
            p.returnInventory(amount);
            bool result;
            if (amount == int.Parse(textBox1.Text))
                result= Item.Delete();
            else
            {
                Item.Reduce(amount);
                result = Item.Update();
            }
            if (result)
            {
                Income refund = new Income(),original = new Income((int)Item.GetColValue("order_id"));
                refund.SetColValue(1, amount * -1 * Item.GetPrice());
                refund.SetColValue(2, original.GetColValue(2));
                refund.SetColValue(3, Workers.LogedWorker.GetColValue(0));
                refund.SetColValue(4, original.GetColValue(4));
                refund.SetColValue(5, true);
                refund.Row.Columes.RemoveAt(refund.Row.Columes.Count-1);
                order.SetColValue("total",order.GetTotal() - amount * Item.GetPrice());
                if (order.Update())
                {
                    using (SaveFileDialog browse = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true, FileName = $"זיכוי{refund.Value}.pdf" })
                    {
                        refund.SetColValue("total", refund.GetTotal() * -1);
                        if(browse.ShowDialog() == DialogResult.OK)
                            refund.CreateRefund(browse.FileName);
                    }
                    p.Update();
                    Products.Reload();
                    MessageBox.Show("זיכוי עבר בהצלחה");
                }
                else
                    MessageBox.Show("שגיאה");
            }
            Reload();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cart_list_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                order.RemoveItem(Cart_list.SelectedIndices[0]);
            }
        }

       

    }
}
