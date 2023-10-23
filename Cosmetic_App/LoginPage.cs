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
        {
            bool result = true;
            result &= Input.Verify(id, label3);
            result &= Input.Verify(password, label4);
            if(result){
                if (Workers.Verify_Account(id.Text, password.Text))
                    MessageBox.Show("Good");
                else
                    MessageBox.Show("Bad");
            }
            
        }

        private void id_Click(object sender, EventArgs e)
        {
            Input.Reset(id);
        }

        private void password_Click(object sender, EventArgs e)
        {
            Input.Reset(password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gmail_helper.SendMail("alon4551@gmail.com", "this was a secsees");
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
