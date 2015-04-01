using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using TDC.Models;

namespace TDC.Tools
{
    public static class MailSender
    {
        public static void sendMessage(this Message x)
        {
            int dont = 0;

            if (dont != 0)
            {
                MailMessage message = new MailMessage("tdcapp411@gamil.com", x.User.Email, "Shock!", x.notification + "   Go to tdcapp.org to check your balance");
                message.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("tdcapp411@gmail.com", "AppleCat");// Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(message); 
            }
        }


    }
}