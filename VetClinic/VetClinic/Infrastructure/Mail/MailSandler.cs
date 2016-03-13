using ActionMailer.Net.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using VetClinic.Models;

namespace VetClinic.Infrastructure.Mail
{
    public class MailSandler
    {
        public bool SendEmail(string currentBody, string currentEmail)
        {
            var fromAddress = new MailAddress("vetclinic1_app@mail.ru", "vetclinic_app@mail.ru");
            var toAddress = new MailAddress(currentEmail, currentEmail);
             string fromPassword = "Vet123456789";
             string subject = "Ветеринарная клиника";
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

        public void MakeDeliver(List<Doctor> allDoctors, string mailText)
        {
            foreach (Doctor doctor in allDoctors)
            {
                SendEmail(mailText, doctor.Email);
            }
        }
    }
}