using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.User
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
        [Required]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// URL of the user photo.
        /// </summary>
        [Required]
        [Column("url")]
        public string PhotoURL { get; set; }

        /// <summary>
        /// Mapping property for User (One-To-One relationship)
        /// </summary>
        public virtual User User { get; set; }
    }
}
