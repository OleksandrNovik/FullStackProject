using CollabProj.Domain.Models.Content.TopicModels;

namespace CollabProj.Application.Interfaces.Services.ContentServices
{
    /// <summary>
    /// Interface for a topic service
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// Creates new topic with provided data
        /// </summary>
        /// <param name="data"> Data for a new topic </param>
        /// <returns> Completed Task </returns>
        public Task CreateTopicAsync(TopicModel data);

        /// <summary>
        /// Edits topic title or its content if changed
        /// </summary>
        /// <param name="topic"> New Data about this topic </param>
        /// <returns> Completed Task </returns>
        public Task EditTopicAsync(TopicModel topic);

        /// <summary>
        /// Deletes all data about topic by its id
        /// </summary>
        /// <param name="id"> Id of the topic </param>
        /// <returns> Completed Task </returns>
        public Task DeleteTopicAsync(int id);

        /// <summary>
        /// Method selects topic by its id
        /// </summary>
        /// <param name="id"> Id of topic </param>
        /// <returns> Topic if it was found </returns>
        public Task<TopicModel?> GetTopicByIdAsync(int id);
    }
}
