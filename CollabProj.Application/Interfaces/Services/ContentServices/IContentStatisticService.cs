namespace CollabProj.Application.Interfaces.Services.ContentServices
{
    /// <summary>
    /// Interface to update statisitcs of the content
    /// </summary>
    public interface IContentStatisticService
    {
        /// <summary>
        /// Updates views on some content 
        /// There is guaranteed update on every content view if some user views it
        /// </summary>
        /// <param name="Id"> Id of statistics </param>
        /// <returns></returns>
        public Task UpdateViewsAsync(int Id);

        /// <summary>
        /// Updates amount of likes at some content statistics
        /// User can like content or not
        /// </summary>
        /// <param name="Id"> Id of content statistics </param>
        /// <param name="likes"> New number of likes </param>
        /// <returns> Completed Task</returns>
        public Task UpdateLikesAsync(int Id, int likes);

    }
}
