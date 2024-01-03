using Cosmetic_App.Forms;
using Cosmetic_App.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Workers.LogedWorker = new Workers("0");
            Application.Run(new Shifts_Dashbored("206517336"));
        }
    }
}
