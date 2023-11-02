using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Custom_View
{
    public partial class InputView : UserControl
    {
        public InputView()
        {
            InitializeComponent();
        }
        public void SetData(string field,string value)
        {
            Fname.Text = field;
            input_box.Text = value;
        }
        
       
    }
}
