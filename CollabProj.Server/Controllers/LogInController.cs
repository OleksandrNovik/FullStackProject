using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Models.Error;
using CollabProj.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollabProj.Server.Controllers
{
    /// <summary>
    /// Controller for handling LogIn
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LogInController : ControllerBase
    {
        /// <summary>
        /// Service for handling actions associated with users 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for LogIn Controller
        /// </summary>
        /// <param name="userService">User Service</param>
        public LogInController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Method for processing user's authentication
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>Errors or Successful authentication of user</returns>
        [HttpPost]
        public async Task<LogInErrorModel> Authenticate([FromBody] UserModel model)
        {
            //TODO: Authentication
            Log.Information("POST request has been made for authentication of user");

            Log.Information("Model, retrieved from body: {@model}", model);

            Log.Debug("Initialization of LogIn Error Model for further processing of data");

            var errors = new LogInErrorModel() { Success = true };

            Log.Information("Checking password...");

            if (false)
            {
                Log.Information("Authentication has been granted");

                Log.Debug("Transferring data to User Service...");

                Log.Information("User has been authenticated. Returning Success...");

                return errors;
            }

            Log.Information("Password isn't correct. Setting up errors...");

            errors.Success = false;
            errors.PasswordError = "Password isn't correct. Try again";

            Log.Information("Errors: {@errors}", errors);

            Log.Information("Returning Errors...");

            return errors;
        }
    }
}
