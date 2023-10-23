using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cosmetic_App.Audit
{
    public class Verification
    {
        public static bool Text(string text, string type)
        {
            text = text.Trim();
            if( text.Contains("'"))
                return false;
            switch(type.ToLower())
            {
                case "id":
                    return VerifyId(text);
                case "password":
                case "repassword":
                    return text != "";
                case "email":
                    return VerifyEmail(text);
                case "firstname":
                    return text != "";
                case "lastname":
                    return text != "";
                case "phone":
                    return text != "";
                case "birthday":
                    return VerifyBirthday(text);
            }
            return false;
        }

        private static bool VerifyBirthday(string text)
        {
            try
            {
               DateTime.Parse(text);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private static bool VerifyEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private static bool VerifyId(string id)
        {
            if(id.Length!=9||!IsNumeric(id))
                return false;
            int total = 0;
            for (int i = 0; i < 9; i++)
                if (i % 2 == 0)
                    total += (id[i] - '0');
                else
                {
                    if ((id[i] - '0') * 2 >= 10)
                        total += ((id[i] - '0') * 2) % 10 + ((id[i] - '0') * 2) / 10;
                    else
                        total += (id[i] - '0') * 2;
                }
            total %= 10;
            return total == 0;
        }
        private static bool IsNumeric(string input)
        {
            foreach (char c in input)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }
    }
}
