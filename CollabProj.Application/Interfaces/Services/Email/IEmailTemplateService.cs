namespace CollabProj.Application.Interfaces.Services.Email
{
    /// <summary>
    /// Service Interface to create body templates for email list  
    /// </summary>
    public interface IEmailTemplateService
    {
        /// <summary>
        /// Method to create HTML body for validation code email list
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">Verification code</param>
        /// <returns>HTML body for validation code email list</returns>
        public string VerificationCodeTemplate(string username, int verificationCode);
    }
}
