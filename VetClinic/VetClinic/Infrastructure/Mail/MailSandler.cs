using ActionMailer.Net.Mvc;
using System.Net;
using System.Net.Mail;

namespace VetClinic.Infrastructure.Mail
{
    public class MailSandler
    {
        public bool SendEmail(string currentBody, string currentEmail)
        {
            var fromAddress = new MailAddress("vetclinic_app@mail.ru", "vetclinic_app@mail.ru");
            var toAddress = new MailAddress(currentEmail, currentEmail);
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
                try {
                    smtp.Send(message);
                    return true;
                }
                catch (SmtpFailedRecipientException)
                {
                    return false;
                }
            }
        }
    }
}