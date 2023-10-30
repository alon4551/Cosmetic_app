using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Utiltes
{
    internal class Messages
    {
        public static string IncorectID_Error_TextBox { get; } = "תעודת הזהות שהכנסת אינה תקינה";
        public static string IncorectPassword_Error_TextBox { get; } = "סיסמא לא נכונה";
        public static string Get(string type)
        {
            switch (type)
            {
                case "id":
                    return IncorectID_Error_TextBox;
                case "password":
                    return IncorectPassword_Error_TextBox;
            }
            return "";
        }
    }
}
