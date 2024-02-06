using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;
using Riok.Mapperly.Abstractions;

namespace CollabProj.Infrastructure.Mappers.UserRelated
{
    /// <summary>
    /// Mapper class for User Entity and User Model
    /// </summary>
    [Mapper]
    public partial class UserMapper
    {
        /// <summary>
        /// Method for mapping User Entity to User Model
        /// </summary>
        /// <param name="user">User Entity</param>
        /// <returns>User Model</returns>
        [MapperIgnoreSourceValue(nameof(User.UserPhoto.Id))]
        [MapProperty(nameof(User.UserPhoto), nameof(UserModel.UserPhotoModel))]
        public partial UserModel UserToUserModel(User user);

        /// <summary>
        /// Method for mapping User Model to User Entity
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>User Entity</returns>
        [MapperIgnoreTargetValue(nameof(User.UserPhoto.Id))]
        [MapProperty(nameof(UserModel.UserPhotoModel), nameof(User.UserPhoto))]
        public partial User UserModelToUser(UserModel model);
    }
}
