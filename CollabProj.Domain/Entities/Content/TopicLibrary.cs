using CollabProj.Domain.Entities.Content.Statistics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.Content
{
    /// <summary>
    /// This is the collection of topics
    /// </summary>
    [Table("topicLibraries")]
    public class TopicLibrary
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Title of this collection
        /// </summary>
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Author of those topics
        /// </summary>
        //TODO: Replace empty User with entity
        public FakeUser Author { get; set; }

        /// <summary>
        /// Statistics for an entire library (summary if you liked or not all of topics)
        /// </summary>
        public ContentStatistics Statistics { get; set; }

        /// <summary>
        /// Topic library can have topics in it
        /// </summary>
        public ICollection<Topic>? Topics { get; set; }

    }
}
