using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;
using Riok.Mapperly.Abstractions;

namespace CollabProj.Infrastructure.Mappers.UserRelated
{
    [Mapper]
    public partial class UserMapper
    {
        [MapperIgnoreSourceValue(nameof(User.Id))]
        [MapperIgnoreSourceValue(nameof(User.UserPhoto.Id))]
        [MapProperty(nameof(User.UserPhoto), nameof(UserModel.UserPhotoModel))]
        public partial UserModel UserToUserModel(User user);

        [MapperIgnoreTargetValue(nameof(User.Id))]
        [MapperIgnoreTargetValue(nameof(User.UserPhoto.Id))]
        [MapProperty(nameof(UserModel.UserPhotoModel), nameof(User.UserPhoto))]
        public partial User UserModelToUser(UserModel model);
    }
}
