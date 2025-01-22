using Core.Models;
using Sql.Entities;

namespace Sql.Mappers
{
    internal class UserMapper
    {
        public static GetUserModel Map(UserEntity userEntity)
        {
            return new GetUserModel(userEntity.Username);
        }

        public static GetUserSaltModel SaltMap(UserEntity userEntity)
        {
            return new GetUserSaltModel(new Guid(userEntity.Salt));
        }

        public static UserEntity Map(CreateUserModel user)
        {
            return new UserEntity
            {
                Username = user.Username,
                Password = user.Password,
                Salt = user.Salt
            };
        }
    }
}
