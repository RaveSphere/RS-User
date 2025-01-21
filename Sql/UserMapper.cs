using Core.Models;
using Sql.Entities;

namespace Sql
{
    internal class UserMapper
    {
        public static UserModel Map(UserEntity userEntity)
        {
            return new UserModel(userEntity.Username, userEntity.Password, userEntity.Salt);
        }

        public static UserEntity Map(UserModel user)
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
