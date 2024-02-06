using CollabProj.Domain.Entities.Content.Statistics;

namespace CollabProj.Application.Interfaces.Repositories.ContentRepositories
{
    /// <summary>
    /// Interface to handle updates of statistics in db
    /// </summary>
    public interface IContentStatisticsRepository
    {
        /// <summary>
        /// Updates statistics data in db for a certain item
        /// </summary>
        /// <param name="data"> New statistics data </param>
        /// <returns> Completed Task </returns>
        public Task UpdateStatistics(ContentStatistics data);

    }
}
