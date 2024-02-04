using CollabProj.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Serilog;

namespace CollabProj.Infrastructure.Services
{
    /// <summary>
    /// Implementation of service for sending email
    /// </summary>
    public class EmailSenderService : IEmailSenderService
    {
        /// <summary>
        /// Implementation of method for sending email
        /// </summary>
        /// <param name="mail">Recipient's email</param>
        /// <param name="subject">Subject of a list</param>
        /// <param name="message">Message of a list</param>
        public void SendEmail(string mail, string subject, string message)
        {
            Log.Information("Data, passed for sending: {@mail}, {@subject}, {@message}", mail, subject, message);

            Log.Debug("Setting up data for email sending...");

            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress("My website", "baryaroman@ukr.net"));
            email.To.Add(new MailboxAddress("User", mail));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = message };

            Log.Information("Data set up successfully");

            Log.Debug("Entering sending procedure...");

            using (SmtpClient smtp = new SmtpClient())
            {
                Log.Warning("Connecting to Mail SSL...");

                smtp.Connect("smtp.ukr.net", 465, SecureSocketOptions.SslOnConnect);

                Log.Information("Connection to Mail SSL established");

                Log.Warning("Authenticating to sending email...");

                smtp.Authenticate("baryaroman@ukr.net", "JY8aaKeilssBxTp5");

                Log.Information("Successfully authenticated to email");

                Log.Warning("Sending email letter...");

                smtp.Send(email);

                Log.Information("Email letter successfully was sent");

                Log.Warning("Disconnecting from SSL...");

                smtp.Disconnect(true);

                Log.Information("Disconnected from SSL");
            }

            Log.Information("Mail sending procedure was successfully");
        }
    }
}
