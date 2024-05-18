using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class Schedule : Form
    {
        Income order ;
        List<Person> Clients;
        bool saved = false;
        List<Cart> Shoping_Cart = new List<Cart>();
        List<Calender_Table> appoitments=new List<Calender_Table>();
        List<Products> Treatments,Filter = new List<Products>();
        List<Cart_Schedule_View> shoping_cart = new List<Cart_Schedule_View>();
        public Schedule()
        {

            InitializeComponent();
            order = new Income();
            order.SetWorker(Workers.LogedWorker.Value.ToString());
            order.SetClient("0");
            order.SetColValue("total", 0);
           
            order.Insert();
            textBox1.Text = order.Value.ToString();
            Featch_Information();
        }
        private void Schedule_Load(object sender, EventArgs e)
        {
           
        }
        public void Reload()
        {//reloading order information from DB 
            appoitments = order.GetApooitments();
            Featch_Information();
            Load_ShopingCart();
            Load_Client_List();
        }
        public async void Featch_Information()
        {//featching informaiton from DB
            Clients = Person.GetAllPeople();
            appoitments = Calender_Table.GetAppoitments((int)order.Value);
            Treatments = Products.GetAllTreatments();
            Load_Client_List();
            Load_Treatment_List(Treatments);
        }
        public void Load_ShopingCart()
        {//loading appoitment of order
            shoping_cart_layout.Controls.Clear();
            shoping_cart.Clear();
            foreach(Cart c in Shoping_Cart)
            {
                Cart_Schedule_View view = new Cart_Schedule_View(c, SetDate, Cancel,SetWorker);
                foreach(Calender_Table apooitment in appoitments)
                    if (apooitment.GetColValue("cart_id").ToString() == c.Value.ToString())
                    {
                        view.SetTime(apooitment.getSchedualeTreatment());
                        view.SetWorkerName(apooitment.getWorkerName());
                    }
                shoping_cart_layout.Controls.Add(view);
                shoping_cart.Add(view);
            }
        }
        public void Load_Treatment_List(List<Products> list)
        {//loading treatment list names
            comboBox2.Items.Clear();
            foreach(Products p in list)
            {
                comboBox2.Items.Add(p.getName() + "," + p.GetPrice());
            }
        }
        public void CLick_Treatment(object sender, EventArgs e)
        {//adding treatment / product to shoping cart
            Products p = (Products)Input.GetTag(sender);
            if (p == null) p = (Products)sender;
            Cart c = new Cart((int)order.Value, p);
            c.SetColValue(Database_Names.Cart_Columes[3], 1);
            c.Insert();
            Shoping_Cart.Add(c);
            SetDate(c, null);

        }
        public string GetClientId()
        {//return clientd Id from order
            
            foreach(Person person in Clients)
            {
                if (person.GetColValue(0).ToString() == "0") continue;
                if (comboBox1.Text.Contains(person.GetColValue(0).ToString()))
                    return person.GetColValue(0).ToString();
            }
            return "";
        }


        public void Load_Client_List()
        {//loading client list
            comboBox1.Items.Clear();
            foreach(Person person in Clients) {
                comboBox1.Items.Add(person.GetFullName() +','+person.GetColValue(0));
            }
        }
        public Cart_Schedule_View GetView(Cart cart)
        {//getting cart information from custom view
            Cart c;
            foreach (Cart_Schedule_View view in shoping_cart_layout.Controls.OfType<Cart_Schedule_View>())
            {
                c = (Cart)view.Tag;
                if (c.Value.ToString() == cart.Value.ToString())
                    return view;
            }
            return null;
        }
        public void SetWorker(object sender, EventArgs e)
        {// setting worker to selected appoitment
            Cart c = (Cart)Input.GetTag(sender);
            foreach(Calender_Table apooitment in appoitments)
            {
                if (apooitment.GetColValue(Database_Names.Calender_Columes[3]).ToString() == c.Value.ToString()) {
                    apooitment.setWorker(Workers.LogedWorker.Value.ToString());
                    apooitment.Update();
                    return;
                }
            }
        }
       public void SetDate(object sender, EventArgs e)
        {//schdualing appoitment
            Cart c = (Cart)Input.GetTag(sender);
            if (c == null) c = (Cart)sender;
            Calender_Table selected_apooitment = null;
            if (comboBox1.Text =="")
            {
                MessageBox.Show("עלייך לבחור לקוח בבקשה");
                return;
            }

            foreach(Calender_Table apooitment in appoitments)
            {
                if (apooitment.GetColValue(Database_Names.Calender_Columes[3]).ToString()==c.Value.ToString())
                {
                    selected_apooitment=apooitment;
                    break;
                }
            }
            using (SelectApoitmentTime select = new SelectApoitmentTime(c.GetProductId(),comboBox1.Text,selected_apooitment))
            {
                select.ShowDialog();
                bool found = false;
                if (select.Result)
                {
                    foreach(Calender_Table apooitment in appoitments)
                        if(c.Value.ToString() == apooitment.GetColValue("cart_id").ToString())
                        {
                            apooitment.SetColValue("day",select.SelectTime.ToShortDateString());
                            apooitment.SetColValue("start", select.SelectTime.ToShortTimeString());
                            apooitment.setWorker(select.Selected_Worker);
                            apooitment.SetColValue(Database_Names.Calender_Columes[7], select.SelectTime);
                            apooitment.Delete();
                            apooitment.Insert();
                            found = true;
                            Reload();
                            return;
                        }
                    if(found == false)
                    {
                        string worker_id=select.Selected_Worker;
                        Calender_Table apooitmnet = new Calender_Table(worker_id, GetClientId(), c.Value.ToString(), order.Value.ToString(), select.SelectTime.ToShortDateString(), select.SelectTime.ToShortTimeString());
                        apooitmnet.Insert();
                    }
                }
            Reload();
            }
        }

        private void new_client_btn_Click(object sender, EventArgs e)
        {//createing new person process
            App_Process.NewPerson(this);
            Reload();

        }

        private void save_bbtn_Click(object sender, EventArgs e)
        {//saving order in DB
            bool result = true;
            List<Calender_Table> list = order.GetApooitments();
            if (list != null)
            {
                if (list.Count != shoping_cart.Count)
                    result = false;
                else
                {
                    result = true;
                }
            }
            else
                result = false;
            if (result == false)
            {
                MessageBox.Show("עלייך לוודא כי נקבעו מתאימים לטיפול");
                return;
            }
            else
            {
                int total = 0;
                order.SetClient(GetClientId());
                foreach(Cart c in Shoping_Cart)
                {
                    total += c.GetPrice();
                }
                order.SetColValue(Database_Names.Income_Columes[1], total);
                if (order.Save())
                {
                    saved = true;
                    MessageBox.Show("תהליך הושלם בהצלחה");
                    this.Close();
                }
               
            }

        }

        private void Schedule_FormClosing(object sender, FormClosingEventArgs e)
        {//closeing form and not saveing the order
            if (saved == false)
                if (order.Delete())
                    MessageBox.Show("הזמנה לא נשמרה");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//changeing clinet 
            if (comboBox1.SelectedIndex != -1)
                order.SetClient(Clients[comboBox1.SelectedIndex].Value.ToString());
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {// closeing form and not saveing the order
            Schedule_FormClosing(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//not using the function
            if (comboBox2.SelectedIndex != -1)
                label7.Text = Products.AllTreatments[comboBox2.SelectedIndex].getName() + ", " + Products.AllTreatments[comboBox2.SelectedIndex].GetPrice();
            else
                label7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {//adding treatment to cart
            if(comboBox2.SelectedIndex!=-1)
                CLick_Treatment(Products.AllTreatments[comboBox2.SelectedIndex], null);
        }

        public void Cancel(object sender, EventArgs e)
        {//canceling one for the items
            Cart c =(Cart)Input.GetTag(sender);
            Shoping_Cart.Remove(c);
            c.Delete();
            foreach (Calender_Table apooitment in appoitments)
            {
                if (apooitment.GetColValue(3).ToString() == c.Value.ToString())
                {
                    apooitment.Delete();
                    appoitments.Remove(apooitment);

                    break;
                }
            }
            Reload();
        }
        
    }
}
