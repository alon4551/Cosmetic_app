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

namespace Cosmetic_App.Forms
{
    public partial class Store : Form
    {
        public Income Order = new Income();
        public List<Person> People = Person.GetAllClients();
        public List<Products> products = Products.GetAllProducts(),Filter=new List<Products>();
        public Store()
        {
            InitializeComponent();
        }
        public void Load_Information()
        {
            Client_List.Items.Clear();
            foreach(Person person in People)
            {
                Client_List.Items.Add(person.)
            }
        }

    }
}
