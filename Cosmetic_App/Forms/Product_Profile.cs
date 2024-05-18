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


namespace Cosmetic_App.Forms
{
    public partial class Product_Profile : Form
    {
        Products Products = new Products();
        public Product_Profile()
        {
            InitializeComponent();
        }
        public Product_Profile(bool IsTreatment)
        {//creating a new product / treatment
            InitializeComponent();
            Products.SetIsTreatment(IsTreatment);
        }
        public Product_Profile(int id)
        {//getting the product / treatment
            InitializeComponent();
            Products.Grab(id);
        }
        
        private void Product_Profile_Load(object sender, EventArgs e)
        {//loading information for selected product
            foreach (TextBox box in product_profile_layout.Controls.OfType<TextBox>())
            {
                box.Click += Input.TextChangeAfterError;
                box.Enter += Input.TextChangeAfterError;
            }
            count.Click += Input.TextChangeAfterError;
            count.Enter += Input.TextChangeAfterError;
                Load_Information();
        }
        public void Load_Information()
        {
            //loading of exsiting product
            StateLayout(Products.IsTreatment());
            if (Products.IsExist())
            {
                Input.Load_TextBox_Information(product_profile_layout, Products);
                StateProduct(Products.IsTreatment());
                
            }



        }
        public void StateLayout(bool state)
        {//changeing text depand of exisiting product is treatment or merchandice
           info_label.TextAlign = ContentAlignment.BottomRight;
           info_label.Dock = DockStyle.Fill;
            if (state)
            {
                label3.Text = "עריכת פרטי טיפול";
                info_label.Text = "אורך הטיפול (בדקות)";
            }
            else
            {
                label3.Text = "עריכת פרטי מוצר";
                info_label.Text = "כמות במחסן";
            }
        }
        public void StateProduct(bool state)
        {//changine visuals depand on exisiting product is treatment or merchandice 
            amount.Enabled = state;
            if (state)
                amount.Text = Products.Treatment.GetDuration();
            else
            {
                amount.Text = Products.getInventory().ToString();
                add_layout_table.Visible = true;
                label7.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//saveing product or treatment in DB
            bool result = true;
            foreach (TextBox box in product_profile_layout.Controls.OfType<TextBox>())
            {
                foreach (Label hint in product_profile_layout.Controls.OfType<Label>())
                {
                    if (hint.Tag == null) continue;
                    if (hint.Tag.ToString() == box.Name)
                    {
                        result &= Input.Verify(box, hint);
                        break;
                    }
                }
            }
            result &= Input.Verify(count, count_label);
            if (result)
            {
                if (SaveProduct())
                {
                    
                    MessageBox.Show("רשומה נרשמה בהצלחה");
                }
                else
                    MessageBox.Show("שגיאה");
                this.Close();
            }
        }
        public bool SaveProduct()
        {//saveing product or treatment in DB

            foreach (TextBox box in product_profile_layout.Controls.OfType<TextBox>())
                Products.SetColValue(box.Name, box.Text);
            if (Products.IsTreatment())
            {
                Products.SetInvetory(0);
                Products.Treatment.SetColValue("duration", int.Parse(amount.Text));
                Products.Treatment.SetColValue(0, Products.GetColValue(0));
            }
            else
                Products.SetInvetory(int.Parse(amount.Text));
            if (!Products.IsExist())
            {
                Products.SetColValue("id", Products.Value);
                if (Products.IsTreatment())
                    Products.Treatment.SetColValue("id", Products.Value);
            }
            else
                Products.SetInvetory(Products.getInventory() + int.Parse(count.Text));
            if (Products.Update())
            {
                Products.RealoadList();
                if (Products.IsTreatment())
                    Treatments.ReloadList();
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {//deleting treatment or product 
            if (Products.IsExist())
                if (DialogResult.Yes == MessageBox.Show("האם אתה בטוח שאתה מעוניין למחוק את רשומה, אחרי שתמחוק מידע המקושר למוצר ימחק בהתאם", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    if (Products.Delete())
                    {
                        MessageBox.Show("מוצר / טיפול נמחק מהמערכת");
                    }
                    else
                        MessageBox.Show("שגיאה");
                    this.Close();
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {//adding amout box
            try
            {
                count.Text = (int.Parse(count.Text) + 1).ToString();
            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {//reducing amout box
            try
            {
                    count.Text = (int.Parse(count.Text) -1).ToString();
            }
            catch { }
        }
    }
}
