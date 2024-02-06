using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollabProj.Domain.Entities.Content
{
    /// <summary>
    /// Entity for a content piece to describe its characteristics
    /// </summary>
    [Table("contentPieces")]
    public class ContentPiece
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Type of this content piece
        /// </summary>
        [Required]
        [Column("type")]
        public ContentPieceType Type { get; set; }

        /// <summary>
        /// Text information in this content piece
        /// </summary>
        [Required]
        [Column("innerText")]
        public string InnerText { get; set; }

        /// <summary>
        /// Topic this content piece belongs
        /// </summary>
        public Topic Topic { get; set; }
    }
    /// <summary>
    /// Types of content pieces that can be placed at topics
    /// </summary>
    public enum ContentPieceType
    {
        Header,
        Text,
        Code
    }
}
