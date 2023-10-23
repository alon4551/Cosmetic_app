using Cosmetic_App.Audit;
using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App
{
    public static class Input
    {
        public static void Reset(TextBox input)
        {
            input.BackColor = Color.White;
        }
        public static void Reset(Label hint)
        {
            hint.Text = "";
        }
        public static bool Verify(TextBox input,Label hint)
        {
            if (Verification.Text(input.Text, input.Name) == false)
            {
                input.BackColor = Color.Red;
                if(hint != null) 
                    hint.Text = Messages.Get(input.Name);
                return false;
            }
            return true;
        }
         
    }
}
