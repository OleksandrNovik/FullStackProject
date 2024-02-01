using CollabProj.Domain.Entities.User;
using CollabProj.Domain.Models.User;
using Riok.Mapperly.Abstractions;

namespace CollabProj.Infrastructure.Mappers.UserRelated
{
    [Mapper]
    public partial class UserPhotoMapper
    {
        [MapperIgnoreSourceValue(nameof(UserPhoto.Id))]
        public partial UserPhotoModel UserPhotoToUserPhotoModel(UserPhoto photo);

        [MapperIgnoreTargetValue(nameof(UserPhoto.Id))]
        public partial UserPhoto UserPhotoModelToUserPhoto(UserPhotoModel photo);
    }
}
