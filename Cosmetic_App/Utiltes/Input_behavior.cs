using Cosmetic_App.Audit;
using Cosmetic_App.Custom_View;
using Cosmetic_App.Tables;
using Cosmetic_App.Utiltes;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static void TextChangeAfterError(object sender, EventArgs e)
        {//reset waring after failue input 
            Reset((TextBox) sender);
        }
        public static void Reset(TextBox input,Label hint)
        {//reseting color and waring label
            input.BackColor = Color.White;
            hint.Text = "";
        }
        public static void Reset(TextBox input)
        {
            input.BackColor = Color.White;
        }
        public static void Reset(Label hint)
        {
            hint.Text = "";
        }
        public static bool Verify(TextBox input,Label hint)
        {//verify input and styleing in case of failue
            if (Verification.Text(input.Text, input.Name) == false)
            {
                input.BackColor = Color.Red;
                if (hint != null)
                    if (input.Text == "")
                        hint.Text = Messages.Get("null");
                    else
                        hint.Text = Messages.Get(input.Name);

                return false;
            }
            else
                if (hint != null)
                Reset(hint);
            return true;
        }
         public static object GetTag(object obg)
        {//return the tag value for each element 
            switch (obg.GetType().Name)
            {
                case "Label":return (obg as Label).Tag;
                case "TextBox":return (obg as TextBox).Tag;
                case "Button":return (obg as Button).Tag;
                case "ComboBox":return (obg as ComboBox).Tag;
                case "table_product_layout":return (obg as TableLayoutPanel).Tag;
                case "Person_Profile_View":return (obg as Person_Profile_View).Tag;
                case "DayApooitment_view": return (obg as DayApooitment_view).Tag;
                case "ProductView":return (obg as ProductView).Tag;
                case "Cart_Schedule_View": return (obg as Cart_Schedule_View).Tag;
                case "TableLayoutPanel":return (obg as TableLayoutPanel).Tag;
                default:
                    {
                        return null;
                    }
            }
        }
        public static void Clear_Textbox_Information(TableLayoutPanel layout)
        {//clearing all text from input in a form
            foreach(TextBox box in layout.Controls.OfType<TextBox>())
                box.Text = "";
        }
        public static void Load_TextBox_Information(TableLayoutPanel layout,DB_Object obj)
        {//putting all infomation from object in the form 
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
                        try
                        {
                            
                            box.Text = obj.GetColValue(box.Name).ToString();
                        }
                        catch { }
                        break;
                }
            }
        }
    }
}
