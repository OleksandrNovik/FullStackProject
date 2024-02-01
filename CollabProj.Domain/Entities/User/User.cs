using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.User
{
    /// <summary>
    /// User entity.
    /// </summary>
    [Table("user")]
    public class User
    {
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Username for user.
        /// </summary>
        [Required]
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// Email for user.
        /// </summary>
        [Required]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Password for user.
        /// </summary>
        [Required]
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Role for user.
        /// </summary>
        [Column("role")]
        public Role RoleType { get; set; }

        /// <summary>
        /// Creation date of user account.
        /// </summary>
        [Column("creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Last login date of user account.
        /// </summary>
        [Column("lastLoginDate")]
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Mapping property for UserPhoto (One-To-One relationship)
        /// </summary>
        public UserPhoto? UserPhoto { get; set; }
    }

    /// <summary>
    /// All possible roles for user
    /// </summary>
    public enum Role
    {
        normal,
        author,
        admin
    }
}
