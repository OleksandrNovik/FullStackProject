using CollabProj.Domain.Entities.Content;
using CollabProj.Domain.Models.Content.TopicModels;

namespace CollabProj.Domain.Models.Content
{
    //TODO: documentation 1
    public class TopicLibraryModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public FakeUser? Author { get; set; }
        public ContentStatisticsModel? Statistics { get; set; }
        public List<TopicModel>? Topics { get; set; }
        public bool? IsLiked { get; set; }
    }
}
