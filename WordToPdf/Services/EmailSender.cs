using System.IO;
using System.Net;
using System.Net.Mail;

namespace WordToPdf.Services
{
    public static class EmailSender
    {
        #region The mail to be added to the cc part of the outgoing mail

        const string _toBcc = "veysel_mutlu42@hotmail.com";

        #endregion
        public static void EmailSend(string email, MemoryStream memoryStream, string fileName)
        {
            var pdfFile = PdfCreator.PdfCreate(memoryStream, fileName);
            SendMail(email, pdfFile);

            memoryStream.Close();
            memoryStream.Dispose();
        }

        public static void SendMail(string to, Attachment attachment)
        {
            string fileCreatedMessage = "Pdf Dosyanız Ekte'dir";
            string subject = "Word To Pdf";

            var from = new MailAddress("Your Email Adress");

            var response = new MailAddress(to);

            using (var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, "Your Password")
            })
            {
                using var message = new MailMessage(from, response) { Subject = subject, Body = fileCreatedMessage };
                {
                    message.Bcc.Add(new MailAddress(_toBcc));
                    message.Attachments.Add(attachment);
                    smtpClient.Send(message);
                }
            }
        }
    }
}
