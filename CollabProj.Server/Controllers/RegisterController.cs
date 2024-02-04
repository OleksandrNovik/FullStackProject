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
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        /// <summary>
        /// Service for handling actions associated with users 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for Register Controller
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
        public async Task<RegisterErrorModel> Register([FromBody] UserModel model)
        {
            Log.Information("POST request has been made for registration of user");

            Log.Information("Model, retrieved from body: {@model}", model);

            Log.Debug("Initialization of Register Error Model for further processing of data");

            var errors = new RegisterErrorModel() { Success = true };

            Log.Information("Checking if Email is unique and username is unique...");

            bool isEmailUnique = await _userService.GetUserByEmailAsync(model.Email) is null;

            bool isUsernameUnique = await _userService.GetUserByUsernameAsync(model.Username) is null;

            if (isEmailUnique && isUsernameUnique)
            {
                Log.Information("Register has been granted");

                Log.Debug("Transferring data to Caching Service...");

                await _userService.CreateUserAsync(model);

                Log.Information("User has been cached. Returning Success...");

                return errors;
            }

            Log.Information("User hasn't been created. Setting up errors...");

            errors.Success = false;
            errors.EmailError = !isEmailUnique ? "This email is already registered to other account" : "";
            errors.UsernameError = !isUsernameUnique ? "This username is already taken by other user" : "";

            Log.Information("Errors: {@errors}", errors);

            Log.Information("Returning Errors...");

            return errors;
        }
    }
}
