using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Models.Error;
using CollabProj.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollabProj.Server.Controllers
{
    /// <summary>
    /// Controller for handling Register Requests
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        /// <summary>
        /// Service for handling actions associated with users 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for RegisterController
        /// </summary>
        /// <param name="userService">User Service</param>
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Method for processing user's registration
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>Errors or Successful adding of user</returns>
        [HttpPost]
        public async Task<RegisterErrorModel> Post([FromBody] UserModel model)
        {
            Log.Information("Post request has been made for registration of user");

            Log.Information("Model, retrieved from body: {@model}", model);

            Log.Debug("Initialization of Register Error Model for further processing of data");

            var errors = new RegisterErrorModel() { Success = true };

            Log.Information("Checking if Email is already registered...");

            if (await _userService.GetUserByEmailAsync(model.Email) is null)
            {
                Log.Information("Register has been granted");

                Log.Debug("Transferring data to User Service...");

                await _userService.CreateUserAsync(model);

                Log.Information("User has been created and added. Returning Success...");

                return errors;
            }

            Log.Information("User hasn't been created. Setting up errors...");

            errors.Success = false;
            errors.EmailError = "This email is already registered to other account";

            Log.Information("Errors: {@errors}", errors);

            Log.Information("Returning Errors...");

            return errors;
        }

        //TODO: Add Verification email
    }
}
