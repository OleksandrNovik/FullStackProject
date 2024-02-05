using CollabProj.Domain.Entities.User;

namespace CollabProj.Application.Interfaces.Repositories
{
    /// <summary>
    /// Repository Interface for User Entity
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Method for adding user to database
        /// </summary>
        /// <param name="user">User, which will be added to the database</param>
        /// <returns>Completed Task</returns>
        public Task CreateAsync(User user);

        /// <summary>
        /// Method for getting user without photo by id from database
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>User, which has this Id or null if user wasn't found</returns>
        public Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Method for getting user without photo by email from database
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User, which has this Email or null if user wasn't found</returns>
        public Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Method for getting user without photo by username from database
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>User, which has this Username or null if user wasn't found</returns>
        public Task<User?> GetByUsernameAsync(string username);

        /// <summary>
        /// Method for getting user with photo by id from database
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>User, which has this Id</returns>
        public Task<User> GetWithPhotoByIdAsync(int id);

        /// <summary>
        /// Method for getting user with photo by email from database
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User, which has this Email</returns>
        public Task<User> GetWithPhotoByEmailAsync(string email);

        /// <summary>
        /// Method for getting user with photo by username from database
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>User, which has this Username</returns>
        public Task<User> GetWithPhotoByUsernameAsync(string username);

        /// <summary>
        /// Method for getting all users with photo from database
        /// </summary>
        /// <returns>List of all users</returns>
        public Task< List<User> > GetAllAsync();

        /// <summary>
        /// Method for getting all users with photo by role from database
        /// </summary>
        /// <param name="role">User's role</param>
        /// <returns>List of all users, which has this Role</returns>
        public Task< List<User> > GetAllByRoleAsync(Role role);

        /// <summary>
        /// Method for updating user in database
        /// </summary>
        /// <param name="user">User for update</param>
        /// <returns>Completed Task</returns>
        public Task UpdateAsync(User user);

        /// <summary>
        /// Method for deleting user from database
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Completed Task</returns>
        public Task DeleteAsync(int id);
    }
}
