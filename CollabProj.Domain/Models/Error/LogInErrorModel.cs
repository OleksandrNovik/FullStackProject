namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Error Model for LogIn Form
    /// </summary>
    public class LogInErrorModel : ErrorModel
    {
        /// <summary>
        /// Password Error of LogIn Form.
        /// </summary>
        public string? PasswordError { get; set; }
    }
}
