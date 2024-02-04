using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CollabProj.Server.Controllers
{
    /// <summary>
    /// Controller for handling Profile actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// Service for handling actions associated with users 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for Profile Controller
        /// </summary>
        /// <param name="userService">User Service</param>
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Method to retrieve User Model data for a Profile page
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>User Model</returns>
        [HttpGet("{username}")]
        public async Task<UserModel> GetProfile(string username)
        {
            Log.Information("GET request has been made for user profile model");

            Log.Information("Username, retrieved url: {@username}", username);

            Log.Debug("Transferring data to User Service...");

            var model = await _userService.GetUserWithPhotoByUsernameAsync(username);

            Log.Information("Model retrieved from service: {@model}", model);

            return model;
        }

        /// <summary>
        /// Method for handling image change (update of image)
        /// </summary>
        /// <param name="file">Image</param>
        /// <param name="username">User's username</param>
        /// <returns>Completed Task</returns>
        [HttpPatch("[action]/{username}")]
        public async Task ChangeImage([FromBody] IFormFile file, string username)
        {
            //TODO: Add Image saving
        }

        /// <summary>
        /// Method for handling user's data change
        /// </summary>
        /// <param name="model">Updated User Model</param>
        /// <returns>Completed Task</returns>
        [HttpPatch("[action]")]
        public async Task ChangeUsername([FromBody] UserModel model)
        {
            Log.Information("PATCH request has been made for change of user's data");

            Log.Information("Model, retrieved from body: {@model}", model);

            Log.Debug("Transferring data to User Service...");

            await _userService.UpdateUserAsync(model);

            Log.Information("User has been successfully updated");
        }
    }
}
