using Api.ViewModels;
using Core.Models;

namespace Api.Mappers
{
    internal class UserMapper
    {
        public static UserVM Map(UserModel user)
        {
            return new UserVM(user.Username);
        }
    }
}
