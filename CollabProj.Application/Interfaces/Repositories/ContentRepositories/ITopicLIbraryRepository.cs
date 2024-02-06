using CollabProj.Domain.Entities.Content;
using CollabProj.Domain.Entities.User;

namespace CollabProj.Application.Interfaces.Repositories.ContentRepositories
{
    /// <summary>
    /// Interface for topic library repository
    /// </summary>
    public interface ITopicLIbraryRepository : IRepository<TopicLibrary>
    {
        /// <summary>
        /// Gets author of a topic library
        /// </summary>
        /// <param name="libraryId"> Id of topic library that is checked</param>
        /// <returns> Author of topic library </returns>
        public Task<User> GetAuthorAsync(int libraryId);

        /// <summary>
        /// Gets number of topic libraries but sorted by date, so recent are first
        /// </summary>
        /// <param name="number"> Number of recent libraries</param>
        /// <returns> List of libraries sorted by date </returns>
        public Task<List<TopicLibrary>> SelectByDateAsync(int number);

        /// <summary>
        /// Gets libraries, that has most likes
        /// </summary>
        /// <param name="number"> Number of most liked libraries </param>
        /// <returns> List of most liked libraries </returns>
        public Task<List<TopicLibrary>> SelectByLikesAsync(int number);

        /// <summary>
        /// Gets libraries, that has most views
        /// </summary>
        /// <param name="number"> Number of most viewed libraries </param>
        /// <returns> List of most viewed libraries </returns>
        public Task<List<TopicLibrary>> SelectByViewsAsync(int number);

        /// <summary>
        /// Sorts library list before selecting specific number of libraries
        /// </summary>
        /// <param name="specifier"> Specifies what sort characteristic is applied </param>
        /// <returns> Raw data, that can soon be processed more 
        /// (for example we can take a certain number of libraries from list)
        /// </returns>
        public Task<IQueryable<TopicLibrary>> SortByAsync(SortSpecifier specifier);
    }
    /*
        We use sort to select a number of libraries by some conditio
        For example select most recent, most liked etc.
        After sort we just get a requested number of libraries
    */
    /// <summary>
    /// Enum that specifies a sort request
    /// </summary>
    public enum SortSpecifier
    {
        Date, Popularity, Likes
    }
}
