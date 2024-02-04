using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Models.User;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;

namespace CollabProj.Infrastructure.Services
{
    /// <summary>
    /// Implementation of service for caching data
    /// </summary>
    public class CachingService : ICachingService
    {
        /// <summary>
        /// Distributed Cache storage
        /// </summary>
        private readonly IDistributedCache _distributedCache;

        /// <summary>
        /// Constructor for Caching Service
        /// </summary>
        /// <param name="distributedCache">Distributed Cache</param>
        public CachingService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        /// <summary>
        /// Implementation of method for getting User Model From Cache
        /// </summary>
        /// <param name="key">Key of User Model</param>
        /// <returns>User Model or null if User Model wasn't cached</returns>
        public async Task<UserModel?> GetUserModelFromCache(string key)
        {
            Log.Information("Passed key for getting User Model: {@key}", key);

            Log.Debug("Getting User Model from distributed cache...");

            var modelString = await _distributedCache.GetStringAsync(key);

            Log.Information("User Model gotten from distributed cache: {@modelString}", modelString);

            return modelString is not null ? JsonConvert.DeserializeObject<UserModel>(modelString) : null;
        }

        /// <summary>
        /// Implementation of method for caching User Model
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>Completed Task</returns>
        public async Task AddUserModelToCache(UserModel model)
        {
            Log.Information("Passed User model for caching: {@model}", model);

            Log.Debug("Forming Key for model...");

            string key = $"Model-{model.Username}";

            Log.Information("Formed Key: {@key}", key);

            Log.Debug("Forming Serialized User model...");

            string modelString = JsonConvert.SerializeObject(model);

            Log.Information("Formed Serialized User model: {@modelString}", modelString);

            Log.Debug("Caching User model for 30 minutes...");

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            };

            await _distributedCache.SetStringAsync(key, modelString, cacheOptions);

            Log.Information("User model was successfully cached");
        }

        /// <summary>
        /// Implementation of method for getting Verification Code From Cache
        /// </summary>
        /// <param name="key">Key of Verification Code</param>
        /// <returns>6-digit Verification Code or null if Code wasn't cached</returns>
        public async Task<int?> GetVerificationCodeFromCache(string key)
        {
            Log.Information("Passed key for getting Verification Code: {@key}", key);

            Log.Debug("Getting Verification Code from distributed cache...");

            var verificationCodeString = await _distributedCache.GetStringAsync(key);

            Log.Information("Verification Code gotten from distributed cache: {@verificationCodeString}", verificationCodeString);

            return verificationCodeString is not null ? JsonConvert.DeserializeObject<int>(verificationCodeString) : null;
        }

        /// <summary>
        /// Implementation of method for caching Verification Code
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">6-digit Verification Code</param>
        /// <returns>Completed Task</returns>
        public async Task AddVerificationCodeToCache(string username, int verificationCode)
        {
            Log.Information("Passed Verification Code for caching: {@verificationCode}", verificationCode);

            Log.Information("Passed Username for key: {@username}", username);

            Log.Debug("Forming Key for Verification Code...");

            string key = $"Code-{username}";

            Log.Information("Formed Key: {@key}", key);

            Log.Debug("Forming Serialized Validation Code...");

            string codeString = JsonConvert.SerializeObject(verificationCode);

            Log.Information("Formed Serialized Validation Code: {@codeString}", codeString);

            Log.Debug("Caching Verification Code for 30 minutes...");

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            };

            await _distributedCache.SetStringAsync(key, codeString, cacheOptions);

            Log.Information("Verification Code was successfully cached");
        }
    }
}
