using Api.ViewModels;
using Core.Models;

namespace Api.Mappers
{
    internal class UserMapper
    {
        public static CreateUserVM Map(CreateUserModel user)
        {
            return new CreateUserVM(user.Username);
        }

        public static GetUserVM Map(GetUserModel user)
        {
            return new GetUserVM(user.Username);
        }

        public static GetUserSaltVM Map(GetUserSaltModel user)
        {
            return new GetUserSaltVM(user.Salt);
        }
    }
}
