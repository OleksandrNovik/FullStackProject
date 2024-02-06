namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Abstract Class for Error Models
    /// </summary>
    public abstract class ErrorModel
    {
        /// <summary>
        /// Indicator of successful form submittion
        /// </summary>
        public bool Success { get; set; }
    }
}
