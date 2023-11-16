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
        public static string IncorectPrice_Error_TextBox { get; } = "המחיר שהכנס אינו תקין";
        public static string IncorectAmount_Error_TextBox { get; } = "הכמות שהכנסת איננה תקינה";
        public static string IncorectNull_Error_TextBox { get; } = "השדה אינו יכול להיות ריק";
        public static string IncorectCount_Error_TextBox { get; } = "רק מספרים מלאים";
        public static string Get(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "id":
                    return IncorectID_Error_TextBox;
                case "password":
                    return IncorectPassword_Error_TextBox;
                case "price":
                    return IncorectPrice_Error_TextBox;
                case "amount":
                    return IncorectAmount_Error_TextBox;
                case "count":
                    return IncorectCount_Error_TextBox;
                case "null":
                    return IncorectNull_Error_TextBox;
            }
            return "";
        }
        public static string Reverse(string message)
        {
            string[] lines = message.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                char[] characters = lines[i].ToCharArray();
                Array.Reverse(characters);
                lines[i] = new string(characters);
            }

            return string.Join("\n", lines);
        }
    }
}
