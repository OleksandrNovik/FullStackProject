using CollabProj.Application.Interfaces.Services;
using CollabProj.Application.Interfaces.Services.Email;
using CollabProj.Application.Interfaces.Services.VerificationCode;
using CollabProj.Domain.Models.Error;
using CollabProj.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollabProj.Server.Controllers
{
    /// <summary>
    /// Controller for handling Validation
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        /// <summary>
        /// Service for handling actions associated with users 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Service for handling actions related with cache
        /// </summary>
        private readonly ICachingService _cachingService;

        /// <summary>
        /// Service for handling actions associated with verification code
        /// </summary>
        private readonly IVerificationCodeService _verificationCodeService;

        /// <summary>
        /// Constructor for Validation Controller
        /// </summary>
        /// <param name="userService">User Service</param>
        /// <param name="verificationCodeService">Verification Code Service</param>
        public ValidationController(IUserService userService, ICachingService cachingService, IVerificationCodeService verificationCodeService)
        {
            _userService = userService;
            _cachingService = cachingService;
            _verificationCodeService = verificationCodeService;
        }

        /// <summary>
        /// Method for getting user for validation and sending code to him
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Errors or Successful adding of user</returns>
        [HttpGet("{username}")]
        public async Task<UserModel?> GetValidation(string username)
        {
            Log.Information("GET request has been made for user validation");

            Log.Information("Username, retrieved from URL: {@username}", username);

            Log.Debug("Transferring data into Verification Code Service...");

            var model = await _verificationCodeService.SendVerificationCode(username);

            Log.Information("Model: {@model}", model);

            Log.Information("Verification code has been cached and sent");

            return model;
        }

        /// <summary>
        /// Method for Validation of Code, which user entered
        /// </summary>
        /// <param name="verificationCode">Verification Code</param>
        /// <returns>Errors or Successful validation of user</returns>
        [HttpPost("[action]/{username}")]
        public async Task<ValidationErrorModel> ValidateCode([FromBody] int verificationCode, string username)
        {
            Log.Information("POST request has been made for verification code submittion");

            Log.Information("Code, retrieved from body: {@verificationCode}", verificationCode);

            Log.Information("Username, retrieved from URL: {@username}", username);

            Log.Debug("Initialization of Validation Error Model for further processing of data");

            var errors = new ValidationErrorModel() { Success = true };

            Log.Information("Checking code....");

            Log.Debug("Transferring data into Verification Code Service...");

            bool? isValid = await _verificationCodeService.IsVerificationCodeValid(username, verificationCode);

            if (isValid is true)
            {
                Log.Information("Validation Code is Valid");

                Log.Debug("Transferring data into Verification Code Service...");

                var model = await _cachingService.GetUserModelFromCache($"Model-{username}");

                Log.Information("Model: {@model}", model);

                Log.Debug("Transferring data into Verification Code Service...");

                await _verificationCodeService.RemoveDataFromCache(username);

                Log.Information("Data Removed from Cache");

                Log.Debug("Transferring data into User Service...");

                await _userService.CreateUserAsync(model);

                Log.Information("User added to database");

                return errors;
            }

            Log.Information("Code isn't Valid. Setting up errors...");

            string errorText = "Validation Code isn't correct. Try again";

            if (isValid is null)
            {
                var model = _verificationCodeService.SendVerificationCode(username);

                errorText = model is null ?
                    "Verification period expired. Register account again"
                    : "Verification code has been resent on your email";
            }

            errors.Success = false;
            errors.ValidationCodeError = errorText;

            Log.Information("Errors: {@errors}", errors);

            Log.Information("Returning Errors...");

            return errors;
        }
    }
}
