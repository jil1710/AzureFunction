using System;
using EmailSender.Helper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace EmailSender
{
    public class Function1
    {
        // This Azure Function run on timer we have to pass CRON expression according to which function invoke event time interval.

        [FunctionName("EmailSender")]
        public void Run([TimerTrigger("0 15 10 ? * *")]TimerInfo myTimer, ILogger log)
        {   

            // Email service 
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendMail(new Message() { To = new MailboxAddress("Jil Patel", "jil.p@simformsolutions.com"), Content = "This is the email service that is send the mail and azure function run at every 10:15 AM every day and send mail", Subject = "Azure Function" });
        }
    }
}
