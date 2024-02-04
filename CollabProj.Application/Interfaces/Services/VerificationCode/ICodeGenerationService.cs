namespace CollabProj.Application.Interfaces.Services.VerificationCode
{
    /// <summary>
    /// Service Interface for Code Generation Service
    /// </summary>
    public interface ICodeGenerationService
    {
        /// <summary>
        /// Method for Code Generation
        /// </summary>
        /// <returns></returns>
        public int GenerateCode();
    }
}
