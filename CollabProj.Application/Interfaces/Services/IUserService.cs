using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;

namespace CollabProj.Application.Interfaces.Services
{
    /// <summary>
    /// Service Interface for processing data from database
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method for mapping User Model to User Entity and adding into database
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Completed Task</returns>
        public Task CreateUserAsync(UserModel model);

        /// <summary>
        /// Method for getting User Entity without photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserByIdAsync(int id);

        /// <summary>
        /// Method for getting User Entity without photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserByEmailAsync(string email);

        /// <summary>
        /// Method for getting User Entity without photo by username from database and mapping it into Model
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Method for getting User Entity with photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserWithPhotoByIdAsync(int id);

        /// <summary>
        /// Method for getting User Entity with photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserWithPhotoByEmailAsync(string email);

        /// <summary>
        /// Method for getting User Entity with photo by username from database and mapping it into Model
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Mapped User Model</returns>
        public Task<UserModel> GetUserWithPhotoByUsernameAsync(string username);

        /// <summary>
        /// Method for getting List of User Entities with photos from database and mapping it into List of User Models
        /// </summary>
        /// <returns>List of Mapped User Models</returns>
        public Task< List<UserModel> > GetAllUsersAsync();

        /// <summary>
        /// Method for getting List of User Entities with photos by Role from database and mapping it into List of User Models
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>List of Mapped User Models</returns>
        public Task< List<UserModel> > GetAllUsersByRoleAsync(Role role);

        /// <summary>
        /// Method for mapping User Model into User Entity and updating it in database
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Completed Task</returns>
        public Task UpdateUserAsync(UserModel model);

        /// <summary>
        /// Method for deleting User from database
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Completed Task</returns>
        public Task DeleteUserAsync(int id);
    }
}
