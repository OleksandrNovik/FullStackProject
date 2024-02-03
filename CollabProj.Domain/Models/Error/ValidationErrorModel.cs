namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Error Model for Validation Code Form
    /// </summary>
    public class ValidationErrorModel
    {
        /// <summary>
        /// Validation Code Error of Validation form.
        /// </summary>
        public string? ValidationCodeError { get; set; }

        /// <summary>
        /// Indicator of successful form submittion
        /// </summary>
        public bool Success { get; set; }
    }
}
