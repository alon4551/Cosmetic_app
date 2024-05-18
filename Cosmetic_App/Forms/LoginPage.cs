using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {//verify infputs are correct and log's in to the application
            bool result = true;
            result &= Input.Verify(id, label3);
            result &= Input.Verify(password, label4);
            if(result){
                if (Workers.Verify_Account(id.Text, password.Text))
                {
                    Workers.LogedWorker = new Workers(id.Text);
                    using (HomePage homepage = new HomePage())
                    {
                        this.Hide();
                        homepage.ShowDialog();
                        this.Show();
                    }

                }
                else
                {
                    MessageBox.Show("פרטי התחברות אינם תקינים");
                }
            }
            
        }

        private void id_Click(object sender, EventArgs e)
        {
            //warning reset after changeing the input
            Input.Reset(id);
        }

        private void password_Click(object sender, EventArgs e)
        {
            //warning reset after changeing the input
            Input.Reset(password);
        }

        private void button2_Click(object sender, EventArgs e)
        {//application shows if 
            if (id.Text != "")
                App_Process.ForgetPassword(id.Text);
            else
                MessageBox.Show("אנא תכתוב בשדה הראשון ת.ז.");
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {//if user hit 'enter' key it process as login 
            if (e.KeyCode == Keys.Enter)
                Login_Click(null, null);
        }
    }
}
