using CollabProj.Domain.Models.Content;

namespace CollabProj.Application.Interfaces.Services.ContentServices
{
    /// <summary>
    /// Interface to be implemented by topic library service  
    /// </summary>
    public interface ITopicLibraryService
    {
        /// <summary>
        /// Creates new empty topic library
        /// </summary>
        /// <param name="data"> Library data </param>
        /// <returns> Completed Task </returns>
        public Task CreateLibraryAsync(TopicLibraryModel data);

        /// <summary>
        /// This method should edit topic library (its title or topic list)
        /// </summary>
        /// <param name="library"> New information about library </param>
        /// <returns> Completed Task </returns>
        public Task EditLibraryAsync(TopicLibraryModel library);

        /// <summary>
        /// Method should delete library by its id
        /// </summary>
        /// <param name="id"> Id of library </param>
        /// <returns> Completed Task </returns>
        public Task DeleteLibraryAsync(int id);

        /// <summary>
        /// Method should get topic library by its Id
        /// </summary>
        /// <param name="id"> Id of topic library </param>
        /// <returns> Topic library if it was found </returns>
        public Task<TopicLibraryModel?> GetLibraryByIdAsync(int id);

        /// <summary>
        /// Checks if current user can edit topic library
        /// </summary>
        /// <param name="username"> Username of current user </param>
        /// <param name="libraryId"> Id of topic library </param>
        /// <returns> true if user is author, so he has permission to edit content, false if user can only read library</returns>
        public Task<bool> IsAuthorAsync(string username, int libraryId);

        /// <summary>
        /// Method to select first 'number' topic libraries
        /// </summary>
        /// <param name="number"> Number of libraries to select (selects all if not provided) </param>
        /// <returns> List of first topic libraries </returns>
        public Task<List<TopicLibraryModel>> SelectFirstAsync(int number);

        /// <summary>
        /// Method should look through libraries list and find most recent
        /// </summary>
        /// <param name="number"> Number of first recent topics (if is not provided selects all of them) </param>
        /// <returns> List of most recent topics </returns>
        public Task<List<TopicLibraryModel>> SelectRecentAsync(int number);

        /// <summary>
        /// Method to find most popular (by views) topic libraries
        /// </summary>
        /// <param name="number"> Number of topic libraries to select (if not provided selects all of the libraries) </param>
        /// <returns> List of most popular topic libraries </returns>
        public Task<List<TopicLibraryModel>> SelectMostPopularAsync(int number);

        /// <summary>
        /// Selects most liked libraries
        /// </summary>
        /// <param name="number"> Number of topic libraries to select (if not provided selects all of libraries) </param>
        /// <returns> List of most liked topic libraries </returns>
        public Task<List<TopicLibraryModel>> SelectMostLikedAsync(int number);

        /// <summary>
        /// Selects each topic library of certain author
        /// </summary>
        /// <param name="authorName"> Nickname of author </param>
        /// <returns> List of libraries that this author created </returns>
        public Task<List<TopicLibraryModel>> SelectAllByAuthorAsync(string authorName);

        /// <summary>
        /// Selects all liked topic libraries by current user
        /// </summary>
        /// <param name="username"> Nickname of current user </param>
        /// <returns> List of liked libraries </returns>
        public Task<List<TopicLibraryModel>> SelectAllLikedAsync(string username);


    }
}
