using CollabProj.Domain.Entities.Content.Statistics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.Content
{
    /// <summary>
    /// Entity for a single topic
    /// </summary>
    [Table("topics")]
    public class Topic
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Topic title
        /// </summary>
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Topic library this topics belongs
        /// </summary>
        public TopicLibrary TopicLibrary { get; set; }

        /// <summary>
        /// Statistic of this topic (article)
        /// </summary>
        public ContentStatistics Statistics { get; set; }

        /// <summary>
        /// Topic has its content, which consists of pieces with given type and other information
        /// </summary>
        public List<ContentPiece>? TopicContent { get; set; }
    }
}
