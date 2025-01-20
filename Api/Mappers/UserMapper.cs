using Api.ViewModels;
using Core.Models;

namespace Api.Mappers
{
    internal class UserMapper
    {
        public static UserVM Map(User user)
        {
            return new UserVM(user.Username);
        }
    }
}
