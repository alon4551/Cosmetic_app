using Cosmetic_App.Audit;
using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Tls;
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
         public static object GetTag(object obg)
        {
            switch (obg.GetType().Name)
            {
                case "Label":
                    return (obg as Label).Tag;
                case "TextBox":
                    return (obg as TextBox).Tag;
                case "Person_Profile_View":
                    return (obg as Person_Profile_View).Tag;
            }
            return null;
        }
        public static void Load_TextBox_Information(TableLayoutPanel layout,DB_Object obj)
        {
            foreach(TextBox box in layout.Controls.OfType<TextBox>())
            {
                box.Clear();
                switch (box.Name.ToLower())
                {
                    case "fullname":
                        box.Text = (obj as Person).GetFullName();
                        break;
                    case "status":
                        break;
                    default:
                            box.Text = obj.GetColValue(box.Name).ToString();
                        break;
                }
            }
        }
    }
}
