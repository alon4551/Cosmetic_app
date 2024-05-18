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
        {//opening process of new order
            control.Hide();
            using (Schedule edit = new Schedule())
            {
                edit.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
            return -1;
        }
        public static void Statisteics( Control control)
        {//opening process of showing stats
            control.Hide();
            using (Statistic edit = new Statistic())
            {
                edit.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }
        public static string NewPerson(Control control)
        {//opening process of new person in application
            if (control != null)
                control.Hide();
           
            using (PersonFile profile = new PersonFile())
            {
                profile.ShowDialog();
                if (control != null)
                    control.Show();
                if (profile.Status_Save)
                    return profile.GetId();
                else
                    return "";
            }
        }

        internal static void Clients(Control control)
        {//opening process of showing all clients
            control.Hide();
            using(PeopleList Dashborad = new PeopleList(true))
            {
                Dashborad.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }

        internal static void ClockInOrOut(HomePage control)
        {//opening process of shifts window
            control.Hide();
            using(ClockShifts checkin = new ClockShifts())
            {
                checkin.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
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
        {//opening process of new product in application
            if (control != null)
                control.Hide();
            using (Product_Profile profile = new Product_Profile(isTreatment))
            {
                profile.ShowDialog();
            }
            if (control != null)
            {
                Cosmetic_App.Tables.Products.CheckInventory();
                control.Show();
            }
        }

        internal static void NewWorker(Control control)
        {//opening process of new worker in application
            control.Hide();
            string id;
            using (SearchPerson search = new SearchPerson())
            {
                search.ShowDialog();
                if (search.Selected != null)
                {
                    id = search.Selected.GetColValue(0).ToString();
                    using (CreatePassword profile = new CreatePassword(id))
                    {
                        profile.ShowDialog();
                    }
                }
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }

        internal static void Order_Dashborad(Control control)
        {//opening process of orders dashbord
            control.Hide();
            using(Orders_Dashboard dashboard = new Orders_Dashboard(Tables.Workers.LogedWorker.Value.ToString()))
            {
                dashboard.ShowDialog();
            }
            control.Show();
        }

        internal static void Products(Control control,bool state)
        {//opening process of all merch or all treatment (depand on the state,true - treatment,false- merch)
            control.Hide();
            using(Product_Dashbord dashbord =new Product_Dashbord(state))
            {
                dashbord.ShowDialog();

            }

            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }
        internal static void Product(Control control,int id)
        {//opening process of editing a product
            control.Hide();
            using (Product_Profile profile = new Product_Profile(id))
            {
                profile.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }
        internal static void Shifts(Control control)
        {

        }

        internal static void Workers(Control control)
        {//opening process of all workers
            control.Hide();
            using (PeopleList Dashborad = new PeopleList(false))
            {
                Dashborad.ShowDialog();
            }
            Cosmetic_App.Tables.Products.CheckInventory();
            control.Show();
        }
        public static void ForgetPassword(string id)
        {//opening process of forgeting worker password
            using (Manager_Verification verification = new Manager_Verification())
            {
                verification.ShowDialog();
                if (!verification.result)
                    return;
            }
            foreach(Workers worker in Cosmetic_App.Tables.Workers.list)
            {
                if(worker.Value.ToString()==id)
                    MessageBox.Show(worker.GetColValue("password").ToString(), "הסיסמא מופיעה על המסך");
            }
        }
    }
}
