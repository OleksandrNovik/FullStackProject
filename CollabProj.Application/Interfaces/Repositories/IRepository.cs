namespace CollabProj.Application.Interfaces.Repositories
{
    /// <summary>
    /// General repository interface
    /// </summary>
    /// <typeparam name="T"> Type of entity methods should work with </typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets item from db by its id
        /// </summary>
        /// <param name="id"> Id of item </param>
        /// <returns> Item, if it was found </returns>
        public Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Adds new item to db
        /// </summary>
        /// <param name="data"> All data about item </param>
        /// <returns> Completed Task </returns>
        public Task CreateAsync(T data);

        /// <summary>
        /// Updates item in db
        /// </summary>
        /// <param name="data"> New data about item </param>
        /// <returns> Completed Task </returns>
        public Task UpdateAsync(T data);

        /// <summary>
        /// Deletes item fromc db
        /// </summary>
        /// <param name="id"> Id of item we are deleting </param>
        /// <returns> Completed Task </returns>
        public Task DeleteAsync(int id);

        /// <summary>
        /// Gets number of entities from db
        /// </summary>
        /// <returns> List of entities found in db </returns>
        public Task<List<T>> GetAllAsync();

    }
}
