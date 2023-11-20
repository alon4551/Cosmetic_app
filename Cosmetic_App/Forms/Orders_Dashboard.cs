using Cosmetic_App.Tables;
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

namespace Cosmetic_App.Forms
{
    public partial class Orders_Dashboard : Form
    {
        List<Income> AllOrders = Income.GrabAll(), UrjentOrders;
        public Orders_Dashboard()
        {
            InitializeComponent();
            SortOrders();
        }
        public void SortOrders()
        {
            UrjentOrders = new List<Income>();
            foreach(Income income in AllOrders) 
            {
                if(!income.IsShopingCartScheduale())
                {
                    UrjentOrders.Add(income);
                }
            }
        }
    }
}
