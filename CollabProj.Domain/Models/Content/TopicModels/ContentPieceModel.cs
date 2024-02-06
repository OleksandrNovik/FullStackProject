using CollabProj.Domain.Entities.Content;

namespace CollabProj.Domain.Models.Content.TopicModels
{
    //TODO: documentation 1
    public class ContentPieceModel
    {
        public int Id { get; set; }
        public string InnerText { get; set; }
        public ContentPieceType Type { get; set; }
    }
}
