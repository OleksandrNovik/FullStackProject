namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Error Model for Register Form
    /// </summary>
    public class RegisterErrorModel : ErrorModel
    {
        /// <summary>
        /// Email Error of register Form.
        /// </summary>
        public string? EmailError { get; set; }

        /// <summary>
        /// Username Error of register Form.
        /// </summary>
        public string? UsernameError { get; set; }
    }
}
