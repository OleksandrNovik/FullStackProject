using CollabProj.Domain.Models.User;

namespace CollabProj.Application.Interfaces.Services.VerificationCode
{
    /// <summary>
    /// Service Interface for handling actions with Verification Code
    /// </summary>
    public interface IVerificationCodeService
    {
        /// <summary>
        /// Method for preparing verification code and sending
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns> True if Verification Code is sent, False if it isn't sent</returns>
        public Task<UserModel?> SendVerificationCode(string username);

        /// <summary>
        /// Method for removing data from cache
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Completed Task</returns>
        public Task RemoveDataFromCache(string username);

        /// <summary>
        /// Method for comparing entered Verification Code
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">Entered Verification Code</param>
        /// <returns>True if code is valid, False if code isn't valid, Null if verification code expired</returns>
        public Task<bool?> IsVerificationCodeValid(string username, int verificationCode);
    }
}
