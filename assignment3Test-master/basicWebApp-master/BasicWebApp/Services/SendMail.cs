using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace BasicWebApp.Services
{
    public class SendMail
    {
        private string email;
        private string subject;
        private string message;

        public void sendEmail(string email, string subject, string message)
        {
            SmtpClient smtpClient = new SmtpClient("mail.InstaTest.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("ahmedsharfraz27@gmail.com", "blackswan");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("ahmedsharfraz27@gmail.com", "Instagram");
            mail.To.Add(new MailAddress(email));
            mail.Subject = subject;
            mail.Body = message;


            smtpClient.Send(mail);
        }
    }
}
