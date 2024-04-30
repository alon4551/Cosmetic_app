using Cosmetic_App.Tables;
using iText.Layout.Borders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Forms
{
    public partial class CreatePassword : Form
    {
        private string id;
        public CreatePassword(string id)
        {
            InitializeComponent();
            this.id = id;   
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool result = Input.Verify(password, label3);
                result&=Input.Verify(repassowrd,label5);
            if (password.Text != repassowrd.Text)
            {
                MessageBox.Show("תכתוב את הסיסמאות זהות בשני השדות");
                return;
            }
            if (result)
            {
                Workers worker = new Workers();
                worker.SetColValue(0, id);
                worker.SetColValue("password", password.Text);
                worker.SetColValue("admin", false);
                if (worker.Update())
                {
                    MessageBox.Show("אדם נכנס למערכת עובדים");
                    this.Close();
                }
                else
                    MessageBox.Show("שגיאה");
            }
           
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
            label3.Text = "";           
        }

        private void repassowrd_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
            label5.Text = "";
        }
    }
}
