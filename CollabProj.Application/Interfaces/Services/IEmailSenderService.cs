namespace CollabProj.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for sending email
    /// </summary>
    public interface IEmailSenderService
    {
        /// <summary>
        /// Method for sending email
        /// </summary>
        /// <param name="mail">Recipient's email</param>
        /// <param name="subject">Subject of a list</param>
        /// <param name="message">Body of a list</param>
        public void SendEmail(string mail, string subject, string message);
    }
}
