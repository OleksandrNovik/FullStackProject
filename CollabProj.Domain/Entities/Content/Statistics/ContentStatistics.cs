using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.Content.Statistics
{
    /// <summary>
    /// Entity for a content statistics,
    /// to store all necessary data
    /// </summary>
    [Table("contentStatistics")]
    public class ContentStatistics
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// When this item was created
        /// </summary>
        [Required]
        [Column("creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Last time some user (including author) viewed content
        /// </summary>
        [Required]
        [Column("lastViewDate")]
        public DateTime LastViewDate { get; set; }

        /// <summary>
        /// Each content can have views from users
        /// </summary>
        public ICollection<FakeUser> Viewed { get; set; }

        /// <summary>
        /// List of users who liked this content
        /// </summary>
        public ICollection<FakeUser> Liked { get; set; }
    }
}
