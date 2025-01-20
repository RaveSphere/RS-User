using Core.Models;
using Sql.Entities;

namespace Sql
{
    internal class UserMapper
    {
        public static User Map(UserEntity userEntity)
        {
            return new User(userEntity.Username, userEntity.Password, userEntity.Salt);
        }

        public static UserEntity Map(User user)
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
