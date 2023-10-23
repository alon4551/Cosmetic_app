using Cosmetic_App.Audit;
using Cosmetic_App.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public partial class PersonFile : Form
    {
        Workers Worker = new Workers();
        Person Person = new Person();
        bool Profile_State = true;
        public PersonFile(string id)
        {
            InitializeComponent();
            Person.Grab(id);
            Worker.Grab(id);
        }
        public PersonFile()
        {
            InitializeComponent();
        }

        private void PersonFile_Load(object sender, EventArgs e)
        {
            LoadPerson();
            LoadWorker();
        }
        public void LoadWorker()
        {
            if (!Worker.IsEmpty())
                Admin_checkBox.Checked = Worker.GetAdmin();
        }
        public void LoadPerson()
        {
            if (Person.IsEmpty()) return;
            foreach(TextBox box in Profile_Layout.Controls.OfType<TextBox>())
                box.Text = Person.GetColValue(box.Name).ToString();
            birthday.Text = Person.GetColValue("birthday").ToString();
        }
        public void SetPerson(string id)
        {
            Person.Grab(id);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            switch (profile_control.SelectedIndex)
            {
                case 0:
                    if (SavePerson())
                        MessageBox.Show("פרטי אדם נשמר במערכת");
                    else
                        MessageBox.Show("Error Human");
                    break;
                case 1:
                    if (SaveWorker())
                    {
                        if (DialogResult.Yes == MessageBox.Show("פרטי עובד נשמרו, האם תרצה לשמור את נתוני האדם שלו גם?", "", MessageBoxButtons.YesNo))
                            if(SavePerson())
                                MessageBox.Show("פרטי אדם נשמר במערכת");
                        else 
                                MessageBox.Show("Error Human");
                    }
                    else 
                        MessageBox.Show("Error Worker");
                    break;
            }
        }
        private bool IsWorkerPageIsEmpty()
        {
            return Password.Text.Length == 0 && RePassword.Text.Length == 0;
        }
        private bool SaveWorker()
        {
            bool result = true;
            foreach (TextBox box in Worker_Layout.Controls.OfType<TextBox>())
                result &= Input.Verify(Password, null);
            if(result==false)return false;
            if (Password.Text == RePassword.Text)
                Worker.SetColValue("password", Password.Text);
            Worker.SetColValue(2, Admin_checkBox.Checked);
            return Worker.Update();
        }
        private bool SavePerson()
        {
            bool result = true;
            foreach (TextBox box in Profile_Layout.Controls.OfType<TextBox>())
                result &= Input.Verify(box, null);
            if (result == false)
                return false;
            foreach (TextBox box in Profile_Layout.Controls.OfType<TextBox>())
                Person.SetColValue(box.Name, box.Text);
            Person.SetColValue(birthday.Name, birthday.Text);
            return Person.Update();
        }
        private bool DeleteProfile()
        {
            return Person.Delete();
        }
        private void TextBox_Click(object sender, EventArgs e)
        {
            Input.Reset((TextBox)sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DeleteProfile())
            {
                MessageBox.Show("בן האדם נמחק");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Input.Reset(Password);
        }
    }
}
