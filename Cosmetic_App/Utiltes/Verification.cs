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
        {//verify if input was corectly typed
            text = text.Trim();
            if( text.Contains("'"))
                return false;
          
            switch (type.ToLower())
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
                case "count":
                    return VerifyNumber(text);
                case "amount":
                case "price":
                    {
                        if (VerifyNumber(text))
                            if (int.Parse(text) >= 0)
                                return true; ;
                        return false;
                    }
            }
            if (text != "")
                return true;
            return false;
        }
        private static bool VerifyNumber(string price)
        {//verify if phone number is currect
            if(price=="") return false;
            foreach (char c in price)
            {
                if (c == price[0] && c == '-')
                    continue;
                if (c > '9' || c < '0')
                    return false;
            }
            return true;
        }
        private static bool VerifyBirthday(string text)
        {//verify if birthday is currect
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
        {//verify if email is currect
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private static bool VerifyId(string id)
        {//verify if israeli Id is currect
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
        {//return if text has digits in text
            foreach (char c in input)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }
    }
}
