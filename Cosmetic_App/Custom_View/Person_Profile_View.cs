using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cosmetic_App.Custom_View
{
    public partial class Person_Profile_View : UserControl
    {
        string Id_Person;
        public Person_Profile_View()
        {
            InitializeComponent();
        }

        private void Person_Profile_View_Load(object sender, EventArgs e)
        {

        }
        public void SetCLickEvent(EventHandler handler)
        {
            ID.Click += handler;
            FullName.Click += handler;
            label1.Click += handler;
            label2.Click += handler;
        }
        public string GetID() { return Id_Person; }
        public void SetData(string id,string fullname)
        {
            label1.Tag= id;
            label2.Tag= id;
            ID.Tag= id;
            FullName.Tag= id;
            this.Tag = id;
            ID.Text = id;
            Id_Person = id;
            FullName.Text = fullname;
        }

        
    }
}
