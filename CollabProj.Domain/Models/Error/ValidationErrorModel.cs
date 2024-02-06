namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Error Model for Validation Code Form
    /// </summary>
    public class ValidationErrorModel : ErrorModel
    {
        /// <summary>
        /// Validation Code Error of Validation Form.
        /// </summary>
        public string? ValidationCodeError { get; set; }
    }
}
