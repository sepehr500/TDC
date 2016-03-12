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
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public static string ToEmail { get; set; }
        public static string Subject { get; set; }
        public static  string Body { get; set; }
        public static bool IsHtml { get; set; }

        public static void sendMessage(this Message x)
        {


            //MailMessage message = new MailMessage("tdcapp411@gamil.com", x.User.Email, "Shock!", x.notification + "   Go to tdcapp.org to check your balance");
            //message.IsBodyHtml = false;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 25;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential
            //("tdcapp411@gmail.com", "AppleCat");// Enter senders User name and password
            //smtp.EnableSsl = true;
            //smtp.Send(message); 
            
        }


    }
}