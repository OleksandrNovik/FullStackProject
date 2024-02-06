using CollabProj.Application.Interfaces.Services.VerificationCode;
using Serilog;

namespace CollabProj.Infrastructure.Services.VerificationCode
{
    /// <summary>
    /// Service implementation for code generation
    /// </summary>
    public class CodeGenerationService : ICodeGenerationService
    {
        /// <summary>
        /// Randomizer for code generation
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// Constructor for Code Generation Service
        /// </summary>
        public CodeGenerationService()
        {
            _random = new Random();
        }

        /// <summary>
        /// Implementation of method for generating code
        /// </summary>
        /// <returns>6-digit code</returns>
        public int GenerateCode()
        {
            Log.Warning("Generating validation code...");

            int code = _random.Next(100000, 999999);

            Log.Information("Generated code: {@code}", code);

            return code;
        }
    }
}
