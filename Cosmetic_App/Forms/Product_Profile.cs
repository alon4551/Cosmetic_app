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
        Products Product = new Products();
        public Product_Profile()
        {
            InitializeComponent();
        }
        public Product_Profile(bool IsTreatment)
        {
            InitializeComponent();
            Product.SetIsTreatment(IsTreatment);
        }
        public Product_Profile(int id)
        {
            InitializeComponent();
            Product.Grab(id);
        }
        
        private void Product_Profile_Load(object sender, EventArgs e)
        {
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

            StateLayout(Product.IsTreatment());
            if (Product.IsExist())
            {
                Input.Load_TextBox_Information(product_profile_layout, Product);
                StateProduct(Product.IsTreatment());
                
            }



        }
        public void StateLayout(bool state)
        {
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
        {
            amount.Enabled = state;
            if (state)
                amount.Text = Product.Treatment.GetDuration();
            else
            {
                amount.Text = Product.getInventory().ToString();
                add_layout_table.Visible = true;
                label7.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("good");
                else
                    MessageBox.Show("ohh ohh");
                this.Close();
            }
        }
        public bool SaveProduct()
        {

            foreach (TextBox box in product_profile_layout.Controls.OfType<TextBox>())
                Product.SetColValue(box.Name, box.Text);
            if (Product.IsTreatment())
            {
                Product.SetInvetory(0);
                Product.Treatment.SetColValue("duration", int.Parse(amount.Text));
            }
            else
                Product.SetInvetory(int.Parse(amount.Text));
            if (!Product.IsExist())
            {
                Product.SetColValue("id", Product.Value);
                if (Product.IsTreatment())
                    Product.Treatment.SetColValue("id", Product.Value);
            }
            else
                Product.SetInvetory(Product.getInventory() + int.Parse(count.Text));
           return Product.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Product.IsExist())
                if (DialogResult.Yes == MessageBox.Show("האם אתה בטוח שאתה מעוניין למחוק את רשומה, אחרי שתמחוק מידע המקושר למוצר ימחק בהתאם", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    if (Product.Delete())
                    {
                        MessageBox.Show("מוצר / טיפול נמחק מהמערכת");
                    }
                    else
                        MessageBox.Show("error");
                    this.Close();
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                count.Text = (int.Parse(count.Text) + 1).ToString();
            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                    count.Text = (int.Parse(count.Text) -1).ToString();
            }
            catch { }
        }
    }
}
