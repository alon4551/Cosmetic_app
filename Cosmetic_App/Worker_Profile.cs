using Cosmetic_App.Audit;
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
    public partial class Worker_Profile : Form
    {
        Workers Worker = new Workers();
        public Worker_Profile()
        {
            InitializeComponent();
        }
        public Worker_Profile(string id)
        {
            InitializeComponent();
            Worker.Grab(id);
        }
        public void Load_Personal_Information()
        {
            if (!Worker.Person.IsEmpty())
            {
                id.Text = Worker.Person.GetColValue("id").ToString();
                fullname.Text = Worker.Person.GetFullName();
                phone.Text = Worker.Person.GetColValue("phone").ToString();
                email.Text=Worker.Person.GetColValue("email").ToString();
                birthday.Text = Worker.Person.GetColValue("birthday").ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PersonFile profile;
            if(Worker.Person.IsEmpty())
                profile = new PersonFile();
            else
                profile = new PersonFile(Worker.Person.GetColValue(0).ToString());
            profile.ShowDialog();
            Reload(profile.GetId());
        }
        private void Reload(string id)
        {
            Worker.Grab(id);
            Load_Personal_Information();
        }
        private void Worker_Profile_Load(object sender, EventArgs e)
        {
            Load_Personal_Information();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool result=true;
            foreach (TextBox box in tableLayoutPanel6.Controls.OfType<TextBox>())
                result &= Input.Verify(box, null);
            if (password.Text != repassword.Text)
            {
                MessageBox.Show("אנא תקן את הסיסמאות כך שיהיו זהות");
                return;
            }
            if (!result)
            {
                MessageBox.Show("אנא ודא כי בסיסמא יש פרטים נכונים היא חזקה");
                return;
            }
            else
            {
                Worker.SetColValue("id", Worker.Person.GetColValue("id"));
                Worker.SetColValue("password", password.Text);
                if (Worker.Update())
                    MessageBox.Show("סיסמא עודכנה במערכת");
                else
                    MessageBox.Show("Error");
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            Input.Reset((TextBox) sender);
        }
    }
}
