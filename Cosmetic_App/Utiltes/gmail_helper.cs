using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Cosmetic_App.Tables;
using System.Windows.Forms;


namespace Cosmetic_App.Utiltes
{
    public static class gmail_helper
    {
        private static string senderEmail = "appcosmetic@gmail.com";
        //Person.GetColValue("0","email").ToString(); nipeqzygbxgndbpj
        private static string senderPassword = "Cosmetic@321";
           // Workers.GetColValue("0","password").ToString();
        public static void SendMail(string recipientEmail, string Message)
        {
            MailMessage message = new MailMessage(senderEmail, recipientEmail)
            {
                Subject = "Subject of your email",
                Body = Message
            };
            
            // Create a SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };
            
            try
            {
                // Send the email
                smtpClient.Send(message);
                MessageBox.Show("Good");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
