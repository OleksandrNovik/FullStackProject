using CollabProj.Application.Interfaces.Repositories;
using CollabProj.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CollabProj.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for User Entity
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Context for work with database
        /// </summary>
        private readonly TopicDbContext _context;

        /// <summary>
        /// User repository constructor
        /// </summary>
        /// <param name="context">Database context</param>
        public UserRepository(TopicDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Implementation of method for adding user to database
        /// </summary>
        /// <param name="user">User, which will be added to the database</param>
        /// <returns>Completed Task</returns>
        public async Task CreateAsync(User user)
        {
            Log.Warning("Adding User: {@user}", user);

            await _context.Users.AddAsync(user);

            Log.Warning("User is created. Saving changes into database...");

            await _context.SaveChangesAsync();

            Log.Information("User successfully added");
        }

        /// <summary>
        /// Implementation of method for getting user without photo by id from database
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>User, which has this Id</returns>
        public async Task<User> GetByIdAsync(int id)
        {
            Log.Warning("Getting user by id from database: {@id}", id);

            return await _context.Users
                                .FirstAsync(user => user.Id == id);
        }

        /// <summary>
        /// Implementation of method for getting user without photo by email from database
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User, which has this Email</returns>
        public async Task<User> GetByEmailAsync(string email)
        {
            Log.Warning("Getting user by email from database: {@email}", email);

            return await _context.Users
                                .FirstAsync(user => user.Email == email);
        }

        /// <summary>
        /// Implementation of method for getting user with photo by id from database
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>User, which has this Id</returns>
        public async Task<User> GetWithPhotoByIdAsync(int id)
        {
            Log.Warning("Getting user with photo by id from database: {@id}", id);

            return await _context.Users
                                .Include(u => u.UserPhoto)
                                .FirstAsync(user => user.Id == id);
        }

        /// <summary>
        /// Implementation of method for getting user with photo by email from database
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User, which has this Email</returns>
        public async Task<User> GetWithPhotoByEmailAsync(string email)
        {
            Log.Warning("Getting user with photo by email from database: {@email}", email);

            return await _context.Users
                                .Include(u => u.UserPhoto)
                                .FirstAsync(user => user.Email == email);
        }

        /// <summary>
        /// Implementation of method for getting all users with photo from database
        /// </summary>
        /// <returns>List of all users</returns>
        public async Task<List<User>> GetAllAsync()
        {
            Log.Warning("Getting every User from database...");

            return await _context.Users
                                .Include(u => u.UserPhoto)
                                .ToListAsync();
        }

        /// <summary>
        /// Implementation of method for getting all users by role with photo from database
        /// </summary>
        /// <param name="role">User's role</param>
        /// <returns>List of all users, which has this Role</returns>
        public async Task<List<User>> GetAllByRoleAsync(Role role)
        {
            Log.Warning("Getting every User by role from database...");

            return await _context.Users
                                .Include(u => u.UserPhoto)
                                .Where(user => user.RoleType == role)
                                .ToListAsync();
        }

        /// <summary>
        /// Implementation of method for updating user in database
        /// </summary>
        /// <param name="user">User for update</param>
        /// <returns>Completed Task</returns>
        public async Task UpdateAsync(User user)
        {
            Log.Warning("Updating user: {@user}", user);

            _context.Users.Update(user);

            Log.Warning("User is updated. Saving changes into database...");

            await _context.SaveChangesAsync();

            Log.Information("User successfully updated");
        }

        /// <summary>
        /// Implementation of method for deleting user from database
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Completed Task</returns>
        public async Task DeleteAsync(int id)
        {
            Log.Warning("Deleting user with id: {@id}", id);

            var user = await _context.Users.FirstAsync(user => user.Id == id);

            Log.Information("User queued for removal has been found in database");

            Log.Warning("Removing user from database...");

            _context.Users.Remove(user);

            Log.Warning("User is removed. Saving changes into database...");

            await _context.SaveChangesAsync();

            Log.Information("User successfully removed");
        }
    }
}
