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
    public partial class CustomMessageBox : Form
    {// a class not used in the project
        public string selected { get; set; } = "";
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        public static string Show()
        {
            using (CustomMessageBox dlg = new CustomMessageBox())
            {
                 dlg.ShowDialog();
                 return dlg.selected;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selected = "טיפול";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selected = "מוצר";
            this.Close();
        }
    }
}
