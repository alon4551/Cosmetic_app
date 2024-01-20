using Cosmetic_App.Forms;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
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
            //gmail_helper.SendMail("alon4551@gmail.com", "hello world");
            Workers.LogedWorker = new Workers("0");
            Application.Run(new LoginPage());
        }
    }
}
