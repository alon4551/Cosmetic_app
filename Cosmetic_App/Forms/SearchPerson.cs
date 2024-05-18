using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cosmetic_App.Tables;

namespace Cosmetic_App.Forms
{
    public partial class SearchPerson : Form
    {
        public Person Selected = null;
        List<Person> People = Person.Clients;
        public SearchPerson()
        {
            InitializeComponent();
        }

        private void Load_list()
        {// loading list of people in window
            comboBox1.Items.Clear();
            foreach (Person person in People)
                comboBox1.Items.Add(person.GetFullName());
        }
        private void SearchPerson_Load(object sender, EventArgs e)
        {
            Load_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {//choseing peoson and holding the information
            Selected = People[comboBox1.SelectedIndex];
            MessageBox.Show($"{Selected.GetFullName()} נבחר") ;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//createing a new person in DB and selecting him
            using(PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                if (profile.GetId() == "")
                {
                    MessageBox.Show("תהליך לא הושלם");
                    return;
                }
                else
                {
                    Selected = new Person(profile.GetId());
                    MessageBox.Show($"{Selected.GetFullName()} נבחר");
                }
            }
            this.Close();
        }
    }
}
