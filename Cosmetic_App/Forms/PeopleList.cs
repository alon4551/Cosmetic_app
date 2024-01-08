using Cosmetic_App.Custom_View;
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
    public partial class PeopleList : Form
    {
        List<Person> All = new List<Person>(), workers = new List<Person>(), filter = new List<Person>(),selecedFilter= new List<Person>();
        string selected_id = "";
        bool Status ;
        public PeopleList()
        {
            InitializeComponent();
            selecedFilter = All;
        }
        public PeopleList(bool Clients)
        {
           InitializeComponent();
            Status = Clients;
           Reload();
        }
        private void Fetch()
        {
            All = Person.GetAllPeople();
            workers = Workers.GetAllWorkers();
            bool state = true;
            foreach (Person person in All)
            {
                foreach (Person worker in workers)
                    if (worker.Field == person.Field)
                    {
                        state = false;
                        break;
                    }
                if (state)
                    filter.Add(person);
            }
        }
        private void PeopleList_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            Fetch();
            if (Status)
                selecedFilter = Person.GetAllClients();
            else
                selecedFilter = workers;
            LoadList(selecedFilter);
            if (selected_id != "")
                Load_Information(new Person(selected_id));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Person person in workers)
                if(person.Value.ToString() == selected_id)
                using (Worker_Profile profile = new Worker_Profile(selected_id))
                    {
                        profile.ShowDialog();
                        Reload();
                        return;
                    }
            using (PersonFile profile = new PersonFile(selected_id))
            {
                profile.ShowDialog();
                Fetch();
                Reload();
            }
        }

        private void אדםחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                Fetch();
                Reload();
            }
        }

        private void עובדחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Worker_Profile profile = new Worker_Profile())
            {
                profile.ShowDialog();
                Fetch();
                Reload();
            }
        }

        private void להפוךלקוחלעובדToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_id != "")
            {
                foreach (Person person in workers)
                {
                    if (person.Value.ToString() == selected_id)
                    {
                        MessageBox.Show("פרופיל זה הוא כבר עובד במערכת");
                        return;
                    }
                }
                DialogResult reslt = MessageBox.Show("האם אתה רוצה להפוך לקוח זה לעובד במערכת?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reslt == DialogResult.Yes)
                {
                    using (Worker_Profile profie = new Worker_Profile(selected_id))
                    {
                        profie.ShowDialog();
                        Fetch();
                        Reload();
                    }
                }
            }
            else
                MessageBox.Show("תחילה צריך לבחור פרופיל על מנת להמשיך את התהליך");
        }

        private void להסירעובדממערכתToolStripMenuItem_Click(object sender, EventArgs e)
        {
           using (Manager_Verification verification = new Manager_Verification())
            {
                verification.ShowDialog();
                if (verification.result)
                {
                    Workers workers = new Workers(selected_id);
                    if (workers.Delete())
                    {
                        MessageBox.Show("עובד הוסר מהמערכת");
                        Fetch();
                        Reload();
                    }
                    else
                        MessageBox.Show("error");
                }
                else
                    MessageBox.Show("לצערי רק מנהל מערכת יכול להסיר את העובד מהמערכת");
            }
        }

        public void LoadList(List<Person> list)
        {
           list_layout.Controls.Clear();
           foreach(Person person in list)
            {
                Person_Profile_View view = new Person_Profile_View();
                view.SetData(person.GetColValue(0).ToString(), person.GetFullName());
                view.Click += new EventHandler(ClickPersonProfile);
                view.SetCLickEvent(new EventHandler(ClickPersonProfile));
                list_layout.Controls.Add(view);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (filter_textbox.Text == "")
                LoadList(selecedFilter);
            else
            {
                filter.Clear();
                foreach( Person person in All)
                {
                    bool type = true;
                    foreach (char c in filter_textbox.Text)
                        if(c< '0' || c> '9')
                            type = false;
                    if (type) {
                        if (person.Value.ToString().StartsWith(filter_textbox.Text))
                            filter.Add(person);
                    }
                    else
                    {
                        if(person.GetFullName().Contains(filter_textbox.Text))
                            filter.Add(person);
                    }
                }
                LoadList(filter);

            }
        }
        public void ClickPersonProfile(object sender,EventArgs e)
        {
            selected_id = Input.GetTag(sender).ToString();
            foreach (Person person in All) 
            {
                if(person.GetColValue("id").ToString() ==selected_id ) 
                {
                    Load_Information(person);
                    break;
                }
            }
            
        }
        public void Load_Information(Person person)
        {
            Input.Load_TextBox_Information(information_layout_table, person);
            foreach (Person worker in workers)
                if (worker.Value.ToString() == selected_id)
                {
                    if (bool.Parse(worker.GetColValue("admin").ToString()))
                        status.Text = "האדם הוא מנהל";
                    else
                        status.Text = "האדם הוא עובד במערכת";
                    break;
                }
                else
                    status.Text = "האדם הוא לקוח";
        }   
    }
}
