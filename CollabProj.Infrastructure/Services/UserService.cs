using CollabProj.Application.Interfaces.Repositories;
using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;
using CollabProj.Infrastructure.Mappers.UserRelated;
using Serilog;

namespace CollabProj.Infrastructure.Services
{
    /// <summary>
    /// Service Implementation for processing data from database
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Repository for work with users
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Mapper for User Entities and Models
        /// </summary>
        private readonly UserMapper _userMapper;

        /// <summary>
        /// User service constructor
        /// </summary>
        /// <param name="repository">User repository</param>
        public UserService(IUserRepository repository)
        {
            _repository = repository;
            _userMapper = new UserMapper();
        }

        /// <summary>
        /// Implementation of method for mapping User Model to User Entity and adding into database
        /// </summary>
        /// <param name="model">User</param>
        /// <returns>Completed Task</returns>
        public async Task CreateUserAsync(UserModel model)
        {
            Log.Information("Retrieved User Model for database creation: {@model}", model);

            Log.Warning("Mapping User Model to User Entity...");

            var user = _userMapper.UserModelToUser(model);

            Log.Information("User Model successfully mapped to User Entity");

            Log.Information("Mapped User Entity: {@user}", user);

            Log.Information("Transferring data to the repository...");

            await _repository.CreateAsync(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity without photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            Log.Information("Id for retrieving User from database: {@id}", id);

            Log.Information("Transferring data to the repository...");

            var user = await _repository.GetByIdAsync(id);

            Log.Information("User Entity was received from repository: {@user}",  user);

            Log.Warning("Mapping User Entity to User Model...");

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity without photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            Log.Information("Email for retrieving User from database: {@email}", email);

            Log.Information("Transferring data to the repository...");

            var user = await _repository.GetByEmailAsync(email);

            Log.Information("User Entity was received from repository: {@user}", user);

            Log.Warning("Mapping User Entity to User Model...");

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity with photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserWithPhotoByIdAsync(int id)
        {
            Log.Information("Id for retrieving User with photo from database: {@id}", id);

            Log.Information("Transferring data to the repository...");

            var user = await _repository.GetWithPhotoByIdAsync(id);

            Log.Information("User Entity with photo was received from repository: {@user}", user);

            Log.Warning("Mapping User Entity with photo to User Model with photo...");

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity with photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserWithPhotoByEmailAsync(string email)
        {
            Log.Information("Email for retrieving User with photo from database: {@email}", email);

            Log.Information("Transferring data to the repository...");

            var user = await _repository.GetWithPhotoByEmailAsync(email);

            Log.Information("User Entity with photo was received from repository: {@user}", user);

            Log.Warning("Mapping User Entity with photo to User Model with photo...");

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting List of User Entities with photos from database and mapping it into List of User Models
        /// </summary>
        /// <returns>List of Mapped User Models</returns>
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var userList = await _repository.GetAllAsync();

            Log.Information("Retrieved List of Users from database: {@userList}", userList);

            Log.Warning("Mapping User Entities List to User Model List...");

            return userList.Select(user => _userMapper.UserToUserModel(user)).ToList();
        }

        /// <summary>
        /// Implementation of method for getting List of User Entities with photos by Role from database and mapping it into List of User Models
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>List of Mapped User Models</returns>
        public async Task<List<UserModel>> GetAllUsersByRoleAsync(Role role)
        {
            Log.Information("Transferring data to the repository...");

            var userList = await _repository.GetAllByRoleAsync(role);

            Log.Information("Retrieved List of Users by role from database: {@userList}", userList);

            Log.Warning("Mapping User Entities List to User Model List...");

            return userList.Select(user => _userMapper.UserToUserModel(user)).ToList();
        }

        /// <summary>
        /// Implementation of method for mapping User Model into User Entity and updating it in database
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Completed Task</returns>
        public async Task UpdateUserAsync(UserModel model)
        {
            Log.Information("Retrieved User Model for database updating: {@model}", model);

            Log.Warning("Mapping User Model to User Entity...");

            var user = _userMapper.UserModelToUser(model);

            Log.Information("User Model successfully mapped to User Entity");

            Log.Information("Mapped User Entity: {@user}", user);

            Log.Information("Transferring data to the repository...");

            await _repository.UpdateAsync(user);
        }

        /// <summary>
        /// Implementation of method for deleting User from database
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Completed Task</returns>
        public async Task DeleteUserAsync(int id)
        {
            Log.Information("Id for removing User from database: {@id}", id);

            Log.Information("Transferring data to the repository...");

            await _repository.DeleteAsync(id);
        }
    }
}
