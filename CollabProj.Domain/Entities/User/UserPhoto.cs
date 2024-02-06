using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.UserRelated
{
    /// <summary>
    /// User photo entity.
    /// </summary>
    [Table("user_photo")]
    public class UserPhoto
    {
        /// <summary>
        /// Unique identifier for the user photo.
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// URL of the user photo.
        /// </summary>
        [Required]
        [Column("url")]
        public string PhotoURL { get; set; }

        /// <summary>
        /// Mapping property for User (One-To-One relationship)
        /// </summary>
        public User User { get; set; }
    }
}
