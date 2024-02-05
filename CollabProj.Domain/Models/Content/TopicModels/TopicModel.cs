namespace CollabProj.Domain.Models.Content.TopicModels
{
    //TODO: documentation
    public class TopicModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ContentStatisticsModel Statistics { get; set; }
        public List<ContentPieceModel> Content { get; set; }
    }
}
