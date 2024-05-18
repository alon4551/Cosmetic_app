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

namespace Cosmetic_App
{
    public partial class Manager_Verification : Form
    {
        public bool result;
        public Manager_Verification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//verify if acount is manager
            result = Workers.Verify_Account_Admin(id.Text, password.Text);
            if (result)
                MessageBox.Show("פרטי התחברות תקינים, אפשר להמשיך");
            else
                MessageBox.Show("פרטי התחברות אינם תקינים, לא ניתן להמשיך");
            this.Close();
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {//trigier verify account when user click the 'enter' key
            if(e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}
