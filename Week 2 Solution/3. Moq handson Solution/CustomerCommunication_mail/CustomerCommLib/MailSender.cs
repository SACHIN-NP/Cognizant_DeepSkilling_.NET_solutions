// CustomerCommLib/MailSender.cs
using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            // Actual mail sending logic (commented for testing)
            /*
            var mail = new MailMessage("sender@example.com", toAddress)
            {
                Subject = "Test Mail",
                Body = message
            };
            
            using var client = new SmtpClient("smtp.example.com", 587)
            {
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true
            };
            client.Send(mail);
            */
            return true; // Simulate success
        }
    }
}
