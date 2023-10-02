using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Helper
{

    public class EmailHelper
    {
        private static string From = "jil1710.jp@gmail.com";
        private static string Host = "smtp.gmail.com";
        private static int Port = 465;
        private static bool EnableSsl = true;
        private static string Username = "Jil Patel";
        private static string Password = "pliwmhhvxxaigzjh";

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(Username,From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }

        public void SendMail(Message message)
        {
            MimeMessage emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private void Send(MimeMessage emailMessage)
        {
            using SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect(Host, Port, EnableSsl);
                smtpClient.Authenticate(From, Password);
                smtpClient.Send(emailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception ====> {ex.Message}");
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }

    }
}
