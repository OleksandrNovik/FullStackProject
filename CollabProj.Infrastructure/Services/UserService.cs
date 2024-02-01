using CollabProj.Application.Interfaces.Repositories;
using CollabProj.Application.Interfaces.Services;
using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;
using CollabProj.Infrastructure.Mappers.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var userMapper = new UserMapper();

            var user = _userMapper.UserModelToUser(model);

            await _repository.CreateAsync(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity without photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity without photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _repository.GetByEmailAsync(email);

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity with photo by id from database and mapping it into Model
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserWithPhotoByIdAsync(int id)
        {
            var user = await _repository.GetWithPhotoByIdAsync(id);

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting User Entity with photo by email from database and mapping it into Model
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>Mapped User Model</returns>
        public async Task<UserModel> GetUserWithPhotoByEmailAsync(string email)
        {
            var user = await _repository.GetWithPhotoByEmailAsync(email);

            return _userMapper.UserToUserModel(user);
        }

        /// <summary>
        /// Implementation of method for getting List of User Entities with photos from database and mapping it into List of User Models
        /// </summary>
        /// <returns>List of Mapped User Models</returns>
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var userList = await _repository.GetAllAsync();
            return userList.Select(user => _userMapper.UserToUserModel(user)).ToList();
        }

        /// <summary>
        /// Implementation of method for getting List of User Entities with photos by Role from database and mapping it into List of User Models
        /// </summary>
        /// <param name="role">Role</param>
        /// <returns>List of Mapped User Models</returns>
        public async Task<List<UserModel>> GetAllUsersByRoleAsync(Role role)
        {
            var userList = await _repository.GetAllByRoleAsync(role);
            return userList.Select(user => _userMapper.UserToUserModel(user)).ToList();
        }

        /// <summary>
        /// Implementation of method for mapping User Model into User Entity and updating it in database
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Completed Task</returns>
        public async Task UpdateUserAsync(UserModel model)
        {
            var user = _userMapper.UserModelToUser(model);
            await _repository.UpdateAsync(user);
        }

        /// <summary>
        /// Implementation of method for deleting User from database
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Completed Task</returns>
        public async Task DeleteUserAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
