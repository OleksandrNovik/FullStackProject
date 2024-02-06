using CollabProj.Application.Interfaces.Services.VerificationCode;
using CollabProj.Application.Interfaces.Services.Email;
using CollabProj.Application.Interfaces.Services;
using Serilog;
using CollabProj.Domain.Models.User;

namespace CollabProj.Infrastructure.Services.VerificationCode
{
    /// <summary>
    /// Service Implementation for handling actions with Verification Code
    /// </summary>
    public class VerificationCodeService : IVerificationCodeService
    {
        /// <summary>
        /// Service for handling actions related with caching
        /// </summary>
        private readonly ICachingService _cachingService;


        /// <summary>
        /// Service for handling email list sending
        /// </summary>
        private readonly IEmailSenderService _emailSenderService;


        /// <summary>
        /// Service for handling template creating for email lists
        /// </summary>
        private readonly IEmailTemplateService _emailTemplateService;


        /// <summary>
        /// Service for handling validation code generation
        /// </summary>
        private readonly ICodeGenerationService _codeGenerationService;

        /// <summary>
        /// Constructor for Verification Code Service
        /// </summary>
        /// <param name="cachingService">Caching Service</param>
        /// <param name="emailSenderService">Email Sender Service</param>
        /// <param name="emailTemplateService">Email Template Service</param>
        /// <param name="codeGenerationService">Code Generation Service</param>
        public VerificationCodeService(ICachingService cachingService, IEmailSenderService emailSenderService, IEmailTemplateService emailTemplateService, ICodeGenerationService codeGenerationService)
        {
            _cachingService = cachingService;
            _emailSenderService = emailSenderService;
            _emailTemplateService = emailTemplateService;
            _codeGenerationService = codeGenerationService;
        }

        /// <summary>
        /// Implementation of method for preparing verification code and sending
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Completed Task</returns>
        public async Task<UserModel?> SendVerificationCode(string username)
        {
            Log.Information("Retrieved username: {@username}", username);

            Log.Debug("Forming Key for model...");

            string key = $"Model-{username}";

            Log.Information("Formed Key: {@key}", key);

            Log.Debug("Transferring data to Caching Service...");

            var model = await _cachingService.GetUserModelFromCache(key);

            Log.Information("Returned model: {@model}", model);

            if (model is null) return null;

            Log.Debug("Forming Verification Code...");

            int code = _codeGenerationService.GenerateCode();

            Log.Information("Formed Verification Code: {@code}", code);

            Log.Debug("Forming Email Body...");

            string emailBody = _emailTemplateService.VerificationCodeTemplate(username, code);

            Log.Information("Formed Email Body: {@emailBody}", emailBody);

            Log.Debug("Transferring data to Email Sender Service...");

            _emailSenderService.SendEmail(model.Email, "Verification Code", emailBody);

            Log.Debug("Procedure has been successful. Returning model...");

            return model;

        }

        /// <summary>
        /// Implementation of method for removing data from cache
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Completed Task</returns>
        public async Task RemoveDataFromCache(string username)
        {
            Log.Information("Retrieved username: {@username}", username);

            Log.Debug("Forming Key for model...");

            string modelKey = $"Model-{username}";

            Log.Information("Formed Key: {@modelKey}", modelKey);

            Log.Debug("Forming Key for Verification Code...");

            string verificationCodeKey = $"Code-{username}";

            Log.Information("Formed Key: {@verificationCodeKey}", verificationCodeKey);

            Log.Debug("Removing User Model from cache...");

            await _cachingService.RemoveItemFromCache(modelKey);

            Log.Information("User Model successfully removed from cache");

            Log.Debug("Removing Verification Code from cache...");

            await _cachingService.RemoveItemFromCache(verificationCodeKey);

            Log.Information("Verification Code successfully removed from cache");
        }

        /// <summary>
        /// Implementation of method for comparing entered Verification Code
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">Entered Verification Code</param>
        /// <returns>True if code is valid, False if code isn't valid, Null if verification code expired</returns>
        public async Task<bool?> IsVerificationCodeValid(string username, int verificationCode)
        {
            Log.Information("Passed Verification Code for checking: {@verificationCode}", verificationCode);

            Log.Information("Passed Username for key: {@username}", username);

            Log.Debug("Forming Key for getting Verification Code...");

            string key = $"Code-{username}";

            Log.Information("Formed Key: {@key}", key);

            Log.Debug("Transferring data to Caching Service...");

            int? cachedCode = await _cachingService.GetVerificationCodeFromCache(key);

            if (cachedCode is null) return null;

            Log.Information("Cached Verification Code: {@cachedCode}", cachedCode);

            return verificationCode == cachedCode;
        }
    }
}
