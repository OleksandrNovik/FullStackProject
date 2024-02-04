using CollabProj.Domain.Models.User;

namespace CollabProj.Application.Interfaces.Services
{
    /// <summary>
    /// Service interface for caching data
    /// </summary>
    public interface ICachingService
    {
        /// <summary>
        /// Method for getting User Model From Cache
        /// </summary>
        /// <param name="key">Key of User Model</param>
        /// <returns>User Model or null if User Model wasn't cached</returns>
        public Task<UserModel?> GetUserModelFromCache(string key);

        /// <summary>
        /// Method for caching User Model
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>Completed Task</returns>
        public Task AddUserModelToCache(UserModel model);

        /// <summary>
        /// Method for getting Verification Code From Cache
        /// </summary>
        /// <param name="key">Key of Verification Code</param>
        /// <returns>6-digit Verification Code or null if Code wasn't cached</returns>
        public Task<int?> GetVerificationCodeFromCache(string key);

        /// <summary>
        /// Method for caching Verification Code
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">6-digit Verification Code</param>
        /// <returns>Completed Task</returns>
        public Task AddVerificationCodeToCache(string username, int verificationCode);
    }
}
