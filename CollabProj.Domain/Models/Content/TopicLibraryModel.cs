using CollabProj.Domain.Models.Content.TopicModels;
using CollabProj.Domain.Models.User;

namespace CollabProj.Domain.Models.Content
{
    //TODO: documentation
    public class TopicLibraryModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public UserModel? Author { get; set; }
        public ContentStatisticsModel? Statistics { get; set; }
        public List<TopicModel>? Topics { get; set; }
        public bool? IsLiked { get; set; }
    }
}
