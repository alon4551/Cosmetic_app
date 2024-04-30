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
        {
            id.Enabled = true;
            if (Person.IsEmpty()) return;
            foreach(TextBox box in Profile_Layout.Controls.OfType<TextBox>())
                box.Text = Person.GetColValue(box.Name).ToString();
            birthday.Text = Person.GetColValue("birthday").ToString();
            if (Person.Value.ToString() == "0")
                id.Enabled = false;
        }
        public void SetPerson(string id)
        {
            Person.Grab(id);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (SavePerson())
            {
                MessageBox.Show("פרטי אדם נשמר במערכת");
                Status_Save = true;
                Person.ReloadList();
                this.Close();
            }
            else
                MessageBox.Show("Error Human");
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
            return Person.Save();

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
                Person.ReloadList();
                this.Close();
            }
        }

        private void PersonFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Status_Save = false;
        }

    }
}
