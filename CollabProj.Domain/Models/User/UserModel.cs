using CollabProj.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabProj.Domain.Models.User
{
    /// <summary>
    /// User model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Username for user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email for user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password for user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role for user.
        /// </summary>
        public Role? RoleType { get; set; }

        /// <summary>
        /// Creation date of user account.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Last login date of user account.
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// User's Photo
        /// </summary>
        public UserPhotoModel? UserPhotoModel { get; set; }
    }
}
