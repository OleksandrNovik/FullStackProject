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
        /// Number of Likes at this content
        /// </summary>
        [Required]
        [Column("likes")]
        public int Likes { get; set; } = 0;

        /// <summary>
        /// Number of views
        /// </summary>
        [Required]
        [Column("views")]
        public int Views { get; set; } = 0;

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
    }
}
