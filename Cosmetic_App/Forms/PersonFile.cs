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
        public bool Status_Save;
        Person Person = new Person();
        public string GetId()
        {
            return Person.GetColValue("id").ToString();
        }
        public PersonFile(string id)
        {
            InitializeComponent();
            Person.Grab(id);
        }
        public PersonFile()
        {
            InitializeComponent();
        }

        private void PersonFile_Load(object sender, EventArgs e)
        {
            LoadPerson();
        }
        public void LoadPerson()
        {//loading person information on window
            id.Enabled = true;
            if (!Person.IsExist()) return;
            foreach (TextBox box in tableLayoutPanel6.Controls.OfType<TextBox>())
                try
                {
                    box.Text = Person.GetColValue(box.Tag.ToString()).ToString();
                }
                catch { }   
            try
            {
                birthday.Text = Person.GetColValue("birthday").ToString();
            }
            catch { }
            if (Person.Value.ToString() == "0")
                id.Enabled = false;
        }
        public void SetPerson(string id)
        {//holding person information for furthe actions
            Person.Grab(id);
        }
        private void button3_Click(object sender, EventArgs e)
        {//saveing person in DB
            if (SavePerson())
            {
                MessageBox.Show("פרטי אדם נשמר במערכת");
                Status_Save = true;
                Person.ReloadList();
                this.Close();
            }
            else
                MessageBox.Show("שגיאה");
        }
        private bool SavePerson()
        {//saveing person in DB
            bool result = true;
            foreach (TextBox box in tableLayoutPanel6.Controls.OfType<TextBox>())
                result &= Input.Verify(box, null);
            if (result == false)
                return false;
            foreach (TextBox box in tableLayoutPanel6.Controls.OfType<TextBox>())
                Person.SetColValue(box.Tag.ToString(), box.Text);
            Person.SetColValue(birthday.Tag.ToString(), birthday.Text);
            return Person.Save();

        }
        private bool DeleteProfile()
        {//deleting person in DB
            return Person.Delete();
        }
        private void TextBox_Click(object sender, EventArgs e)
        {//reset warning after changing input text
            Input.Reset((TextBox)sender);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (DeleteProfile())
            {
                MessageBox.Show("בן האדם נמחק");
                Person.ReloadList();
                this.Close();
            }
        }

        private void PersonFile_FormClosing(object sender, FormClosingEventArgs e)
        {//saveing status information 
            Status_Save = false;
        }

    }
}
