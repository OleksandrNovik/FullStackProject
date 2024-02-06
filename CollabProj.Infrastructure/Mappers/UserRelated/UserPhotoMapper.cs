using CollabProj.Domain.Entities.UserRelated;
using CollabProj.Domain.Models.User;
using Riok.Mapperly.Abstractions;

namespace CollabProj.Infrastructure.Mappers.UserRelated
{
    /// <summary>
    /// Mapper class for UserPhoto Entity and UserPhoto Model
    /// </summary>
    [Mapper]
    public partial class UserPhotoMapper
    {
        /// <summary>
        /// Method for mapping UserPhoto Entity to UserPhoto Model
        /// </summary>
        /// <param name="photo">UserPhoto Entity</param>
        /// <returns>UserPhoto Model</returns>
        [MapperIgnoreSourceValue(nameof(UserPhoto.Id))]
        public partial UserPhotoModel UserPhotoToUserPhotoModel(UserPhoto photo);

        /// <summary>
        /// Method for mapping UserPhoto Model to UserPhoto Entity
        /// </summary>
        /// <param name="model">UserPhoto Model</param>
        /// <returns>UserPhoto Entity</returns>
        [MapperIgnoreTargetValue(nameof(UserPhoto.Id))]
        public partial UserPhoto UserPhotoModelToUserPhoto(UserPhotoModel model);
    }
}
