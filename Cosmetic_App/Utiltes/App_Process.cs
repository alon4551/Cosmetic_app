using Cosmetic_App.Forms;
using iText.Layout.Borders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cosmetic_App.Tables;

namespace Cosmetic_App.Utiltes
{
    public static class App_Process
    {
        public static int NewOrder(string worker_id, Control control)
        {
            control.Hide();
            using (Store store = new Store(worker_id))
            {
                store.ShowDialog();
                if (store.finish)
                {
                    using (Order_Edit edit = new Order_Edit((int)store.Order.Value))
                    {
                        edit.ShowDialog();
                    }
                    return (int)store.Order.Value;
                }
            }
            control.Show();
            return -1;
        }
        public static string NewPerson(Control control)
        {
            control.Hide();
            using (PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                control.Show();
                if (profile.Status_Save)
                    return profile.GetId();
                else
                    return "";
            }
        }

        internal static void Clients(Control control)
        {
            control.Hide();
            using(PeopleList Dashborad = new PeopleList(true))
            {
                Dashborad.ShowDialog();
            }
            control.Show();
        }

        internal static void ClockInOrOut(HomePage control)
        {
            control.Hide();
            using(ClockShifts checkin = new ClockShifts())
            {
                checkin.ShowDialog();
            }
            control.Show();
        }

        internal static void Expance_Dashboard(HomePage homePage)
        {
            throw new NotImplementedException();
        }

        internal static void NewExpance(HomePage homePage)
        {
            throw new NotImplementedException();
        }

        internal static void NewProduct(Control control,bool isTreatment)
        {
            if (control != null)
                control.Hide();
            using (Product_Profile profile = new Product_Profile(isTreatment))
            {
                profile.ShowDialog();
            }
            if (control != null)
                control.Show();
        }

        internal static void NewWorker(Control control)
        {
            control.Hide();
            string id = NewPerson(null);
            if (id != "")
                using (Worker_Profile profile = new Worker_Profile(id))
                {
                    profile.ShowDialog();
                }
       
            control.Show();
        }

        internal static void Order_Dashborad(Control control)
        {
            control.Hide();
            using(Orders_Dashboard dashboard = new Orders_Dashboard(Tables.Workers.LogedWorker.Value.ToString()))
            {
                dashboard.ShowDialog();
            }
            control.Show();
        }

        internal static void Products(Control control,bool state)
        {
            control.Hide();
            using(Product_Dashbord dashbord =new Product_Dashbord(state))
            {
                dashbord.ShowDialog();

            }
            control.Show();
        }
        internal static void Product(Control control,int id)
        {
            control.Hide();
            using (Product_Profile profile = new Product_Profile(id))
            {
                profile.ShowDialog();
            }
            control.Show();
        }
        internal static void Shifts(Control control)
        {
     
        }

        internal static void Workers(Control control)
        {
            control.Hide();
            using (PeopleList Dashborad = new PeopleList(false))
            {
                Dashborad.ShowDialog();
            }
            control.Show();
        }
    }
}
