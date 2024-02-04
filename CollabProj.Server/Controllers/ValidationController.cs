using CollabProj.Application.Interfaces.Services;
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
        /// Constructor for Validation Controller
        /// </summary>
        /// <param name="userService">User Service</param>
        public ValidationController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Method for getting user for validation and sending code to him
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Errors or Successful adding of user</returns>
        [HttpGet("{id}")]
        public async Task<UserModel> GetValidation(int id)
        {
            Log.Information("GET request has been made for user validation");

            Log.Information("Id, retrieved from URL: {@id}", id);

            Log.Debug("Transferring data to User Service...");

            var model = await _userService.GetUserByIdAsync(id);
            //TODO: Add code generation

            return model;
        }

        /// <summary>
        /// Method for Validation of Code, which user entered
        /// </summary>
        /// <param name="validationCode">Validation Code</param>
        /// <returns>Errors or Successful validation of user</returns>
        [HttpPost("[action]")]
        public async Task<ValidationErrorModel> ValidateCode([FromBody] int validationCode)
        {
            Log.Information("POST request has been made for validation code submittion");

            Log.Information("Code, retrieved from body: {@model}", validationCode);

            Log.Debug("Initialization of Validation Error Model for further processing of data");

            var errors = new ValidationErrorModel() { Success = true };

            Log.Information("Checking code....");

            //TODO: Add code check
            if (false)
            {
                Log.Information("Validation Code is Valid");
                return errors;
            }

            Log.Information("Code isn't Valid. Setting up errors...");

            errors.Success = false;
            errors.ValidationCodeError = "Validation Code isn't correct. Try again";

            Log.Information("Errors: {@errors}", errors);

            Log.Information("Returning Errors...");

            return errors;
        }
    }
}
