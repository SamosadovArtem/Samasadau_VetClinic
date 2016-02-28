using ActionMailer.Net.Mvc;
using System.Net;
using System.Net.Mail;

namespace VetClinic.Infrastructure.Mail
{
    public class MailSandler
    {
        public void SendEmail(string currentBody)
        {
            var fromAddress = new MailAddress("vetclinic_app@mail.ru", "vetclinic_app@mail.ru");
            var toAddress = new MailAddress("pizzaeueu@gmail.com", "pizzaeueu@gmail.com");
             string fromPassword = "Vet123456789";
             string subject = "Subject";
             string body = currentBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}